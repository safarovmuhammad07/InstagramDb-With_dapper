namespace DoMain.Models;

public class UserProfile
{
    public int UserProfileID { get; set; }
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int LocationID { get; set; }
    public char Gender { get; set; }
    public DateTime DOB { get; set; }
    public string Occupation { get; set; }
    public string About { get; set; }
    public DateTime DateUpdated { get; set; }
    public Location Location { get; set; }
}