using DL.entities;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceService
{
    public interface IAppointmentService
    {
        public List<Appointment> GetAllAppointment();
        public Appointment GetAppointmentById(int id);
        public void PostAppointment(Appointment appointment);
        public void PutAppointment(int id, Appointment appointment);
        public void DeleteAppointment(int id);
    }
}
