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
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseManagement _enterpriseManagement;

        public EnterpriseController(IEnterpriseManagement enterpriseManagement)
        {
            _enterpriseManagement = enterpriseManagement;
        }

        

        [ActionName("Create")]
        [HttpPost]
        public async Task<Response<Enterprise>> Create(string enterpriseToken, string signUpUrl)
        {
            return await _enterpriseManagement.Create(enterpriseToken, signUpUrl);
        }


    }
}