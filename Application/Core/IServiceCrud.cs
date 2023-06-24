using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IServiceCrud<TDto, TFormDto, K>
    {
        Task<TDto> Create(TFormDto dto);
        Task<TDto?> Update(TDto dto);
        Task<TDto?> Delete(K id);
        Task<TDto?> Find(K id);
        Task<IList<TDto>> FindAll();
    }
}
