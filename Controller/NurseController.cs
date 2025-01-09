using dropOfMilk.entities;
using dropOfMilk.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dropOfMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        NurseService _nurseService=new NurseService();
        // GET api/<NourseController>
        [HttpGet]
        public List<Nurse> Get() 
        {
            return _nurseService.GetAllNurses();
        }
        // GET api/<NourseController>/5
        [HttpGet("{id}")]
        public Nurse Get(int id)
        {
            return _nurseService.GetNurseById(id);
        }

        // POST api/<NourseController>
        [HttpPost]
        public void Post([FromBody] Nurse value)
        {
            _nurseService.PostNurse(value);
        }

        // PUT api/<NourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nurse nurse)
        {
            _nurseService.PutNurse(id, nurse);
        }

        // DELETE api/<NourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _nurseService.DeleteNurse(id);
        }
    }
}
