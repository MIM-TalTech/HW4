using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Data.Quantity;
using HW4.Infra;
using HW4.Infra.Quantity;

namespace HW4.Infra.Quantity {

    public sealed class SystemsOfUnitsRepository : UniqueEntityRepository<SystemOfUnits, SystemOfUnitsData>,
        ISystemsOfUnitsRepository {

        public SystemsOfUnitsRepository() : this(null) { }
        public SystemsOfUnitsRepository(QuantityDbContext c) : base(c, c?.SystemsOfUnits) { }

        protected internal override SystemOfUnits toDomainObject(SystemOfUnitsData d) => new SystemOfUnits(d);


    }

}

