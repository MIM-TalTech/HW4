
using HW4.Facade.Common;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HW4.Tests.Facade.Quantity
{
        [TestClass]
    public class UnitViewTests : SealedClassTests<UnitView, DefinedView>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            isNullableProperty(() => obj.MeasureId, x=> obj.MeasureId =x);
        }
    }
}
