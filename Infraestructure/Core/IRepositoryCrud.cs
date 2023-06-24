using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core
{
    public interface IRepositoryCrud<T, K>
    {
        Task<T> Create(T entity);
        Task<T?> Update(T entity);
        Task<T?> Delete(K id);
        Task<T?> Find(K id);
        Task<IList<T>> FindAll();
    }
}
