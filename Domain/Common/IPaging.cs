using System;
using System.Collections.Generic;
using System.Text;

namespace HW4.Domain
{
    public interface IPaging
    {
        bool HasNextPage { get; set; }
        bool HasPreviousPage { get; set; }
        int PageIndex { get; set; }

    }
}