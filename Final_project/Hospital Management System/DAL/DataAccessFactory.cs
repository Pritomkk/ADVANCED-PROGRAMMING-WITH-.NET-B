using DAL.interfaces;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<doctor,int, doctor> DoctorData()
        {
            return new DoctorRepo();
        }
        public static IAdminOp<int,string, doctor> DoctorDataOpByAdmin()
        {
            return new DoctorRepo();
        }
        public static IRepo<Admin,string, Admin> AdminData()
        {
            return new AdminRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new AdminRepo(); 
        }

        public static ILoginToken<int>LoginAdminId()
        {
            return new AdminRepo();
        }

        public static IRepo<Department,int,Department> DepartmentData()
        {
            return new DepartmentRepo();
        }

        public static IAdminOp<int,string, Department> CreateDepartmentByAdmin()
        {
            return new DepartmentRepo();
        }
    }
}
