using System.Threading.Tasks;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using HW4.Pages.Quantity;


namespace Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
       public IndexModel(IMeasuresRepository r ) : base(r) { }
       
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }

       
    }
}
