using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Entities.Abstract
{
    public interface IEmployee
    {
        string IdentityNumber { get; set; }
        decimal Salary { get; set; }
    }
}
