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
    internal class AppionmentRepo : Repository, IRepo<Appointment, int, Appointment>, IAppionment<string,int,int,Appointment>, IDOctorAppionment<int,doctor,Patient,Appointment>, IAdminOp<int, string, Appointment>
    {
        public Appointment AddbyAdmin(string id, Appointment obj)
        {
            throw new NotImplementedException();
        }

        public Appointment AddByAdminDep(int Tokenkey, string id, Appointment obj)
        {
            throw new NotImplementedException();
        }

        public Appointment AppionmentAssignAd(string TokenKey, int paitentId, int DoctorId, Appointment obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var adminEntity = db.Admins.FirstOrDefault(a => a.AdminId.Equals(tokenEntity.AdminId));
                var paitentEntity = db.Patients.FirstOrDefault(a => a.PatientId.Equals(paitentId));
                var docotrEntity = db.doctors.FirstOrDefault(a => a.DoctorId.Equals(DoctorId));

                if (adminEntity != null && paitentEntity != null && docotrEntity != null)
                {
                    obj.AdminId = adminEntity.AdminId;
                    obj.PatientId= paitentEntity.PatientId;
                    obj.DoctorId = docotrEntity.DoctorId;

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

                    db.appointments.Add(obj);
                    if (db.SaveChanges() > 0) return obj;
                    return null;
                }
                else
                {
                    throw new Exception("Please Provide Correct PaitendId and DoctorId");
                }
            }
            else
            {
                throw new Exception("Token not found.");
            }
        }


        public Appointment Create(Appointment obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.appointments.Remove(ex);
                return db.SaveChanges() > 0;
            }
            else
            {

                return false;
            }
        }

        public Appointment dischargebyAdmin(int paitentId, Appointment dischargeObj)
        {
            var cancelAppionment = db.appointments.FirstOrDefault(p => p.PatientId ==paitentId);

            if (cancelAppionment != null)
            {
                cancelAppionment.AppointmentStatus = dischargeObj.AppointmentStatus;
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(cancelAppionment, serviceProvider: null, items: null);
                bool isValid = Validator.TryValidateObject(cancelAppionment, context, validationResults, validateAllProperties: true);

                if (isValid)
                { 
                    db.SaveChanges();
                    return cancelAppionment;
                }
                else
                { 
                    var errorMessages = validationResults.Select(vr => vr.ErrorMessage);
                    throw new ValidationException($"Validation failed: {string.Join("; ", errorMessages)}");
                }
            }
            else
            {
                throw new InvalidOperationException("Appointment with the specified patient ID not found.");
            }

        }


        public List<(doctor, Patient, Appointment)> doctorAppionment(int doctorId)
        {
            var doctorAppointments = db.appointments
                .Where(a => a.DoctorId == doctorId)
                .GroupJoin(db.doctors,
                           appointment => appointment.DoctorId,
                           doctor => doctor.DoctorId,
                           (appointment, doctors) => new { Appointment = appointment, Doctors = doctors })
                .SelectMany(x => x.Doctors.DefaultIfEmpty(),
                            (x, doctor) => new { Appointment = x.Appointment, Doctor = doctor })
                .GroupJoin(db.Patients,
                           x => x.Appointment.PatientId,
                           patient => patient.PatientId,
                           (x, patients) => new { x.Appointment, x.Doctor, Patients = patients })
                .SelectMany(x => x.Patients.DefaultIfEmpty(),
                            (x, patient) => new { x.Appointment, x.Doctor, Patient = patient })
                .ToList()
                .Select(x => ((doctor)x.Doctor, (Patient)x.Patient, (Appointment)x.Appointment))
                .ToList();

            return doctorAppointments;
        }




        public List<Appointment> Read()
        {
            return db.appointments.ToList();
        }

        public Appointment Read(int AppionmentId)
        {
            return db.appointments.Find(AppionmentId);
        }

        public Appointment Update(Appointment obj)
        {
            throw new NotImplementedException();
        }

        public Appointment UpdateByToken(int id, Appointment obj)
        {
            throw new NotImplementedException();
        }

        public Appointment updateOperation(int Tokenkey, int id, Appointment obj)
        {
            throw new NotImplementedException();
        }

        public doctor updateOperation(int Tokenkey, string id, doctor obj)
        {
            throw new NotImplementedException();
        }

        public Appointment updateOperation(int Tokenkey, string id, Appointment obj)
        {
            throw new NotImplementedException();
        }
    }
}
