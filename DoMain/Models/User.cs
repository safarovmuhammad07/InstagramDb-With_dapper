﻿namespace DoMain.Models;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime DateRegistered { get; set; }
    public string UserType { get; set; }
    public string AccountStatus { get; set; }
    public UserSetting UserSettings { get; set; }
    public ExternalAccount ExternalAccount { get; set; }
    public ICollection<UserProfile> UserProfiles { get; set; }
    public ICollection<FollowingRelation> FollowingRelationships { get; set; }

}