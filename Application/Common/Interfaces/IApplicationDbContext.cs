using DemoProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Phone> Phones { get; set; }

        DbSet<ApplicationUser> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
