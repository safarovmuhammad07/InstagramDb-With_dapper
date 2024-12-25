namespace DoMain.Models;

public class FollowingRelation
{
    public int FollowingRelationshipID { get; set; }
    public int UserID { get; set; }
    public int FollowingID { get; set; }
    public DateTime DateFollowed { get; set; }
}