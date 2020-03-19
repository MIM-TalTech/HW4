using System.Threading.Tasks;
using HW4.Domain.Common;
using HW4.Domain.Quantity;
using Pages;

namespace Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
       public IndexModel(IMeasuresRepository r ) : base(r) { }
       

      

        

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex);

        }

       
    }
}
