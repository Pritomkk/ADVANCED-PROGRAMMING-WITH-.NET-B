using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class DoctorRepo :Repository, IRepo<doctor,int, doctor>,IAdminOp<int,string, doctor>
    {
        public doctor Create(doctor obj)
        {
            db.doctors.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.doctors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<doctor> Read()
        {
            return db.doctors.ToList();
        }

        public doctor Read(int id)
        {
            return db.doctors.Find(id);
        }

        public doctor Update(doctor obj)
        {
            var ex = Read(obj.DoctorId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
      
        public doctor UpdateByToken(int id ,doctor obj)
        {
            return null;
        }
        public doctor AddbyAdmin(string TokenKey, doctor updateDocr)
        {
            

           throw new NotImplementedException();
        }

        public doctor AddByAdminDep(int DepId, string TokenKey, doctor obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));

                if (adminEntity != null)
                {
                    obj.AdminId = adminEntity.AdminId;
                    obj.DepId = DepId;
                    db.doctors.Add(obj);
                    if (db.SaveChanges() > 0) return obj;
                    return null;
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


        public doctor updateOperation(int Depid, string TokeyKey, doctor obj)
        {
            throw new NotImplementedException();
        }
    }
}

