﻿using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if (ex != null)
            {
                db.doctors.Remove(ex);
                return db.SaveChanges() > 0;
            }
            else
            {

                return false;
            }
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

                    var validationResults = new List<ValidationResult>();
                    var context = new ValidationContext(obj, serviceProvider: null, items: null);
                    bool isValid = Validator.TryValidateObject(obj, context, validationResults, validateAllProperties: true);

                    if (!isValid)
                    {
                        // Log or handle validation errors
                        foreach (var validationResult in validationResults)
                        {
                            Console.WriteLine(validationResult.ErrorMessage);
                        }

                        throw new Exception("Validation failed. See validation errors for more details.");
                    }

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

        public doctor dischargebyAdmin(int Type, doctor obj)
        {
            throw new NotImplementedException();
        }
    }
}

