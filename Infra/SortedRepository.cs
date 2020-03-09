using HW4.Data.Common;
using HW4.Domain;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HW4.Infra
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
         where TData : UniqueEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
          
        }
        protected internal override IQueryable<TData> createSqlQuery()
        {
            var query =base.createSqlQuery();
            query = addSorting(query);
            return query;
        }
        public string SortOrder { get; set; }
        public string DescendingString => "_desc";

        protected internal IQueryable<TData> addSorting(IQueryable<TData> query)
        {
            var expression = createExpression();
            var r = expression is null ? query  : addOrderBy(query, expression);
            return r;
        }

        protected internal IQueryable<TData> addOrderBy(IQueryable<TData> query, Expression<Func<TData, object>> ex)
        {
            if (query is null) return null;
            if (ex is null) return query;

            try { return isDescending() ? query.OrderByDescending(ex) : query.OrderBy(ex); }
            catch { return query; }
                    
        }

        internal Expression<Func<TData, object>> createExpression()
        {
            var property = findProperty();
            if (property is null) return null;
            return lambdaExpression(property);
        }

        internal Expression<Func<TData, object>> lambdaExpression(PropertyInfo p)
        {
            var param = Expression.Parameter(typeof(TData));
            var property = Expression.Property(param, p);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);

        }

        internal PropertyInfo findProperty()
        {
            var name = getName();
            return typeof(TData).GetProperty(name);
        }

        internal string getName()
        {
            if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
            var idx = SortOrder.IndexOf(DescendingString, StringComparison.Ordinal);
            if(idx >= 0) return SortOrder.Remove(idx);
            return SortOrder;
        }

        internal bool isDescending() => !string.IsNullOrEmpty(SortOrder) && SortOrder.EndsWith(DescendingString);

        
    }
}