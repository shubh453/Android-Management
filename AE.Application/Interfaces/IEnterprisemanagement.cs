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
        Task<Response<Enterprise>> Create(string enterpriseToken, string signUpUrl);

        Response<List<Enterprise>> List();

        Task<Response<bool>> Remove();

        Task<Response<Enterprise>> Get(string Id);

        Task<Response<Enterprise>> Update(Enterprise enterprise);
    }
}
