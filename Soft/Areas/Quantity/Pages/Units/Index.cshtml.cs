using System.Threading.Tasks;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Units
{
    public class IndexModel : UnitsPage
    {
       public IndexModel(IUnitsRepository r, IMeasuresRepository m ) : base(r, m) { }
       

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }


       
    }
}
