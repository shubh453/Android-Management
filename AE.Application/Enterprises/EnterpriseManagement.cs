using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AE.Application.Auth;
using AE.Application.Interfaces;
using AE.Domain.Abstract;
using Google.Apis.AndroidManagement.v1;
using Google.Apis.AndroidManagement.v1.Data;
using Microsoft.Extensions.Configuration;

namespace AE.Application.Enterprises
{
    public class EnterpriseManagement: IEnterpriseManagement
    {
        private readonly AndroidManagementService _service;
        private readonly IConfiguration _configuration;
        private readonly IAppDbContext _context;
        public EnterpriseManagement(
            IConfiguration configuration,
            IAppDbContext context)
        {
            _configuration = configuration;
            _context = context;
            _service = configuration.GetAndroidService();
        }

        public async Task<Response<SignupUrl>> SignUp()
        {
            try
            {
                var signUpCreateResource = _service.SignupUrls.Create();

                signUpCreateResource.CallbackUrl = _configuration.GetSection("CallbackUrl").Value;
                signUpCreateResource.ProjectId = _configuration.GetSection("ProjectId").Value;

                var signupUrl = await signUpCreateResource.ExecuteAsync();

                return new Response<SignupUrl>(
                    signupUrl,
                    "Sign up request completed Successfully. SignUp Url contains the enterprise token.");
            }
            catch (Exception e)
            {
                return new Response<SignupUrl>(
                    e,
                    "Sign up request Failed");

            }
        }

        public async Task<Response<string>> SaveSignUpDetails(SignupUrl signupUrl)
        {
            try
            {
                var enterpriseToken = signupUrl.Url.Split("token=").LastOrDefault();


                await _context.SaveChangesAsync(CancellationToken.None);
                
                return new Response<string>(
                    enterpriseToken,
                    "SignUp Saved Successfully");
            }
            catch (Exception e)
            {
                return new Response<string>(
                    e,
                    "Sign up request Failed");

            }

           
        }

        public async Task<Response<Enterprise>> CreateEnterprise(string enterpriseToken, string signUpUrl)
        {
            try
            {
                var enterprise = new Enterprise
                {
                    EnabledNotificationTypes = new [] {"ENROLLMENT", "STATUS_REPORT", "COMMAND"},
                    Name = "Catalyst IT",
                    SigninDetails = new List<SigninDetail>() { new SigninDetail { SigninUrl = signUpUrl, SigninEnrollmentToken = "enterpriseToken" } }
                };
                var createdenterprise = await _service.Enterprises.Create(enterprise).ExecuteAsync();

                return new Response<Enterprise>(
                    createdenterprise,
                    "Enterprise Created Successfully");
            }
            catch (Exception e)
            {
                return new Response<Enterprise>(
                    e,
                    "Enterprise Create request failed");
            }
        }

       
    }
}
