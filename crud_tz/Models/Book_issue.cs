namespace crud_tz.Models
{
    public class Book_issue
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public Book book { get; set; }
        public int user_id { get; set; }
        public User user { get; set; }
        public int quantity { get; set; }
        public DateTime issue_date { get; set; }
        public DateTime return_date { get; set; }

    }
}
