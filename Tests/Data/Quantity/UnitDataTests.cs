using HW4.Data.Common;
using HW4.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTests<UnitData, DefinedEntityData>
    {

        [TestMethod]
        public void MeasureIdTest()
        {
            isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);
        }
    }
}
