using DL.entities;
using BL;


namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService _appointmentService = new AppointmentService();
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointment GetAppointmentById(int id)
        {
            return _appointmentService.GetAppointmentById(id);
        }
        [HttpGet]
        public List<Appointment> GetAppointmentList()
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
