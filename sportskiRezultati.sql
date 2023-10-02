GO;
CREATE TABLE country(
    countryID INT NOT NULL PRIMARY KEY,
    countryName NVARCHAR(100) NOT NULL,
)

CREATE TABLE league(
    leagueID INT NOT NULL PRIMARY KEY,
    leagueName NVARCHAR(50) NOT NULL,
    numberOfTeams INT NOT NULL,
)

CREATE TABLE match (
    matchID INT NOT NULL PRIMARY KEY,
    venue NVARCHAR(50) NOT NULL,
    matchDate DATE NOT NULL,
    matchTime TIME NOT NULL,
    results NVARCHAR(50) NOT NULL,
    homeTeamGoal INT NULL,
    awayTeamGoal INT NULL,
)

CREATE TABLE team(
    teamID INT PRIMARY KEY NOT NULL, 
    teamName NVARCHAR(50) NOT NULL,
    numberOfPlayers INT NOT NULL,
)

CREATE TABLE players(
    playerID INT PRIMARY KEY NOT NULL,
    jerseyNumber INT NOT NULL,
    playerName NVARCHAR(50) NOT NULL,
    playerSurname NVARCHAR(50) NOT NULL,
    birthDate DATE NOT NULL,
    age INT NOT NULL,
    position NVARCHAR(50) NOT NULL,
)

CREATE TABLE homeTeam(
    homeTeamID INT NOT NULL PRIMARY KEY,
)

CREATE TABLE awayTeam(
    awayTeamID INT NOT NULL PRIMARY KEY,
)

-- ALTER TABLE AWAYTEAM
ALTER TABLE awayTeam
ADD awayTeam int not null references team(teamID)

--  ALTER TABLE HOMETEAM
ALTER TABLE homeTeam
ADD homeTeam int not null references team(teamID)

-- ALTER TABLE LEAGUE
ALTER TABLE league
ADD countryID INT NOT NULL REFERENCES country(countryID)

-- ALTER TABLE TEAM
ALTER TABLE team
ADD countryID INT NOT NULL REFERENCES country(countryID)
ALTER TABLE team
ADD leagueID INT NOT NULL REFERENCES league(leagueID)
ALTER TABLE team
ADD matchID INT NOT NULL REFERENCES match(matchID)

-- ALTER TABLE PLAYERS
ALTER TABLE players
ADD teamID INT NOT NULL REFERENCES team(teamID)

SELECT * FROM league
SELECT * FROM team
SELECT * FROM match
SELECT * FROM players
SELECT * FROM country
SELECT * FROM awayTeam
SELECT * FROM homeTeam

-- INSERTS
INSERT INTO league(leagueID,leagueName,numberOfTeams,countryID) VALUES ('1','PREMIJER LIGA BIH',3,1)

INSERT INTO country(countryID, countryName) VALUES (1, 'Bosnia&Herzegovina')

INSERT INTO homeTeam(homeTeamID,homeTeam)VALUES(1,1)
INSERT INTO homeTeam(homeTeamID,homeTeam) VALUES(2,3)

INSERT into awayTeam(awayTeamID,awayteam)VALUES(1,2)

INSERT INTO match(matchID,venue,matchDate,matchTime,results,homeTeamGoal,awayTeamGoal) VALUES (1,'Stadion Kosevo','2022-12-25','15:30','2:1',2,1)
INSERT INTO match(matchID,venue,matchDate,matchTime,results,homeTeamGoal,awayTeamGoal) VALUES (2,'Stadion Grbavica','2022-12-27','17:30','2:0',2,0)

INSERT INTO team(teamID,teamName,numberOfPlayers,countryID,leagueID,matchID) VALUES ('1','FK ZELJEZNICAR','11',1,1,1)
INSERT INTO team(teamID,teamName,numberOfPlayers,countryID,leagueID,matchID) VALUES (2,'FK SARAJEVO','11',1,1,1)
INSERT INTO team(teamID,teamName,numberOfPlayers,countryID,leagueID,matchID) VALUES ('3','FK VELEZ','11','1',1,2)

INSERT INTO players(playerID,jerseyNumber,playerName,playerSurname,birthDate,age,position,teamID) VALUES (1,14,'Semir','Stilic','1987-10-08','35','Midfielder',1)
INSERT INTO players(playerID,jerseyNumber,playerName,playerSurname,birthDate,age,position,teamID) VALUES (2,2,'Musa','Muhammad','1996-10-31','26','Defender',2)
INSERT INTO players(playerID,jerseyNumber,playerName,playerSurname,birthDate,age,position,teamID) VALUES (3,93,'Slaviša','Bogdanovic','1993-11-10','29','Goalkeeper',3)

-- JOIN

-- players --> team
SELECT players.playerID, players.jerseyNumber, players.playerName, players.playerSurname, players.position, team.teamName
FROM players
INNER JOIN team ON players.teamID=team.teamID
-- team --> country--> league
SELECT team.teamID, team.teamName, country.countryName,  league.leagueName
FROM team
INNER JOIN country ON team.countryID=country.countryID
INNER JOIN league ON team.leagueID=league.leagueID
-- team--> match --> country --> league
SELECT match.matchID,country.countryName, league.leagueName,match.venue, match.matchDate,match.matchTime, match.results, match.homeTeamGoal, match.awayTeamGoal
FROM team
INNER JOIN match ON team.matchID=match.matchID
INNER JOIN country ON team.countryID=country.countryID
INNER JOIN league ON team.leagueID=league.leagueID

-- awayteam --> match --> team
SELECT match.matchid,team.teamID,team.teamName, awayTeam.awayTeam
FROM team
INNER JOIN match ON team.matchid=match.matchid
INNER JOIN awayTeam ON team.teamid=awayTeam.awayTeam

-- hometeam --> match --> team
SELECT match.matchid,team.teamID,team.teamName, homeTeam.homeTeam
FROM team
INNER JOIN match ON team.matchid=match.matchid
INNER JOIN homeTeam ON team.teamID=homeTeam.homeTeam

 -- SELECT QUERY
SELECT playerName, playerSurname
FROM players
ORDER BY playerSurname

SELECT playerSurname AS Surname
FROM players
WHERE playerSurname LIKE '%IC' 

SELECT COUNT(*) AS numberOfPlayers
FROM players

SELECT matchID, matchDate
FROM match
WHERE matchDate='2022-12-27'

SELECT playerName, playerSurname FROM players
WHERE playerID>0 AND playerSurname='Stilic' OR playerSurname='Bogdanovic'
ORDER BY playerSurname ASC

SELECT UPPER(playerName) AS upperName, LOWER(playerSurname) AS lowerSurname
FROM players

-- VIEW
CREATE VIEW vwMatch
AS
SELECT venue, matchDate
FROM match WHERE matchDate BETWEEN '2022-12-1' AND '2022-12-28'

SELECT * FROM vwMatch

CREATE VIEW showLeague
AS SELECT leagueName, numberOfTeams
FROM league

SELECT * FROM showLeague

-- Subqueries
SELECT playerName, playerSurname
FROM players
WHERE players.teamID = (SELECT teamID FROM team WHERE team.teamName='FK SARAJEVO')

-- Agregatne funkcije 
SELECT 
MAX(homeTeamGoal) AS 'HighestScoredGoal'
FROM match

SELECT 
MIN(numberofplayers) AS 'numberOfPlayers',
COUNT(teamName) AS 'numberOfTeams'
FROM team

-- SQL Stored Procedure
CREATE PROCEDURE selectPlayer @Id int
AS
SELECT playerName, playersurname FROM players
WHERE playerid= @Id
GO;
EXEC selectPlayer 3;

CREATE PROCEDURE chooseLeague @numberOfTeams int 
AS
SELECT leagueName FROM league
WHERE numberOfTeams = @numberOfTeams
GO;
EXEC chooseLeague 3;

CREATE PROCEDURE selectMatch @matchDate date
AS
SELECT matchId FROM match
WHERE matchdate = @matchDate;
GO;
EXEC selectMatch '2022-12-27';