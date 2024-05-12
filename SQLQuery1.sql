CREATE TABLE Accounts (
    Email NVARCHAR(255) PRIMARY KEY,
    PasswordHash CHAR(40), -- Password will be hashed with SHA1
    ID NVARCHAR(255) UNIQUE,
    Status NVARCHAR(20) ,
    Type NVARCHAR(20) 
);
CREATE TABLE Users (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DOB DATE,
    Gender NVARCHAR(10),
    Phone NVARCHAR(20),
    Email NVARCHAR(255),
    Rank NVARCHAR(5), -- Assuming ranks are single characters like A/B/C/D/E
    PrivateAcc BIT, -- true/false
    Matches INT,
    WinRate DECIMAL(5, 2), -- Store win rate as a percentage with two decimal places
    Picture IMAGE,
    Bio NVARCHAR(255),
    Favorite NVARCHAR(50),
	Flag NVARCHAR(MAX) -- Assuming notes or reports can be of varying length
);
CREATE TABLE FollowStatus (
    UserID INT,
    TargetID INT,
    Status NVARCHAR(20), -- Can be 'Following', 'Unfollowed', etc.
    PRIMARY KEY (UserID, TargetID)
);
CREATE TABLE Business (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DOB DATE,
    Gender NVARCHAR(10),
    Phone NVARCHAR(20),
    Email NVARCHAR(255),
    Picture IMAGE, -- Adding an image field
    MID INT,
    GroupID NVARCHAR(10),
    Flag NVARCHAR(MAX)
);
CREATE TABLE MatchResults (
    MatchID  NVARCHAR(255) PRIMARY KEY,
    UserID1 INT,
    UserID2 INT,
    WinnerID INT,
    Score NVARCHAR(50),
    Player1Name NVARCHAR(255),
    Player2Name NVARCHAR(255),
    WinnerName NVARCHAR(255),
    Facility NVARCHAR(255),
    MatchDate DATE,
);
CREATE TABLE Facility (
    FacilityID INT PRIMARY KEY,
    FacilityName NVARCHAR(255),
    Location NVARCHAR(255),
    Capacity NVARCHAR(50), -- Change capacity to NVARCHAR
	Image IMAGE,
    Description NVARCHAR(MAX) -- Add Description
);
CREATE TABLE Tables (
    TableID INT PRIMARY KEY,
    FacilityID INT,
    TableNumber INT, -- Table Name in the facility
    IsPublic BIT, -- Indicates whether the table is public or private
	PrivateKey NVARCHAR(8),
    Location NVARCHAR(255),
    Date DATE,
    Time TIME,
    GameType NVARCHAR(50),
    PlayerLimit INT,
    GameRules NVARCHAR(MAX), -- Specific game rules
    FOREIGN KEY (FacilityID) REFERENCES Facility(FacilityID)
);
CREATE TABLE Tournament (
    TournamentID NVARCHAR(40) PRIMARY KEY,
    TournamentName NVARCHAR(255),
    Organizer NVARCHAR(255),
    Location NVARCHAR(255),
	Image IMAGE,
    DateStart DATE,
    DateEnd DATE,
    Description NVARCHAR(MAX),
    NumberOfPlayers INT,
	PlayersNow INT, 
    WinnerID INT,
    WinnerName NVARCHAR(255)
);
CREATE TABLE TournamentTables (
    TournamentID NVARCHAR(40),
    TableID INT
);



