using HW4.Data;
using HW4.Domain.Quantity;
using HW4.Infra;
using HW4.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public class MeasuresRepository: UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository
    {
        
            public MeasuresRepository(QuantityDbContext c) : base(c, c.Measures)
        {
            
        }
        protected override async Task<MeasureData> getData(string id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

        protected internal override IQueryable<MeasureData> addFiltering(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            
                return set.Where(s => s.Name.Contains(SearchString)
                                       || s.Code.Contains(SearchString)
                                       || s.Id.Contains(SearchString)
                                       || s.Definition.Contains(SearchString)
                                       || s.ValidFrom.ToString().Contains(SearchString)
                                       || s.ValidTo.ToString().Contains(SearchString));
            
        }

       
     

        protected internal override Measure toDomainObject(MeasureData d)
        {
            return new Measure(d);
        }
    }
}
