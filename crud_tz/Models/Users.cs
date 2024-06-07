namespace crud_tz.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime registration { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string libCode { get; set; }
        public ICollection<Book_issue> BookIssues { get; set; }
    }

}
