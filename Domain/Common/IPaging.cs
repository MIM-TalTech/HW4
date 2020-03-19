namespace HW4.Domain.Common
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