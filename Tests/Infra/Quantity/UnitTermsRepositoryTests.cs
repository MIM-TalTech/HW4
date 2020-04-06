using System;
using System.Collections.Generic;
using System.Text;
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
    public class UnitTermsRepositoryTests : RepositoryTests<UnitTermsRepository, UnitTerm, UnitTermData>
    {

        [TestInitialize]
        public override void TestInitialize()
        {

            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).UnitTerms;
            obj = new UnitTermsRepository((QuantityDbContext)db);
            count = GetRandom.UInt8(20, 40);

            base.TestInitialize();

        }







        protected override Type getBaseType()
        {

            return typeof(PaginatedRepository<UnitTerm, UnitTermData>);
        }



        protected override string getId(UnitTermData d)
        {
            return $"{d.MasterId}.{d.TermId}";
        }

        protected override UnitTerm getObject(UnitTermData d)
        {
            return new UnitTerm(d);
        }

        protected override void setId(UnitTermData d, string id)
        {

            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;
        }

    }

}


