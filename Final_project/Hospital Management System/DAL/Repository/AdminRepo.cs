using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class AdminRepo : Repository, IRepo<Admin, string, Admin>, IAuth<bool>, ILoginToken<int>
    {
        public bool LogInAuthenticate(string email, string password)
        {
           
            var data = db.Admins.FirstOrDefault(u => u.email.Equals(email) &&
            u.password.Equals(password) );
            if (data != null) return true;
            return false;
        }

        public Admin Create(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }


        public bool Delete(string TokenKey)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));
                var deleteTokenEntity = db.Tokens.FirstOrDefault(a => a.Id.Equals(tokenEntity.Id));

                if (adminEntity != null)
                {
                    db.Admins.Remove(adminEntity);
                    db.Tokens.Remove(deleteTokenEntity);
                    db.SaveChanges();
                    return true;
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

        public List<Admin> Read()
        {
            return db.Admins.ToList();
        }

        public Admin Read(string TokenKey)
        {
            try
            {
                var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

                if (tokenEntity != null)
                {
                    var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));

                    return adminEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
               
                Console.WriteLine("An error occurred while executing the command: " + ex.Message);
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);

                // Handle the exception gracefully, return null or throw a custom exception
                return null;
            }
        }



        public Admin Update(Admin obj)
        {

            var ex = Read(obj.email);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public Admin UpdateByToken(string TokenKey, Admin updatedAdmin)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));

                if (adminEntity != null)
                {
                   
                    adminEntity.email = updatedAdmin.email;
                    adminEntity.name = updatedAdmin.name;
                    adminEntity.password = updatedAdmin.password;
                    adminEntity.date=updatedAdmin.phone;
                    adminEntity.phone = updatedAdmin.phone;
                    adminEntity.gender = updatedAdmin.gender;


                    db.SaveChanges();

                    // Update the email in the token entity
                    tokenEntity.email = updatedAdmin.email;
                    db.SaveChanges();

                    return updatedAdmin;
                }
                else
                {
                    // Admin not found with the AdminId associated with the token
                    throw new Exception("Admin with the AdminId associated with the token not found.");
                }
            }
            else
            {
                // Token not found with the provided TokenKey
                throw new Exception("Token not found.");
            }
        }


        public int GetAdminIdByEmail(string email)
        {
            var Adminemail = db.Admins.FirstOrDefault(t => t.email.Equals(email));

            if (Adminemail != null)
            {

                return Adminemail.AdminId;
            }

            return -1;

        }
    }
}
