using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IRegister _register;
        public RegisterController(IRegister register)
        {
            _register = register;
        }

        [HttpPost]
        public string Post(RegistrationDetails registrationDetails)
        {
            return _register.CreatePassword(registrationDetails);
        }
    }
}
