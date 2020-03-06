using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AE.Application.Interfaces;
using AE.Domain.Abstract;
using AE.Domain.Entities;
using AE.Domain.Enums;
using Google.Apis.AndroidManagement.v1;
using Google.Apis.AndroidManagement.v1.Data;
using Microsoft.Extensions.Configuration;

namespace AE.Application.Auth
{
    public class UserSignUp: IUserSignUp
    {
        private readonly AndroidManagementService _service;
        private readonly IConfiguration _configuration;
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUser;
        public UserSignUp(
            IConfiguration configuration,
            IAppDbContext context,
            ICurrentUserService currentUser)
        {
            _configuration = configuration;
            _context = context;
            _currentUser = currentUser;
            _service = configuration.GetAndroidService();
        }

        public async Task<Response<SignupUrl>> SignUp()
        {
            try
            {
                var signUpCreateResource = _service.SignupUrls.Create();

                signUpCreateResource.CallbackUrl = _configuration.GetSection("CallbackUrl").Value;
                signUpCreateResource.ProjectId = _configuration.GetSection("ProjectId").Value;

                var signUpUrl = await signUpCreateResource.ExecuteAsync();

                return new Response<SignupUrl>(
                    signUpUrl,
                    "Sign up request completed Successfully. SignUp Url contains the enterprise token.");
            }
            catch (Exception e)
            {
                return new Response<SignupUrl>(
                    e,
                    "Sign up request Failed");

            }
        }

        public async Task<Response<string>> SaveDetails(SignupUrl signUpUrl)
        {
            try
            {

                if(signUpUrl == null) throw new ArgumentNullException(nameof(signUpUrl));

                var enterpriseToken = signUpUrl.Url.Split("token=").LastOrDefault();

                var organization = _context.Users.Where(u => u.Id == _currentUser.UserId).Select(u => u.Organization).FirstOrDefault();

                _context.SignUpDetails.Add(new SignUpDetail(signUpUrl.Name,
                    signUpUrl.Url,
                    enterpriseToken,
                    EStatus.Pending,
                    organization));

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
    }
}
