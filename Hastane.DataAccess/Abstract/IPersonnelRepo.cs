using Hastane.Core.DataAccessAbstract;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.Abstract
{
    public interface IPersonnelRepo:IBaseRepo<Personnel>
    {
        Task<Personnel> GetByEmail(string email, string password);
    }
}
