using HW4.Data.Quantity;
using HW4.Domain.Common;
using HW4.Facade.Quantity;
using System.Collections.Generic;
using HW4.Domain.Quantity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW4.Pages.Quantity
{
    public abstract class UnitsPage : BasePage<IUnitsRepository, Unit, UnitView, UnitData>
    {

        protected internal UnitsPage(IUnitsRepository r, IMeasuresRepository m) : base(r)
        {

        PageTitle = "Units";
        Measures = createMeasures(m);
        }

        private static IEnumerable<SelectListItem> createMeasures(IMeasuresRepository r)
        {
            var list = new List<SelectListItem>();
            var measures = r.Get().GetAwaiter().GetResult();
            foreach (var m in measures)
            {
                list.Add(new SelectListItem(m.Data.Name, m.Data.Id));
            }
            return list;
        }

        public IEnumerable<SelectListItem> Measures { get; }
        public override string ItemId => Item?.Id ?? string.Empty;
        protected internal override string getPageUrl() => "/Quantity/Units";
        
        

        protected internal override string getPageSubtitle()
        {
            if (FixedValue is null) return base.getPageSubtitle();
            return $"For {GetMeasureName(FixedValue)}";
        }

        protected internal override Unit toObject(UnitView view)
        {
        return UnitViewFactory.Create(view);
        }

    protected internal override UnitView toView(Unit o)
        {
        return UnitViewFactory.Create(o);
        }


    public string GetMeasureName(string measureId)
        {
        foreach(var m in Measures)
            if (m.Value == measureId)
                return m.Text;
        return "Unspecified";

        }



    }
}
