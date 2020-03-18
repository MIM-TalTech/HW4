using System.Collections.Generic;
using System.Threading.Tasks;
using Facade;
using Pages;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using System;
using HW4.Data;
using System.Linq.Expressions;
using HW4.Aids;
using HW4.Pages.Quantity;

namespace Soft.Areas.Quantity.Pages.Units
{
    public class IndexModel : UnitsPage
    {
       public IndexModel(IUnitsRepository r, IMeasuresRepository m ) : base(r, m) { }
       

      

        

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex);

        }


       
    }
}
