namespace crud_tz.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string code { get; set; }
        public int year { get; set; }
        public string publisher { get; set; }
        public string shelf { get; set; }
        public bool isIssued { get; set; }
        public int quantity { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? return_date { get; set; }
    }

}
