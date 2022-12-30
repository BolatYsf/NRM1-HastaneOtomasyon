using Hastane.Core.EntitiesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Core.DataAccessAbstract
{
    public interface IBaseRepo<T> where T : class 
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(List<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

        Task<List<T>> GetAll(); // dbcontext.admin.tolist demis olduk 
        //devamı icin ozellestirirsek where sartı ve select veririz

        Task<T> GetById(Guid id);

        Task<int> Save();
        
    }
}
