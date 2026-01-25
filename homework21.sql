USE Lesson19Homework

ALTER TABLE Teams ADD Rate INT;
ALTER TABLE Players ADD Salaty NUMERIC(18,2);
-- Колонка Player.Age уже существует

CREATE OR ALTER TRIGGER Players_INSERT
ON Players
AFTER INSERT, UPDATE
AS
	UPDATE Players
	SET Salaty = CAST(Age AS NUMERIC(18,2)) / 10 * CAST((SELECT Teams.Rate FROM Teams WHERE Teams.Id = IdTeam) AS NUMERIC(18,2))
	WHERE Id IN (SELECT Id FROM inserted);


SELECT * FROM Teams;
UPDATE Teams SET Rate = 1234 WHERE Id = 1;
UPDATE Teams SET Rate = 2345 WHERE Id = 2;
UPDATE Teams SET Rate = 3456 WHERE Id = 3;

SELECT * FROM Teams;
SELECT * FROM Players;
INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Николай', N'Акульчик', 23, N'4 года', 42572.42, 34, 1);
SELECT * FROM Players;

UPDATE Players SET Age = Age + 1;

CREATE OR ALTER PROCEDURE TeamCostProc
	@IdTeam INT,
	@TeamCost NUMERIC(18,2) OUTPUT
AS
BEGIN
	SET @TeamCost = 
		(SELECT SUM(Salaty) AS TeamCost 
		FROM Players 
		WHERE IdTeam = @IdTeam);
END

SELECT * FROM Players;

DECLARE @Cost NUMERIC(18,2);
EXEC TeamCostProc 1, @Cost OUTPUT;
PRINT @Cost;

EXEC TeamCostProc 2, @Cost OUTPUT;
PRINT @Cost;

EXEC TeamCostProc 3, @Cost OUTPUT;
PRINT @Cost;


SELECT Id, FirstName, LastName, IdTeam from Players WHERE Id = 7;
BEGIN TRY
	BEGIN TRANSACTION;

	UPDATE Players SET IdTeam = NULL WHERE Id = 7;
	SELECT Id, FirstName, LastName, IdTeam from Players WHERE Id = 7;
	UPDATE Players SET IdTeam = 4 WHERE Id = 7;

	COMMIT TRANSACTION;
	PRINT 'All successfully updated';
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;
	PRINT 'Failed to update';	
END CATCH
SELECT Id, FirstName, LastName, IdTeam from Players WHERE Id = 7;