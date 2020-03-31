using System;
using HW4.Data.Common;
using HW4.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HW4.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain> 
        where TData :PeriodData, new() 
        where TDomain :Entity<TData>, new()
    {
        protected internal DbSet<TData> dbSet;
        private readonly DbContext db;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }
        
        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }
        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();
            var d = await getData(id);
            var obj = new TDomain
            {
                Data = d
            };
            return obj;
        }
        protected abstract Task<TData> getData(string id);

        protected virtual bool isThisRecord(TData d, string id)
        {
            if (d is UniqueEntityData) return (d as UniqueEntityData).Id == id;
            return true;
        }

        public async Task Update(TDomain obj)
        {
            if (obj is null) return;
            var v = await dbSet.FindAsync(getId(obj));
            if (v is null) return;
            dbSet.Remove(v);
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();


        }

        protected abstract string getId(TDomain entity);
        
           
        

        public async Task Delete(string id)
        {
            var d = await dbSet.FindAsync(id);

            if (d is null) return;

            dbSet.Remove(d);
            await db.SaveChangesAsync();

        }
        public virtual async Task<List<TDomain>> Get()
        {
            var query = createSqlQuery();
            var set = await runSqlQueryAsync(query);
            return toDomainObjectsList(set);
        }

        internal List<TDomain> toDomainObjectsList(List<TData> set)
        {
            var list = new List<TDomain>();
            foreach(var e in set)
            {
                list.Add(toDomainObject(e));

            }
            return list;
        }

        protected internal abstract TDomain toDomainObject(TData periodData);
        
        

        internal async Task<List<TData>> runSqlQueryAsync(IQueryable<TData> query)
        {
            return await query.AsNoTracking().ToListAsync();
        }

        protected internal virtual IQueryable<TData> createSqlQuery()
        {
            var query = from s in dbSet select s;
            return query;
        }
    }
}