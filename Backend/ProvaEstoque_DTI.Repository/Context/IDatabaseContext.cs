using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaEstoque_DTI.Repository.Context
{
    public interface IDatabaseContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void Dispose();
    }
}
