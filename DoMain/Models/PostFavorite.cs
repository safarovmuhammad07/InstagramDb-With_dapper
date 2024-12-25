namespace DoMain.Models;

public class PostFavorite
{
    public int PostFavoriteID { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }
    public DateTime DateFavorited { get; set; }

}