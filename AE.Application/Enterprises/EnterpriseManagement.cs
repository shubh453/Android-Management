using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AE.Application.Auth;
using AE.Application.Interfaces;
using AE.Domain.Abstract;
using AE.Domain.Entities;
using AE.Domain.Enums;
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
        private readonly ICurrentUserService _currentUser;
        public EnterpriseManagement(
            IConfiguration configuration,
            IAppDbContext context,
            ICurrentUserService currentUser)
        {
            _configuration = configuration;
            _context = context;
            _currentUser = currentUser;
            _service = configuration.GetAndroidService();
        }

        public async Task<Response<Enterprise>> Create(string enterpriseToken, string signUpUrl)
        {
            try
            {
                if (enterpriseToken == null) throw new ArgumentNullException(nameof(enterpriseToken));
                if (signUpUrl == null) throw new ArgumentNullException(nameof(signUpUrl));

                var enterprise = new Enterprise
                {
                    EnabledNotificationTypes = new [] {"ENROLLMENT", "STATUS_REPORT", "COMMAND"},
                    Name = "Catalyst IT",
                    SigninDetails = new List<SigninDetail>() { new SigninDetail { SigninUrl = signUpUrl, SigninEnrollmentToken = "enterpriseToken" } }
                };
                var createdEnterprise = await _service.Enterprises.Create(enterprise).ExecuteAsync();

                return new Response<Enterprise>(
                    createdEnterprise,
                    "Enterprise Created Successfully");
            }
            catch (Exception e)
            {
                return new Response<Enterprise>(
                    e,
                    "Enterprise Create request failed");
            }
        }

        public Response<List<Enterprise>> List()
        {

            try
            {
                var details = _context.SignUpDetails
                                    .Where(u => 
                                        u.OrganizationId == _currentUser.OrganizationId 
                                        && u.Status == EStatus.Pending)
                                    .ToList();
                var enterprises = details.Select(
                                                detail => _service.Enterprises.Get(detail.EnterpriseId).Execute()).ToList();

                return new Response<List<Enterprise>>(
                    enterprises,
                    "Enterprise Created Successfully");
            }
            catch (Exception e)
            {
                return new Response<List<Enterprise>>(
                    e,
                    "Enterprise Create request failed");
            }
        }

        public Task<Response<bool>> Remove()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Enterprise>> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Enterprise>> Update(Enterprise enterprise)
        {
            try
            {
                if (enterprise == null) throw new ArgumentNullException(nameof(enterprise));
                
                var createdEnterprise = await _service.Enterprises.Patch(enterprise, enterprise.Name).ExecuteAsync();

                return new Response<Enterprise>(
                    createdEnterprise,
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
