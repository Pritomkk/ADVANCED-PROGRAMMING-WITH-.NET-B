using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class DepartmentRepo : Repository, IRepo<Department, int, Department>,IAdminOp<int,string,Department>
    {

        public Department AddbyAdmin(string TokenKey, Department obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));

                if (adminEntity != null)
                {
                   
                    Department objDepartment = new Department();
                    objDepartment.AdminId = adminEntity.AdminId;  
                    objDepartment.DepName = obj.DepName;  
                    objDepartment.Date = DateTime.Now; 

                    db.Departments.Add(objDepartment);
                    db.SaveChanges();
                    return obj;
                }
                else
                {
                   
                    throw new Exception("Admin associated with the token not found.");
                }
            }
            else
            {
              
                throw new Exception("Token not found.");
            }
        }

        public Department Create(Department obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> Read()
        {
            throw new NotImplementedException();
        }

        public Department Read(int id)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department obj)
        {
            throw new NotImplementedException();
        }

        public Department UpdateByToken(int id, Department obj)
        {
            throw new NotImplementedException();
        }

        public Department AddByAdminDep(int Depid,String TokeyKey,Department obj)
        {
            throw new NotImplementedException();
        }

        public Department updateOperation(int Depid, String TokeyKey, Department obj)
        {
            throw new NotImplementedException();
        }


    }
}
