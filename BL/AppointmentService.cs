using BL.InterfaceService;
using DL;
using DL.entities;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class AppointmentService:IAppointmentService
    {
        public readonly IDataContext _dataContext;
        
        public AppointmentService(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public List<Appointment> GetAllAppointment()
        {
            if (_dataContext.Appointments.Count() == 0)
            {
                throw new Exception("no Appointments");
            }
            return _dataContext.Appointments.Include(u => u.nurse).Include(u => u.baby).ToList();
        }
        public Appointment GetAppointmentById(int id)
        {
            if (_dataContext.Appointments.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            return _dataContext.Appointments.Where(x => x.Id == id).Include(u => u.nurse).Include(u => u.baby).FirstOrDefault();
        }
        public void PostAppointment(Appointment appointment)
        {
            if (appointment == null || appointment is not Appointment)
            {
                throw new Exception("no VALID appointment");
            }
            appointment.Id = 0;
            var existingBaby = _dataContext.Babies.Find(appointment.babyId);
            if (existingBaby == null) {
                throw new Exception("no exists Baby");
            }
            // חפש את האחות הקיימת
            var existingNurse = _dataContext.Nurses.Find(appointment.nurseId);
            if (existingNurse == null) {
                throw new Exception("no exists nurse");
            }

            // השתמש באובייקטים הקיימים
            appointment.baby = existingBaby;
            appointment.nurse = existingNurse;

            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
        }
        public void PutAppointment(int id, Appointment appointment)
        {

            if (_dataContext.Appointments.Count() == 0)
            {
                throw new Exception("no Appointments");
            }
            if (appointment == null || appointment is not Appointment)
            {
                throw new Exception("no VALID appointment");
            }
            _dataContext.Appointments.Remove(_dataContext.Appointments.ToList().Find(x => x.Id == id));
            var existingBaby = _dataContext.Babies.Find(appointment.babyId);
            if (existingBaby == null)
            {
                throw new Exception("no exists Baby");
            }
            // חפש את האחות הקיימת
            var existingNurse = _dataContext.Nurses.Find(appointment.nurseId);
            if (existingNurse == null)
            {
                throw new Exception("no exists nurse");
            }

            // השתמש באובייקטים הקיימים
            appointment.baby = existingBaby;
            appointment.nurse = existingNurse;
            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
        }
        public void DeleteAppointment(int id)
        {
            if (_dataContext.Appointments.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            _dataContext.Appointments.Remove(_dataContext.Appointments.ToList().Find(x => x.Id == id));
            _dataContext.SaveChanges();
        }
    }
}
