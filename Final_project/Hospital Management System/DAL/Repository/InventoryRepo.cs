using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class InventoryRepo : Repository, IRepo<Inventory, int, Inventory>, IAdminOp<int, string, Inventory>, IInventory<int, Inventory>
    {
        public Inventory AddbyAdmin(string Tokenkey, Inventory obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(Tokenkey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));

                if (adminEntity != null)
                {
                    obj.AdminId = adminEntity.AdminId;

                    var validationResults = new List<ValidationResult>();
                    var context = new ValidationContext(obj, serviceProvider: null, items: null);
                    bool isValid = Validator.TryValidateObject(obj, context, validationResults, validateAllProperties: true);

                    if (!isValid)
                    {
                        foreach (var validationResult in validationResults)
                        {
                            Console.WriteLine(validationResult.ErrorMessage);
                        }

                        throw new Exception("Validation failed. See validation errors for more details.");
                    }

                    db.Inventories.Add(obj);
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

        public Inventory AddByAdminDep(int Tokenkey, string id, Inventory obj)
        {
            throw new NotImplementedException();
        }

        public Inventory BillingInfo(int Invenid)
        {

            return db.Inventories.Find(Invenid);
        }

        public Inventory Create(Inventory obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Inventories.Remove(ex);
                return db.SaveChanges() > 0;
            }
            else
            {
               
                return false;
            }
        }

        public Inventory dischargebyAdmin(int id, Inventory obj)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> Read()
        {
            return db.Inventories.ToList();
        }

        public Inventory Read(int id)
        {
            var ex=db.Inventories.Find(id);
            if(ex != null)
            {
                return ex;
            }
            else
            {
                return null;
            }
        }

        public Inventory Update(Inventory obj)
        {
            throw new NotImplementedException();
        }

        public Inventory UpdateByToken(int id, Inventory obj)
        {
            throw new NotImplementedException();
        }

        public Inventory updateOperation(int Tokenkey, string id, Inventory obj)
        {
            throw new NotImplementedException();
        }
    }
}
