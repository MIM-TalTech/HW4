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

        public string SortOrder { get; set; }
        public string DescendingString => "_desc";

        protected internal IQueryable<TData> setSorting(IQueryable<TData> data)
        {
            var expression = createExpression();
            if (expression is null) return data;
            return setOrderBy(data, expression);
        }

        protected internal IOrderedQueryable<TData> setOrderBy(IQueryable<TData> data, Expression<Func<TData, object>> ex)
        {
            var expression = createExpression();
            return isDescending(SortOrder) ? data.OrderByDescending(ex) : data.OrderBy(ex);
                    
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

        private string getName()
        {
            if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
            return SortOrder.Remove(SortOrder.IndexOf(DescendingString, StringComparison.Ordinal));
        }

        internal bool isDescending(string sortOrder) => sortOrder.EndsWith(DescendingString);
    }
}