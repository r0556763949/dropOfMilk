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
           return _dataContext.Appointments.Include(u => u.nurse).Include(u => u.baby).ToList();
        }
        public Appointment GetAppointmentById(int id)
        {
            return _dataContext.Appointments.Where(x => x.Id == id).Include(u => u.nurse).Include(u => u.baby).FirstOrDefault();
        }
        public void PostAppointment(Appointment appointment)
        {
            appointment.Id = 0;
            var existingBaby = _dataContext.Babies.Find(appointment.babyId);

            // חפש את האחות הקיימת
            var existingNurse = _dataContext.Nurses.Find(appointment.nurseId);
            // השתמש באובייקטים הקיימים
            appointment.baby = existingBaby;
            appointment.nurse = existingNurse;

            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
        }
        public void PutAppointment(int id, Appointment appointment)
        {
            _dataContext.Appointments.Remove(_dataContext.Appointments.ToList().Find(x => x.Id == id));
            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
        }
        public void DeleteAppointment(int id)
        {
            _dataContext.Appointments.Remove(_dataContext.Appointments.ToList().Find(x => x.Id == id));
            _dataContext.SaveChanges();
        }
    }
}
