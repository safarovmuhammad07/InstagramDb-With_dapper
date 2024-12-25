namespace DoMain.Models;
using DoMain.Models;
public class Post
{
    public int PostID { get; set; }
    public int UserID { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public DateTime DatePublished { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    public PostStatus PostStatus { get; set; }
}