namespace _14_Action_Filters.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}
