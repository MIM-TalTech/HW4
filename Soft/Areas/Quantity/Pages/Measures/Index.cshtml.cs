using System.Collections.Generic;
using System.Threading.Tasks;
using Facade;
using Pages;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using System;
using HW4.Infra;

namespace Soft
{
    public class IndexModel : MeasuresPage
    {
       public IndexModel(IMeasuresRepository r ) : base(r) { }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string SearchString;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            data.SortOrder = sortOrder;
            SearchString = searchString;
            data.SearchString = SearchString;
            var l = await data.Get();
            Items = new List<MeasureView>();
            foreach( var e in l)
            {
                Items.Add(MeasureViewFactory.Create(e));
            }
         
        }
    }
}
