using System.Collections.Generic;
using System.Threading.Tasks;
using Facade;
using Pages;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;

namespace Soft
{
    public class IndexModel : MeasuresPage
    {
       public IndexModel(IMeasuresRepository r ) : base(r) { }

        public async Task OnGetAsync()
        {
            var l = await data.Get();
            Items = new List<MeasureView>();
            foreach( var e in l)
            {
                Items.Add(MeasureViewFactory.Create(e));
            }
         
        }
    }
}
