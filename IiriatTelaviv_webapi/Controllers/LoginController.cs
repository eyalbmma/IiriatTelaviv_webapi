using DomainIriatTelaviv.Entities;
using DomainIriatTelaviv.Interfaces;
using DomainIriatTelaviv.Res_Req.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IiriatTelaviv_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IloginRepository _loginRepository;
        public LoginController(IloginRepository loginRepository)
        {

            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Users login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {





                response = Ok(new LoginResult { success = user.success, id= user.id});
            }
            return response;
        }




        private LoginResult AuthenticateUser(Users login)
        {
            Users user = null;
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    

            LoginResult res = _loginRepository.Login(login);

            if (res.success)
            {
                return res;

            }
            else
            {
                return new LoginResult
                {

                    success = false

                };
            }


        }
    }
}
