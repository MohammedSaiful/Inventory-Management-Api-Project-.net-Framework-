using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthen<RET>
    {
        RET GetAuthen(string username, string password);
    }
}
