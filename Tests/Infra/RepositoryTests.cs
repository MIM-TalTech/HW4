using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HW4.Data.Common;
using HW4.Data.Quantity;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using HW4.Infra;
using HW4.Infra.Quantity;
using HW4.Tests.Infra.Quantity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Infra
{
    [TestClass]
    public abstract class RepositoryTests<TRepository, TObject, TData> : BaseTests 
        where TRepository : IRepository<TObject>
    where TObject : Entity<TData>
    where TData : PeriodData, new()
    {
        private TData data;
        protected TRepository obj;

       

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TRepository);
            data = GetRandom.Object<TData>();
        }



        [TestMethod]
        public void GetTest()
        {
            testGetList();
        }
        [TestMethod]
        public void IsSealedTest()
        {
            Assert.IsTrue(type.IsSealed);
        }
        [TestMethod]
        public void IsInheritedTest()
        {
            Assert.AreEqual(getBaseType().Name, type?.BaseType?.Name);
        }

        protected abstract Type getBaseType();

        protected abstract void testGetList();

        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var id = getId(data);
            var expected = obj.Get(id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(data, expected.Data);
            obj.Delete(id).GetAwaiter();
            expected = obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);


        }

        protected abstract string getId(TData d);
        

            [TestMethod]
        public void AddTest()
        {
            var id = getId(data);
            var expected = obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            obj.Add(getObject(data)).GetAwaiter();
            expected = obj.Get(id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(data, expected.Data);
        }

        protected abstract TObject getObject(TData d);
      

        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var id = getId(data);
            var newData = GetRandom.Object<TData>();
            setId(newData, id);
            obj.Update(getObject(newData)).GetAwaiter();
            var expected = obj.Get(id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(newData, expected.Data);
        }

        protected abstract void setId(TData newData, string id);
    }
}
