using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IAuth<Ret>
    {
        Ret LogInAuthenticate(string username, string password);
    }
}
