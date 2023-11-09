namespace lesson
{
    public class DataContext
    {
       
        public List<Event> events { get; set; }
        public static int Count = 0;
        public DataContext()
        {

            
            events = new List<Event>();
            events.Add(new Event() { Id= Count++});
            //events.Add(new Event
            //{
            //    Id = count++,
            //    Title = value.Title,
            //    Start = new DateTime(),
            //    End = value.End
            //});
        }

       
    }
}
