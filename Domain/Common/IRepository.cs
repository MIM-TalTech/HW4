using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4.Domain.Quantity
{
    public interface IRepository<T> : ICrudMethods<T>, IPaging, ISorting, ISearching
    {
       
        
      

    }
}