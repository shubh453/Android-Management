using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AE.Application.Enterprises;
using AE.Application.Interfaces;

namespace AE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IEnterpriseManagement, EnterpriseManagement>();
            return service;
        }
    }
}
