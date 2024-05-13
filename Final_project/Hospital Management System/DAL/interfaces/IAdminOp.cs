using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IAdminOp<Type, ID, RET>
    {
       

            RET AddbyAdmin(ID id, RET obj);
             RET dischargebyAdmin(Type id , RET obj);
             RET AddByAdminDep(Type Tokenkey,ID id,RET obj);

             RET updateOperation(Type Tokenkey, ID id, RET obj);

    }
}
