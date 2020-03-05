using HW4.Data.Common;
using HW4.Domain;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Infra
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
         where TData : UniqueEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
          
        }

        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 12;
    }
}