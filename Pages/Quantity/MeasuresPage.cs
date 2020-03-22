using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;


namespace HW4.Pages.Quantity
{
    public abstract class MeasuresPage : BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {

        protected internal MeasuresPage(IMeasuresRepository r) : base(r)
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


    
}

