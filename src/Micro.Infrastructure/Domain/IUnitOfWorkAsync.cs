using System;
using System.Threading;
using System.Threading.Tasks;

namespace Micro.Infrastructure.Domain
{
    public interface IUnitOfWorkAsync : IRepositoryFactoryAsync, IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
