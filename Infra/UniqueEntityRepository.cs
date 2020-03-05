using HW4.Data.Common;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Infra
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData> 
        where TData: UniqueEntityData ,new()
        where TDomain : Entity<TData>, new()
    {

        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {

        }

        protected override async Task<TData> getData(string id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
