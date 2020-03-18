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

namespace Soft
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
