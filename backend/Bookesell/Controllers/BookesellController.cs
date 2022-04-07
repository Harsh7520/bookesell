using Bookesell.Models;
using Bookesell.Models.Data;
using Bookesell.Models.ViewModels;
using Bookesell.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Bookesell.Controllers
{
    [Route("api/Bookesell")]
    [ApiController]
    public class BookesellController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BookesellController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] RegisterUserRequest user)
        {
            User registerUserResponse = new User();
            try
            {
                UserRepository userRepo = new UserRepository();
                var userResult = userRepo.RegisterUser(user);
                ResultStateWithModel<UserDetail> resultState = new ResultStateWithModel<UserDetail>();
                resultState.Data = userResult;
                return StatusCode((int)HttpStatusCode.OK, resultState);
            }
            catch (Exception ex)
            {
                ResultState resultState = new ResultState(Messages.GeneralExceptionCode, "Failed", ex.GetBaseException().Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, resultState);
            }

        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                UserRepository userRepo = new UserRepository();
                var userResult = userRepo.Login(loginRequest);
                ResultStateWithModel<UserDetail> resultState = new ResultStateWithModel<UserDetail>();
                resultState.Data = userResult;
                return StatusCode((int)HttpStatusCode.OK, resultState);
            }
            catch (Exception ex)
            {
                ResultState resultState = new ResultState(Messages.GeneralExceptionCode, "Failed", ex.GetBaseException().Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, resultState);
            }
        }

    }
}