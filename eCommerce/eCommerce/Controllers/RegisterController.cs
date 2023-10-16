using eCommerce.APIObjects;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("registration")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(RegisterCreditionals creditionals)
        {
            
            return BadRequest();
        }
        
    }
}