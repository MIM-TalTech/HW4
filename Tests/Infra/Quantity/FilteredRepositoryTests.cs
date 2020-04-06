using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Measure, MeasureData>, SortedRepository<Measure, MeasureData>>
    {
        
        private class testClass : FilteredRepository<Measure, MeasureData>
        {

            public testClass(DbContext c, DbSet<MeasureData> s) : base(c, s) { }
            protected internal override Measure toDomainObject(MeasureData d) => new Measure(d);

            protected override async Task<MeasureData> getData(string id)
            {
                return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string getId(Measure entity)
            {
                return entity?.Data?.Id;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new QuantityDbContext(options);
            obj = new testClass(c, c.Measures);
            
        }






        [TestMethod]
        public void SearchStringTest()
        {
           isNullableProperty(() => obj.SearchString, x => obj.SearchString = x);
        }

        [TestMethod]
        public void FixedFilterTest()
        {
            isNullableProperty(() => obj.FixedFilter, x => obj.FixedFilter = x);
        }

        [TestMethod]
        public void FixedValueTest()
        {
            isNullableProperty(() => obj.FixedValue, x => obj.FixedValue = x);
        }



        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var sql = obj.createSqlQuery();
            Assert.IsNotNull(sql);
        }

        [TestMethod]
        public void AddFixedFilteringTest()
        {
            var sql = obj.createSqlQuery();
            var fixedFilter = GetMember.Name<MeasureData>(x => x.Definition);
            obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            obj.FixedValue = fixedValue;
            var sqlNew = obj.addFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateFixedWhereExpressionTest()
        {
            var properties = typeof(MeasureData).GetProperties();
            var idx = GetRandom.Int32(0, properties.Length);
            var p = properties[idx];
            obj.FixedFilter = p.Name;
            var fixedValue = "HW4DEFGH";
            obj.FixedValue = fixedValue;
            var e = obj.createFixedWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{fixedValue}\")";
                Assert.IsTrue(s.Contains(expected));
            
        }
        [TestMethod]
        public void CreateFixedWhereExpressionOnFixedFilterNullTest()
        {
            
            Assert.IsNull(obj.createFixedWhereExpression());
            obj.FixedValue = GetRandom.String();
            obj.FixedFilter = GetRandom.String();
            Assert.IsNull(obj.createFixedWhereExpression());

        }

        [TestMethod]
        public void AddFilteringTest()
        {
            var sql = obj.createSqlQuery();
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var sqlNew = obj.addFiltering(sql);
            Assert.IsNotNull(sqlNew);

        }

        [TestMethod]
        public void CreateWhereExpressionTest()
        {
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var e = obj.createWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();
            foreach (var p in typeof(MeasureData).GetProperties())
            {
                var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{searchString}\")";
                Assert.IsTrue(s.Contains(expected));
            }
        }
        [TestMethod]
        public void CreateWhereExpressionWithNullSearchStringTestTest()
        {
            
            obj.SearchString = null;
            var e = obj.createWhereExpression();
            Assert.IsNull(e);
         ;
           
        }


    }
}
