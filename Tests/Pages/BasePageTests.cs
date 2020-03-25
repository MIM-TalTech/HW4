using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HW4.Aids;
using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using HW4.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages
{
    [TestClass]
    public class BasePageTests : AbstractClassTests<BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>,
        PageModel>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(new testRepository());
            
        }


        private class testRepository : baseTestRepository<Measure, MeasureData>, IMeasuresRepository
        {

        }

        [TestClass]
        private class testClass : BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>
        {

            protected internal testClass(IMeasuresRepository r) : base(r)
            {

                PageTitle = "Measures";
            }

            protected internal override string getPageUrl() => "/Quantity/Measures";




            public override string ItemId => Item?.Id ?? string.Empty;

            protected internal override Measure toObject(MeasureView view)
            {
                return MeasureViewFactory.Create(view);
            }

            protected internal override MeasureView toView(Measure o)
            {
                return MeasureViewFactory.Create(o);
            }


          

           


           
        }
        [TestMethod]
        public void CreateBasePageWithRepositoryTest()
        {
            Assert.Inconclusive();

        }

        [TestMethod]
        public void ItemTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ItemsTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ItemIdTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void PageTitleTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetPageSubTitleTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void IndexUrlTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetIndexUrlTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void PageUrlTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetPageUrlTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void FixedFilterTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void FixedValueTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void SortOrderTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void SearchStringTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void PageIndexTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void PageSubTitleTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void HasPreviousPageTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void HasNextPageTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void TotalPagesTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void AddObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ToObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void UpdateObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ToViewTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void DeleteObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetSortStringTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetListNoParamsTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetSearchStringTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void GetListTest()
        {
            Assert.Inconclusive();
        }
    }

   
}
