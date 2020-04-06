using System;
using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Infra;
using HW4.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Infra.Quantity
{
   [TestClass]
    public class MeasureTermsRepositoryTests : RepositoryTests<MeasureTermsRepository, MeasureTerm, MeasureTermData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {

            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).MeasureTerms;
            obj = new MeasureTermsRepository((QuantityDbContext)db);
            count = GetRandom.UInt8(20, 40);

            base.TestInitialize();

        }







        protected override Type getBaseType()
        {

            return typeof(PaginatedRepository<MeasureTerm, MeasureTermData>);
        }



        protected override string getId(MeasureTermData d)
        {
            return $"{d.MasterId}.{d.TermId}";
        }

        protected override MeasureTerm getObject(MeasureTermData d)
        {
            return new MeasureTerm(d);
        }

        protected override void setId(MeasureTermData d, string id)
        {

            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;
        }

    }

}

