using HW4.Aids;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HW4.Domain.Common;

namespace HW4.Pages
{
    public abstract class BasePage<TRepository, TDomain, TView, TData> : PageModel 
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        private TRepository data;

         protected internal BasePage(TRepository r)
        {
            data = r;

        }

        [BindProperty]
        public TView Item { get; set; }
        public IList<TView> Items { get; set; }
        public string PageTitle { get; set; }
        public string PageSubTitle => getPageSubtitle();

        protected internal virtual string getPageSubtitle()
        {
            return string.Empty;
        }

        public string FixedFilter { get => data.FixedFilter; set => data.FixedFilter = value; }

        public string FixedValue { get => data.FixedValue; set => data.FixedValue = value; }
        public string SortOrder { get => data.SortOrder; set => data.SortOrder = value; }
       
        public int PageIndex { get => data.PageIndex; set => data.PageIndex = value; }
        public int TotalPages { get; set; } = 10;
        public abstract string ItemId { get; }
        public string SearchString { get => data.SearchString; set => data.SearchString = value; }
        public bool HasPreviousPage => data.HasPreviousPage;
        public bool HasNextPage => data.HasNextPage;

        protected internal async Task<bool> addObject()
        {
            // TODO
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            try
            {
                if (!ModelState.IsValid)
                {
                    return false;
                }

                await data.Add(toObject(Item));
            }
            catch
            {
                return false;
            }
            return true;
        }

        protected internal abstract TDomain toObject(TView view);
      

        protected internal async Task updateObject()
        {
            // TODO
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            await data.Update(toObject(Item));

        }
        protected internal async Task getObject(string id)
        {

            var o = await data.Get(id);
            Item = toView(o);


        }

        protected internal abstract TView toView(TDomain o);
       

        protected internal async Task deleteObject(string id)
        {
            await data.Delete(id);
        }

        public string GetSortString(Expression<Func<TData, object>> e, string page)
        {

            var name = GetMember.Name(e);
            string sortOrder;
            if (string.IsNullOrEmpty(SortOrder)) sortOrder = name;
            else if (!SortOrder.StartsWith(name)) sortOrder = name;
            else if (SortOrder.EndsWith("_desc")) sortOrder = name;
            else sortOrder = name + "_desc";
            return $"{page}?sortOrder={sortOrder}&currentFilter={SearchString}";

        }
        protected internal async Task getList(string sortOrder, string currentFilter, string searchString, int? pageIndex, 
            string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = getSearchString(currentFilter, searchString, ref pageIndex);
            PageIndex = pageIndex ?? 1;
            Items = await getList();
           
         
        }



        private string getSearchString(string currentFilter, string searchString, ref int? pageIndex)
        {

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            return searchString;
        }

        internal async Task<List<TView>> getList()
        {
            var l = await data.Get();
            var list  = new List<TView>();
            foreach (var e in l)
            {
                list.Add(toView(e));
            }

            return list;
        }
    }
}
