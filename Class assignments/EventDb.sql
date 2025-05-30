CREATE DATABASE EventDb;

USE EventDb;

CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);



CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(MAX) NULL,
    Status VARCHAR(20) NOT NULL CHECK (Status IN ('Active', 'In-Active'))
);

CREATE TABLE SpeakersDetails 
(
    SpeakerId INT PRIMARY KEY IDENTITY(1,1),
    SpeakerName VARCHAR(50) NOT NULL CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);



CREATE TABLE SessionInfo 
(
    SessionId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(MAX) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(MAX),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);



CREATE TABLE ParticipantEventDetails
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL CHECK (IsAttended IN (0, 1)),
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);