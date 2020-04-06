using System;
using System.Collections.Generic;
using System.Text;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Infra;
using HW4.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Infra.Quantity
{
    [TestClass]
    public class UnitsRepositoryTests : RepositoryTests<UnitsRepository, Unit, UnitData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {

            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).Units;
            obj = new UnitsRepository((QuantityDbContext)db);
            count = GetRandom.UInt8(20, 40);

            base.TestInitialize();

        }

        protected override Type getBaseType() => typeof(UniqueEntityRepository<Unit, UnitData>);




       

        protected override string getId(UnitData d) => d.Id;
        
        

        protected override Unit getObject(UnitData d) => new Unit(d);


        protected override void setId(UnitData d, string id) => d.Id = id;

    }
}
