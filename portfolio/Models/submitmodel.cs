namespace portfolio.Models
{
    public class submitmodel
    {

        public  int id { get; set; }
        public  String name { get; set; }
        public String email  { get; set; }
       
        public String message  { get; set; }

        public DateTime submissiondate { get; set; } = DateTime.UtcNow;





    }
}
