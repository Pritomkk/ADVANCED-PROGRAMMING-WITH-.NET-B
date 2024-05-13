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

        public static IRepo<Patient, int, Patient> PaitentData()
        {
            return new PatientRepo();
        }

        public static IAdminOp<int, string, Patient> Admin_Op_PaitentData()
        {
            return new PatientRepo();
        }


        public static IRepo<Appointment, int, Appointment> AppionmentData()
        {
            return new AppionmentRepo();
        }

        public static IAppionment<string,int,int ,Appointment> Admin_Op_AppionmentData()
        {
            return new AppionmentRepo();
        }

        public static IDOctorAppionment<int,doctor,Patient, Appointment> doc_AppionmentData()
        {
            return new AppionmentRepo();
        }
        public static IAdminOp<int,string,Appointment> dischargeAppionment()
        {
            return new AppionmentRepo();
        }


        public static IRepo<Inventory, int, Inventory> InventoryData()
        {
            return new InventoryRepo();
        }

        public static IAdminOp<int, string, Inventory> Admin_Op_InventoryData()
        {
            return new InventoryRepo();
        }
        public static IInventory<int,Inventory> Admin_Op_BillingData()
        {
            return new InventoryRepo();
        }


    }
}
