using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.Validators;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly CredentialsValidator<Credentials> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validator = new CredentialsValidator<Credentials>();
        }
        
        [Route("register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(Credentials credentials)
        {
            if (_validator.IsValid(credentials))
            {
                var createdUser = await _unitOfWork.Users.Create(new()
                {
                    Email = credentials.Email,
                    Password = credentials.Password,
                });
                _unitOfWork.Complete();
                return Ok(createdUser);
            }
            return BadRequest();
        }
        
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LogIn(Credentials credentials) =>
            Ok(await _unitOfWork.Users.FindBy(p =>
                p.Email == credentials.Email &&
                p.Password == credentials.Password));
    }
}