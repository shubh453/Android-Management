using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AE.Domain.Entities;
using Google.Apis.AndroidManagement.v1.Data;
using Microsoft.EntityFrameworkCore;
using User = AE.Domain.Entities.User;

namespace AE.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<SignUpDetail> SignUpDetails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
