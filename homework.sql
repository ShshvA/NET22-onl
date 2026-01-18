--CREATE database Lesson19Homework;

USE Lesson19Homework;

IF OBJECT_ID('Players', 'U') IS NOT NULL 
BEGIN
    DROP TABLE Players
END

IF OBJECT_ID('Teams', 'U') IS NOT NULL 
BEGIN
    DROP TABLE Teams
END

IF OBJECT_ID('TeamCoaches', 'U') IS NOT NULL 
BEGIN 
    DROP TABLE TeamCoaches
END

CREATE TABLE TeamCoaches
(
    Id INT IDENTITY(1,1),
    FirstName NVARCHAR(10) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Age INT CONSTRAINT DF_TeamCoaches_Age DEFAULT 18, 
    Experience NVARCHAR(128),
    CONSTRAINT PK_TeamCoaches_Id PRIMARY KEY (Id), 
    CONSTRAINT CK_TeamCoaches_FirstName CHECK(LEN(FirstName) >= 2 AND LEN(FirstName) <= 10),
    CONSTRAINT UQ_TeamCoaches_FirstName_LastName UNIQUE (FirstName, LastName)
);

CREATE TABLE Teams
(
    Id INT IDENTITY(1,1),
    TeamName NVARCHAR(50) NOT NULL,
    FoundingDate DATE, 
    GamesAmount INT,
    Winrate NUMERIC(5,2),
    IdCoach INT,
    CONSTRAINT PK_Teams_Id PRIMARY KEY (Id), 
    CONSTRAINT FK_Teams_IdCoach FOREIGN KEY (IdCoach) REFERENCES TeamCoaches(Id)
);

CREATE TABLE Players
(
    Id INT IDENTITY(1,1),
    FirstName NVARCHAR(10) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Age INT CONSTRAINT DF_Players_Age DEFAULT 18, 
    Experience NVARCHAR(128),
    Prizes NUMERIC(18,2),
    MatchesAmount INT,
    IdTeam INT,
    CONSTRAINT PK_Players_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Players_IdTeam FOREIGN KEY (IdTeam) REFERENCES Teams(Id),
    CONSTRAINT CK_Players_FirstName CHECK(LEN(FirstName) >= 2 AND LEN(FirstName) <= 10),
    CONSTRAINT UQ_Players_FirstName_LastName UNIQUE (FirstName, LastName)
);

INSERT INTO TeamCoaches (FirstName, LastName, Age, Experience )
    VALUES (N'Алексей', N'Иванов', 29, N'7 лет 3 месяца');

INSERT INTO TeamCoaches (FirstName, LastName, Age, Experience )
    VALUES (N'Дмитрий', N'Долтов', 32, N'6 лет 11 месяцев');

INSERT INTO Teams (TeamName, FoundingDate, GamesAmount, Winrate, IdCoach)
    VALUES (N'Нуга', '2023-10-27', 104, 60.23, 1);

INSERT INTO Teams (TeamName, FoundingDate, GamesAmount, Winrate, IdCoach)
    VALUES (N'Шоколад', '2021-04-19', 189, 55.42, 2);

INSERT INTO Teams (TeamName, FoundingDate, GamesAmount, Winrate, IdCoach)
    VALUES (N'Зефир', '2024-07-04', 76, 63.22, 2);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Алекс', N'Иванков', 22, N'4 года', 77211.23, 32, 1);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Антон', N'Марун', 21, N'3 года', 72721, 12, 1);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Давид', N'Жаков', 22, N'4 года', 41211.88, 44, 2);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Дмитрий', N'Нель', 23, N'5 лет', 41444.56, 41, 2);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Никита', N'Харущов', 24, N'7 лет', 64366.84, 26, 3);

INSERT INTO Players (FirstName, LastName, Age, Experience, Prizes, MatchesAmount, IdTeam )
    VALUES (N'Евгений', N'Жукович', 19, N'2 года', 22552.34, 24, 3);

SELECT * FROM TeamCoaches;
SELECT * FROM Teams;
SELECT * FROM Players;