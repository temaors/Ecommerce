using eCommerce.APIObjects;
using eCommerce.Validators;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("registration")]
    public class RegisterController : ControllerBase
    {
        private readonly CredentialsValidator<Credentials> _validator;
        public RegisterController()
        {
            _validator = new CredentialsValidator<Credentials>();
        }
        
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult LogIn(Credentials credentials)
        {
            return Ok();
        }
    }
}