using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;


namespace lesson
{
    public class DataContext:IDataContext
    {
        public List<Event> Events { get; set; }

        //public List<Event> events { get; set; }
        //public static int Count = 0;
        //public DataContext()
        //{


        //    events = new List<Event>();
        //    events.Add(new Event() { Id= Count++});
        //    //events.Add(new Event
        //    //{
        //    //    Id = count++,
        //    //    Title = value.Title,
        //    //    Start = new DateTime(),
        //    //    End = value.End
        //    //});
        //}
       
        public DataContext()
        {
            
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Events = csv.GetRecords<Event>().ToList();
            }
        }



    }
}
