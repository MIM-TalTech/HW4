﻿using Facade;
using HW4.Aids;
using HW4.Data;
using HW4.Domain;
using HW4.Facade.Quantity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Pages
{
    public abstract class BasePage<TRepository, TDomain, TView, TData> : PageModel 
        where TRepository : ICrudMethods<TDomain>, ISorting, ISearching, IPaging
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
        public string PageSubTitle { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public int PageIndex { get => data.PageIndex; set => data.PageIndex = value; }
        public int TotalPages { get; set; } = 10;
        public abstract string ItemId { get; }
        public string SearchString { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

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
            if (string.IsNullOrEmpty(CurrentSort)) sortOrder = name;
            else if (!CurrentSort.StartsWith(name)) sortOrder = name;
            else if (CurrentSort.EndsWith("_desc")) sortOrder = name;
            else sortOrder = name + "_desc";
            return $"{page}?sortOrder={sortOrder}&currentFilter={CurrentFilter}";

        }
        protected internal async Task getList(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : sortOrder;
            CurrentSort = sortOrder;
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

            PageIndex = pageIndex ?? 1;
            var l = await data.Get();
            Items = new List<TView>();
            foreach (var e in l)
            {
                Items.Add(toView(e));
            }
        }
    }
}