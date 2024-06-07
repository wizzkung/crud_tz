namespace crud_tz.Models
{
    public class Returned_Books
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public int user_id { get; set; }
        public DateTime date_issued { get; set; }
        public DateTime due_date { get; set; }
    }
}
