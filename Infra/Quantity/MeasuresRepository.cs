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

        

        private IQueryable<MeasureData> createSorted()

        {
            IQueryable<MeasureData> measures = from s in dbSet select s;
            measures = setSorting(measures);
            return measures.AsNoTracking();

        }
        private IQueryable<MeasureData> createFiltered(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            
                return set.Where(s => s.Name.Contains(SearchString)
                                       || s.Code.Contains(SearchString)
                                       || s.Id.Contains(SearchString)
                                       || s.Definition.Contains(SearchString)
                                       || s.ValidFrom.ToString().Contains(SearchString)
                                       || s.ValidTo.ToString().Contains(SearchString));
            
        }

        public async override Task<List<Measure>> Get()
        {
            var list = await createPaged(createFiltered(createSorted()));
            HasNextPage = list.HasNextPage;
            HasPreviousPage = list.HasPreviousPage;
            return list.Select(e => new Measure(e)).ToList();
        }
        private async Task<PaginatedList<MeasureData>> createPaged(IQueryable<MeasureData> dataSet)
        {

           return await PaginatedList<MeasureData>.CreateAsync(
                dataSet, PageIndex, PageSize);
        }
       
      
    }
}
