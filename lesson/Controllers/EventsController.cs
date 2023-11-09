using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
       private DataContext d;
        public EventsController(DataContext da)
        {
            d = da;
        }
       //static int count=0;    
        //static List<Event> events=new List<Event> { new Event { Id=count++,Title="First Event",Start= new DateTime(2023,09,07), End = new DateTime(2024, 09, 07) } };
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return d.events;
        }

        // GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            d.events.Add(new Event { Id =value.Id, Title = value.Title, Start = new DateTime(), End = value.End });
           return;

        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            var eve = d.events.Find(e => e.Id == id);
            eve.Title=value.Title;
            eve.Start=value.Start;
            eve.End=value.End;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = d.events.Find(e => e.Id == id);
            d.events.Remove(eve);
             
        }
    }
}
