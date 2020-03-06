using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AE.Domain.Abstract;
using Google.Apis.AndroidManagement.v1.Data;

namespace AE.Application.Interfaces
{
    public interface IUserSignUp
    {
        Task<Response<SignupUrl>> SignUp();
        Task<Response<string>> SaveDetails(SignupUrl signupUrl);
    }
}
