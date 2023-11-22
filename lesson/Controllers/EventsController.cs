using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
       //private DataContext d;
        //public EventsController(DataContext da)
        //{
        //    d = da;
        //}

        private IDataContext _dataContext;

        public EventsController(IDataContext context)
        {
            _dataContext = context;
        }






        //static int count=0;    
        //static List<Event> events=new List<Event> { new Event { Id=count++,Title="First Event",Start= new DateTime(2023,09,07), End = new DateTime(2024, 09, 07) } };
        // GET: api/<EventsController>
        [HttpGet]
        //public IEnumerable<Event> Get()
        //{
        //    return _dataContext.events;
        //}
        public IActionResult Get()
        {
            return Ok(_dataContext.Events);
        }

        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ev1= _dataContext.Events.Find(e=>e.Id==id);
            if (ev1 == null)
            {
                return NotFound();
            }
            return Ok(ev1);
        }

        //POST api/<EventsController>
        [HttpPost]
        public IActionResult Post([FromBody] Event value)
        {
            _dataContext.Events.Add(new Event { Id =value.Id, Title = value.Title, Start = new DateTime(), End = value.End });

            return Ok(value);

        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            var eve = _dataContext.Events.Find(e => e.Id == id);
            eve.Title=value.Title;
            eve.Start=value.Start;
            eve.End=value.End;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            _dataContext.Events.Remove(eve);
            return Ok(id);
        }
    }
}
