using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class Repository
    {
        internal H_M_Context db;
        internal Repository() {
        
        db=new H_M_Context();
        
        }
    }
}
