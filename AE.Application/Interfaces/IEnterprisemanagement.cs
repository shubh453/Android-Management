using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AE.Domain.Abstract;
using Google.Apis.AndroidManagement.v1.Data;

namespace AE.Application.Interfaces
{
    public interface IEnterpriseManagement
    {
        Task<Response<SignupUrl>> SignUp();
        Task<Response<Enterprise>> CreateEnterprise(string enterpriseToken, string signUpUrlN);
        Task<Response<string>> SaveSignUpDetails(SignupUrl signupUrl);
    }
}
