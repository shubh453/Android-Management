using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AE.Application.Interfaces;
using AE.Domain.Abstract;
using Google.Apis.AndroidManagement.v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AE.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IUserSignUp _signUp;

        public SignUpController(IUserSignUp signUp)
        {
            _signUp = signUp;
        }

        [ActionName("SignUp")]
        [HttpGet]
        public async Task<Response<SignupUrl>> SignUp()
        {
            return await _signUp.SignUp();
        }

        [HttpPost]
        public async Task CompleteSignUp(SignupUrl signupUrl)
        {
            await _signUp.SaveDetails(signupUrl);
        }
    }
}