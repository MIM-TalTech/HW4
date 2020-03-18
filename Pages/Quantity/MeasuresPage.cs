using Facade;
using HW4.Data;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using HW4.Pages;


namespace Pages
{
    public class MeasuresPage : BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {

        protected internal MeasuresPage(IMeasuresRepository r) : base(r)
        {
    
            PageTitle = "Measures";
        }
        public override string ItemId => Item.Id;

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

