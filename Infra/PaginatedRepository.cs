﻿using HW4.Data.Common;
using HW4.Domain;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPages => getTotalPages(PageSize);

       

        protected internal override IQueryable<TData> createSqlQuery()
        {
            var query = base.createSqlQuery();
            query = addSkipAndTake(query);
            return query;
        }

        private IQueryable<TData> addSkipAndTake(IQueryable<TData> query)
        {
            var q = query.Skip(
                (PageIndex - 1) * PageSize)
                .Take(PageSize);
            return q;
        }

         int getTotalPages(int pageSize)
        {
            var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);
            return pages;
        }

        internal int countTotalPages(int count, int pageSize)
        {
            return (int)Math.Ceiling(count / (double)pageSize);
        }

       internal int getItemsCount()
        {
            var query = base.createSqlQuery();
            return query.CountAsync().Result;
        }
    }
}