using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IAppionment<Type, Id2, Id3,RET>
    {


        RET AppionmentAssignAd(Type Token, Id2 id2, Id3 id3,RET obj);


    }


   public interface IDOctorAppionment<Type, RET,RET2,RET3>
{
    List<(RET,RET2,RET3)> doctorAppionment(Type id);
}




}
