namespace DoMain.Models;

public class PostComment
{
    public int PostCommentID { get; set; }
    public int PostID { get; set; }
    public int CommenterID { get; set; }
    public string Comment { get; set; }
    public DateTime DateCommented { get; set; }
}