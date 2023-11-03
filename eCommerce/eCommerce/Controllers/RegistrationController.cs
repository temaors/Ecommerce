using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.Validators;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly CredentialsValidator<APICredentials> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validator = new CredentialsValidator<APICredentials>();
        }
        
        [Route("register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(APICredentials apiCredentials)
        {
            if (_validator.IsValid(apiCredentials))
            {
                var createdUser = await _unitOfWork.Users.Create(new()
                {
                    Email = apiCredentials.Email,
                    Password = apiCredentials.Password,
                });
                _unitOfWork.Complete();
                return Ok(createdUser);
            }
            return BadRequest();
        }
        
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LogIn(APICredentials apiCredentials) =>
            Ok(await _unitOfWork.Users.FindBy(p =>
                p.Email == apiCredentials.Email &&
                p.Password == apiCredentials.Password));
    }
}