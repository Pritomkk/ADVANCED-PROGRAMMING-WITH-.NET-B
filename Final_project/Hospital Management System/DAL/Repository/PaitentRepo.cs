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
    internal class PatientRepo : Repository, IRepo<Patient, int, Patient>, IAdminOp<int, string, Patient>
    {
        public Patient Create(Patient obj)
        {
            db.Patients.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Patients.Remove(ex);
                return db.SaveChanges() > 0;
            }
            else
            {

                return false;
            }
        }
        public List<Patient> Read()
        {
            return db.Patients.ToList();
        }

        public Patient Read(int id)
        {
            return db.Patients.Find(id);
        }

        public Patient Update(Patient obj)
        {
            var ex = Read(obj.PatientId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Patient UpdateByToken(int id, Patient obj)
        {
            return null;
        }


        public Patient AddbyAdmin(string TokenKey, Patient obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

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

                    db.Patients.Add(obj);
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

        public Patient AddByAdminDep(int DepId, string TokenKey, Patient obj)
        {
            throw new NotImplementedException();
        }

        public Patient updateOperation(int Depid, string TokeyKey, Patient obj)
        {
            throw new NotImplementedException();
        }

        public Patient dischargebyAdmin(int dischargeid, Patient dischargeobj)
        {
            var patient = db.Patients.FirstOrDefault(p => p.PatientId == dischargeid);

            if (patient != null)
            {
  
                patient.Status = dischargeobj.Status;
                patient.DischargeDate = dischargeobj.DischargeDate;

                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(patient, serviceProvider: null, items: null);
                bool isValid = Validator.TryValidateObject(patient, context, validationResults, validateAllProperties: true);

                if (!isValid)
                {
                    // If validation fails, extract error messages and throw an exception
                    var errorMessages = validationResults.Select(vr => vr.ErrorMessage);
                    throw new Exception($"Validation failed: {string.Join("; ", errorMessages)}");
                }
                db.SaveChanges();

                return patient;
            }
            else
            {
                throw new Exception("Patient with the specified ID not found.");
            }
        }

    }
}
