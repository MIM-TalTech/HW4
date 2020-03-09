using HW4.Data.Common;
using HW4.Domain;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW4.Infra
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, ISearching
         where TData : UniqueEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        protected FilteredRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
            
        }
        protected internal override IQueryable<TData> createSqlQuery()
        {
        var query = base.createSqlQuery();
            query = addFiltering(query);
            return query;
        }

        protected internal virtual IQueryable<TData> addFiltering(IQueryable<TData> query)
        {
            return query;
        }

        public string SearchString { get; set; }
    }
}