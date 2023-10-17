using eCommerce.APIObjects;
using eCommerce.Validators;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly CredentialsValidator<Credentials> _validator;
        public RegistrationController()
        {
            _validator = new CredentialsValidator<Credentials>();
        }
        
        [Route("register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(Credentials credentials)
        {
            if (_validator.IsValid(credentials))
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult LogIn(Credentials credentials)
        {
            return Ok();
        }
    }
}