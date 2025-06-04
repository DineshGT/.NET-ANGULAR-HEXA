-- 1. Create stored procedures for all the tables to insert data. 

-- Stored procedures in SQL
SELECT * FROM UserInfo;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;

--UserInfo table

CREATE PROCEDURE To_Insert_Values2
-- parameters
@EmailId VARCHAR(100),
@UserName VARCHAR(50),
@Role VARCHAR(20),
@Password VARCHAR(20)

AS
BEGIN
	INSERT INTO UserInfo(EmailId, UserName, Role, Password) VALUES (@EmailId, @UserName, @Role, @Password)
END;




-- SpeakerDetails table

CREATE PROCEDURE To_Insert_Values2
-- parameters

@SpeakerName VARCHAR(50)

AS
BEGIN
	INSERT INTO SpeakersDetails(SpeakerName) VALUES (@SpeakerName)
END;


-- EventDetails table

CREATE PROCEDURE InsertEventDetails
    @EventName VARCHAR(50),
    @EventCategory VARCHAR(50),
    @EventDate DATETIME,
    @Description VARCHAR(MAX),
    @Status VARCHAR(20)
AS
BEGIN
    INSERT INTO EventDetails (EventName, EventCategory, EventDate, Description, Status)
    VALUES (@EventName, @EventCategory, @EventDate, @Description, @Status);
END;


-- SessionInfo table

CREATE PROCEDURE InsertSessionInfo
    @EventId INT,
    @SessionTitle VARCHAR(50),
    @SpeakerId INT,
    @Description VARCHAR(MAX),
    @SessionStart DATETIME,
    @SessionEnd DATETIME,
    @SessionUrl VARCHAR(MAX)
AS
BEGIN
    INSERT INTO SessionInfo 
        (EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl)
    VALUES 
        (@EventId, @SessionTitle, @SpeakerId, @Description, @SessionStart, @SessionEnd, @SessionUrl);
END;



-- PaticipantEventDetails table

CREATE PROCEDURE InsertParticipantEventDetails
    @ParticipantEmailId VARCHAR(100),
    @EventId INT,
    @SessionId INT,
    @IsAttended BIT
AS
BEGIN
    INSERT INTO ParticipantEventDetails 
        (ParticipantEmailId, EventId, SessionId, IsAttended)
    VALUES 
        (@ParticipantEmailId, @EventId, @SessionId, @IsAttended);
END;



EXEC To_Insert_Values @EmailId = 'newone@gmail.com', @UserName = 'Ravi kumar', @Role = 'Admin', @Password = 'newone2';

EXEC To_Insert_Values2 @SpeakerName = 'Dinesh';

EXEC InsertEventDetails @EventName = 'AI Conference',@EventCategory = 'Technology',@EventDate = '2025-07-10',@Description = 'Latest AI trends',@Status = 'Active';

EXEC InsertSessionInfo @EventId = 1,@SessionTitle = 'Future of AI',@SpeakerId = 101,@Description = 'Deep learning advancements',@SessionStart = '2025-07-10 10:00',
    @SessionEnd = '2025-07-10 11:00',
    @SessionUrl = 'https://event.com/session1';

EXEC InsertParticipantEventDetails @ParticipantEmailId = 'user@example.com', @EventId = 1, @SessionId = 1, @IsAttended = 1;




--2. Create stored procedures for all the tables to delete data by using appropriate column in where clause. 

CREATE PROCEDURE DeleteEventDetails
    @EventId INT
AS
BEGIN
    DELETE FROM EventDetails
    WHERE EventId = @EventId;
END;

CREATE PROCEDURE DeleteSessionInfo
    @SessionId INT
AS
BEGIN
    DELETE FROM SessionInfo
    WHERE SessionId = @SessionId;
END;


CREATE PROCEDURE DeleteParticipantEventDetails
    @Id INT
AS
BEGIN
    DELETE FROM ParticipantEventDetails
    WHERE Id = @Id;
END;


CREATE PROCEDURE DeleteUserInfo
    @EmailId VARCHAR(100)
AS
BEGIN
    DELETE FROM UserInfo
    WHERE EmailId = @EmailId;
END;


CREATE PROCEDURE DeleteSpeakerDetails
    @SpeakerId INT
AS
BEGIN
    DELETE FROM SpeakersDetails
    WHERE SpeakerId = @SpeakerId;
END;



EXEC DeleteEventDetails @EventId = 1;

EXEC DeleteSessionInfo @SessionId = 1;

EXEC DeleteParticipantEventDetails @Id = 1;

EXEC DeleteUserInfo @EmailId = 'user1@example.com';

EXEC DeleteSpeakerDetails @SpeakerId = 1;


-- 3. Create stored procedures for all the tables to update existing data by using appropriate column in where clause. 

CREATE PROCEDURE UpdateSessionInfo
    @SessionId INT,
    @EventId INT,
    @SessionTitle VARCHAR(50),
    @SpeakerId INT,
    @Description VARCHAR(MAX),
    @SessionStart DATETIME,
    @SessionEnd DATETIME,
    @SessionUrl VARCHAR(MAX)
AS
BEGIN
    UPDATE SessionInfo
    SET 
        EventId = @EventId,
        SessionTitle = @SessionTitle,
        SpeakerId = @SpeakerId,
        Description = @Description,
        SessionStart = @SessionStart,
        SessionEnd = @SessionEnd,
        SessionUrl = @SessionUrl
    WHERE SessionId = @SessionId;
END;


CREATE PROCEDURE UpdateSpeakerDetails
    @SpeakerId INT,
    @SpeakerName VARCHAR(50)
AS
BEGIN
    UPDATE SpeakersDetails
    SET 
        SpeakerName = @SpeakerName
    WHERE SpeakerId = @SpeakerId;
END;


CREATE PROCEDURE UpdateUserInfo
    @EmailId VARCHAR(100),
    @UserName VARCHAR(50),
    @Role VARCHAR(20),
    @Password VARCHAR(20)
AS
BEGIN
    UPDATE UserInfo
    SET 
        UserName = @UserName,
        Role = @Role,
        Password = @Password
    WHERE EmailId = @EmailId;
END;


CREATE PROCEDURE UpdateParticipantEventDetails
    @Id INT,
    @ParticipantEmailId VARCHAR(100),
    @EventId INT,
    @SessionId INT,
    @IsAttended BIT
AS
BEGIN
    UPDATE ParticipantEventDetails
    SET 
        ParticipantEmailId = @ParticipantEmailId,
        EventId = @EventId,
        SessionId = @SessionId,
        IsAttended = @IsAttended
    WHERE Id = @Id;
END;


CREATE PROCEDURE UpdateSessionInfo
    @SessionId INT,
    @EventId INT,
    @SessionTitle VARCHAR(50),
    @SpeakerId INT,
    @Description VARCHAR(MAX),
    @SessionStart DATETIME,
    @SessionEnd DATETIME,
    @SessionUrl VARCHAR(MAX)
AS
BEGIN
    UPDATE SessionInfo
    SET 
        EventId = @EventId,
        SessionTitle = @SessionTitle,
        SpeakerId = @SpeakerId,
        Description = @Description,
        SessionStart = @SessionStart,
        SessionEnd = @SessionEnd,
        SessionUrl = @SessionUrl
    WHERE SessionId = @SessionId;
END;



-- 4. Create a view to show session details of the particular event.

CREATE VIEW View_SessionDetailsByEvent AS
SELECT
    SI.SessionId,
    SI.EventId,
    ED.EventName,
    SI.SessionTitle,
    SI.SpeakerId,
    SP.SpeakerName,
    SI.Description,
    SI.SessionStart,
    SI.SessionEnd,
    SI.SessionUrl
FROM SessionInfo SI
INNER JOIN EventDetails ED ON SI.EventId = ED.EventId
INNER JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId;

SELECT * FROM View_SessionDetailsByEvent
WHERE EventId = 1;




-- 5. Create a view to show speaker detail of particular session.

CREATE VIEW View_SpeakerDetailsBySession AS
SELECT
    SI.SessionId,
    SI.SessionTitle,
    SI.EventId,
    ED.EventName,
    SP.SpeakerId,
    SP.SpeakerName
FROM SessionInfo SI
INNER JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId
INNER JOIN EventDetails ED ON SI.EventId = ED.EventId;

SELECT * FROM View_SpeakerDetailsBySession
WHERE SessionId = 1;



--6. Create a view to show all details of an event like sessions, speaker details, participant details.

CREATE VIEW View_EventFullDetails AS
SELECT
    ED.EventId,
    ED.EventName,
    ED.EventCategory,
    ED.EventDate,
    ED.Description AS EventDescription,
    ED.Status AS EventStatus,

    SI.SessionId,
    SI.SessionTitle,
    SI.Description AS SessionDescription,
    SI.SessionStart,
    SI.SessionEnd,
    SI.SessionUrl,

    SP.SpeakerId,
    SP.SpeakerName,

    PED.Id AS ParticipantId,
    PED.ParticipantEmailId,
    PED.IsAttended

FROM EventDetails ED
LEFT JOIN SessionInfo SI ON ED.EventId = SI.EventId
LEFT JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId
LEFT JOIN ParticipantEventDetails PED ON SI.SessionId = PED.SessionId;


SELECT * FROM View_EventFullDetails
WHERE EventId = 1;



--7. Apply non-clustered indexes to tables by choosing appropriate columns.

CREATE NONCLUSTERED INDEX IDX_EventCategory ON EventDetails(EventCategory);
CREATE NONCLUSTERED INDEX IDX_Status ON EventDetails(Status);