namespace HW4.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, ISorting, ISearching, IPaging
    {
       
        
      

    }
}