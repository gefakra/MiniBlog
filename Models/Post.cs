namespace MiniBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public List<Comment> Comments { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
