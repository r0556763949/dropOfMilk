using BL.InterfaceService;
using DL;
using DL.entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BL
{
    public class AppointmentService:IAppointmentService
    {
        public readonly IDataContext _dataContext;
        
        public AppointmentService(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        private (Nurse, Baby) GetExistingNurseAndBaby(int nurseId, int babyId)
        {
            var existingNurse = _dataContext.Nurses.Find(nurseId);
            if (existingNurse == null)
            {
                throw new KeyNotFoundException("Nurse does not exist");
            }

            var existingBaby = _dataContext.Babies.Find(babyId);
            if (existingBaby == null)
            {
                throw new KeyNotFoundException("Baby does not exist");
            }

            return (existingNurse, existingBaby); 
        }
        public IEnumerable<Appointment> GetAllAppointment()
        {
            if (_dataContext.Appointments.Count() == 0)
            {
                throw new Exception("no Appointments");
            }
            return _dataContext.Appointments.Include(u => u.Nurse).Include(u => u.Baby);
        }
        public Appointment GetAppointmentById(int id)
        {
            var appointment = _dataContext.Appointments.Include(u => u.Nurse).Include(u => u.Baby).FirstOrDefault(x => x.Id == id);
            if (appointment == null)
            {
                throw new Exception("no found id");
            }
            return appointment;
        }
        public void PostAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new Exception("no VALID appointment");
            }

            var (existingNurse, existingBaby) = GetExistingNurseAndBaby(appointment.NurseId, appointment.BabyId);

            // השתמש באובייקטים הקיימים
            appointment.Baby = existingBaby;
            appointment.Nurse = existingNurse;

            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
        }
        public void PutAppointment(int id, Appointment appointment)
        {
            var app = _dataContext.Appointments.FirstOrDefault(x => x.Id == id);

            if (appointment == null || app==null)
            {
                throw new Exception("no VALID appointment");
            }
            var (existingNurse, existingBaby) = GetExistingNurseAndBaby(appointment.NurseId, appointment.BabyId);

            // השתמש באובייקטים הקיימים
            app.Baby = existingBaby;
            app.Nurse = existingNurse;
            app.Date = appointment.Date;
            _dataContext.SaveChanges();
        }
        public void DeleteAppointment(int id)
        {
            var app = _dataContext.Appointments.FirstOrDefault(x => x.Id == id);
            if (app == null)
            {
                throw new Exception("no found id");
            }
            _dataContext.Appointments.Remove(app);
            _dataContext.SaveChanges();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
