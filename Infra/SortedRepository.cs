using HW4.Data.Common;
using HW4.Domain;
using HW4.Domain.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}