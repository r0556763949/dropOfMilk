using dropOfMilk.entities;
using dropOfMilk.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dropOfMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private BabyService _babyService = new BabyService();
        [HttpGet]
        public List<Baby> Get()
        {
            return _babyService.GetAllBaby();
        }
        [HttpGet("{id}")]
        public Baby Get(int id)
        {
            return _babyService.GetBabyById(id);
        }
        // POST api/<BabyController>
        public void Post([FromBody] Baby baby)
        {
             _babyService.PostBaby(baby);
        }

        // PUT api/<BabyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Baby baby)
        {
            _babyService.PutById(id, baby);
        }

        // DELETE api/<BabyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _babyService.DeleteById(id);
        }
    }
}
