using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Domain
{
    public interface IPaging
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get;}
        int TotalPages { get; }

        int PageIndex { get; set; }
        int PageSize { get; set; }
      

    }
}