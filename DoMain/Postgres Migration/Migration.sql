CREATE TABLE Locations (
                           LocationID SERIAL PRIMARY KEY,
                           City VARCHAR(45),
                           State VARCHAR(45),
                           ZipCode VARCHAR(45),
                           Country VARCHAR(45)
);

CREATE TABLE Users (
                       UserID SERIAL PRIMARY KEY,
                       UserName VARCHAR(45),
                       Email VARCHAR(45),
                       Password VARCHAR(45),
                       PasswordSalt VARCHAR(45),
                       DateRegistered TIMESTAMP,
                       UserType VARCHAR(45),
                       AccountStatus VARCHAR(45)
);

CREATE TABLE UserSettings (
                              UserID INT PRIMARY KEY REFERENCES Users(UserID),
                              NotificationsNewsletter VARCHAR(3) CHECK (NotificationsNewsletter IN ('on', 'off')),
                              NotificationsFollowers VARCHAR(3) CHECK (NotificationsFollowers IN ('on', 'off')),
                              NotificationsComm VARCHAR(3) CHECK (NotificationsComm IN ('on', 'off')),
                              NotificationsMessages VARCHAR(3) CHECK (NotificationsMessages IN ('on', 'off'))
);

CREATE TABLE ExternalAccounts (
                                  UserID INT PRIMARY KEY REFERENCES Users(UserID),
                                  FacebookEmail VARCHAR(45),
                                  TwitterUsername VARCHAR(45)
);

CREATE TABLE UserProfiles (
                              UserProfileID SERIAL PRIMARY KEY,
                              UserID INT NOT NULL REFERENCES Users(UserID),
                              FirstName VARCHAR(45),
                              LastName VARCHAR(45),
                              LocationID INT REFERENCES Locations(LocationID),
                              Gender CHAR(1),
                              DOB DATE,
                              Occupation VARCHAR(45),
                              About TEXT,
                              DateUpdated TIMESTAMP
);

CREATE TABLE FollowingRelationships (
                                        FollowingRelationshipID SERIAL PRIMARY KEY,
                                        UserID INT NOT NULL REFERENCES Users(UserID),
                                        FollowingID INT NOT NULL REFERENCES Users(UserID),
                                        DateFollowed TIMESTAMP
);

CREATE TABLE Posts (
                       PostID SERIAL PRIMARY KEY,
                       UserID INT NOT NULL REFERENCES Users(UserID),
                       Title VARCHAR(45),
                       Content TEXT,
                       Status VARCHAR(45),
                       DatePublished TIMESTAMP
);

CREATE TABLE PostComments (
                              PostCommentID SERIAL PRIMARY KEY,
                              PostID INT NOT NULL REFERENCES Posts(PostID),
                              CommenterID INT NOT NULL REFERENCES Users(UserID),
                              Comment TEXT,
                              DateCommented TIMESTAMP
);

CREATE TABLE PostFavorites (
                               PostFavoriteID SERIAL PRIMARY KEY,
                               PostID INT NOT NULL REFERENCES Posts(PostID),
                               UserID INT NOT NULL REFERENCES Users(UserID),
                               DateFavorited TIMESTAMP
);

CREATE TABLE PostStats (
                           PostID INT PRIMARY KEY REFERENCES Posts(PostID),
                           ViewCount INT
);

CREATE TABLE Tags (
                      TagID SERIAL PRIMARY KEY,
                      Tag VARCHAR(45)
);

CREATE TABLE PostTags (
                          PostTagID SERIAL PRIMARY KEY,
                          PostID INT NOT NULL REFERENCES Posts(PostID),
                          TagID INT NOT NULL REFERENCES Tags(TagID)
);

CREATE TABLE Categories (
                            CategoryID SERIAL PRIMARY KEY,
                            Category VARCHAR(45)
);

CREATE TABLE PostCategories (
                                PostCategoryID SERIAL PRIMARY KEY,
                                PostID INT NOT NULL REFERENCES Posts(PostID),
                                CategoryID INT NOT NULL REFERENCES Categories(CategoryID)
);

501250724