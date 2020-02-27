using System.Collections.Generic;
using System.Threading.Tasks;
using Facade;
using Pages;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using System;


namespace Soft
{
    public class IndexModel : MeasuresPage
    {
       public IndexModel(IMeasuresRepository r ) : base(r) { }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string SearchString { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int PageIndex { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        

        

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            data.SortOrder = sortOrder;
            SearchString = CurrentFilter;
            data.SearchString = SearchString;
            data.PageIndex = pageIndex ?? 1;
            PageIndex = data.PageIndex;
            var l = await data.Get();
            Items = new List<MeasureView>();
            foreach( var e in l)
            {
                Items.Add(MeasureViewFactory.Create(e));
            }
            HasNextPage = data.HasNextPage;
            HasPreviousPage = data.HasPreviousPage;
         
        }
    }
}
