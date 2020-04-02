using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;

namespace HW4.Infra.Quantity
{
    public sealed class MeasuresRepository: UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository
    {
        
            public MeasuresRepository(QuantityDbContext c) : base(c, c.Measures)
        {
            
        }
        protected override async Task<MeasureData> getData(string id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }
        protected internal override Measure toDomainObject(MeasureData d)
        {
            return new Measure(d);
        }
    }
}
