using HW4.Data.Common;
using HW4.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HW4.Infra
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : Entity<TData>, new()
         where TData : PeriodData, new()
       
    {
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }


        protected FilteredRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
            
        }
        protected internal override IQueryable<TData> createSqlQuery()
        {
        var query = base.createSqlQuery();
            query = addFixedFiltering(query);
            query = addFiltering(query);
            return query;
        }

        internal IQueryable<TData> addFixedFiltering(IQueryable<TData> query)
        {
            var expression = createFixedWhereExpression();
            return expression is null? query :
            query.Where(expression);
        }

        internal Expression<Func<TData, bool>>createFixedWhereExpression()
        {
            if (string.IsNullOrWhiteSpace(FixedValue)) return null;
            if (string.IsNullOrWhiteSpace(FixedFilter)) return null;
            var param = Expression.Parameter(typeof(TData), "s");
          
            var p = typeof(TData).GetProperty(FixedFilter);
            if (p is null) return null;
                Expression body = Expression.Property(param, p);
                if (p.PropertyType != typeof(string))
                    body = Expression.Call(body, "ToString", null);
                body = Expression.Call(body, "Contains", null, Expression.Constant(FixedValue));
                var predicate = body;
            return Expression.Lambda<Func<TData, bool>>(predicate, param);
        }

        protected internal IQueryable<TData> addFiltering(IQueryable<TData> query)
        {
            if (string.IsNullOrEmpty(SearchString)) return query;
            var expression = createWhereExpression();
            
            return query.Where(expression);

        }

        internal Expression<Func<TData, bool>> createWhereExpression()
        {
            if (string.IsNullOrWhiteSpace((SearchString))) return null;
            var param = Expression.Parameter(typeof(TData), "s");
            Expression predicate = null;
            foreach (var p in typeof(TData).GetProperties())
            {
                Expression body = Expression.Property(param, p);
                if (p.PropertyType != typeof(string))
                    body = Expression.Call(body, "ToString", null);
                    body = Expression.Call(body, "Contains", null, Expression.Constant(SearchString));

                if (predicate is null) predicate = body;
                else predicate = Expression.Or(predicate, body);

            }
            if (predicate is null) return null;
            return Expression.Lambda<Func<TData, bool>>(predicate, param);
        }
        

        
    }
}