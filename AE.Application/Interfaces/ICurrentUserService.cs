using System;
using System.Collections.Generic;
using System.Text;

namespace AE.Application.Interfaces
{
    public interface ICurrentUserService
    {
        long UserId { get; set; }
        int OrganizationId { get; set; }
    }
}
