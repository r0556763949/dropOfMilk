using BL;
using BL.InterfaceService;
using DL.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dropOfMilk.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;   
        }
        //GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointment GetAppointmentById(int id)
        {
            return _appointmentService.GetAppointmentById(id);
        }
        [HttpGet]
        public IEnumerable<Appointment> GetAppointmentList()
        {
            return _appointmentService.GetAllAppointment();
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment app)
        {
            _appointmentService.PostAppointment(app);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Appointment app)
        {
            _appointmentService.PutAppointment(id, app);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _appointmentService.DeleteAppointment(id);
        }
    }
}
