Create database MovieRatings

Use MovieRatings

create table occupation(
	OccupattionID int primary key,
	Title varchar (500)
)

create table users
(
	--3::M::25::15::55117
	--UserID::Gender::Age::Occupation::Zip-code
	userID int primary key,
	Gender varchar(1),
	Age int,
	OccupattionID  int,
	ZipCode varchar(50),
	FOREIGN KEY (OccupattionID) REFERENCES occupation(OccupattionID)
) 

Create table movies
(
	MovieID int primary key,
	Title varchar(500),
	
)

Create table genres(
	GenresID int primary key,
	Title varchar(500),
)

create table movies_genres(
	mgID int primary key identity(1,1),
	MovieID int ,
	GenresID int
	FOREIGN KEY (MovieID) REFERENCES movies(MovieID),
	FOREIGN KEY (GenresID) REFERENCES genres(GenresID)

)

create table ratings(
	
	ID int primary key identity(1,1),
	userID int,
	movieID int,
	Rating float,
	[Timestamp] Timestamp ,
	FOREIGN KEY (UserID) REFERENCES users(userID),
	FOREIGN KEY (movieID) REFERENCES movies(MovieID) )

----- Insert data in Occupation

 Insert into occupation(OccupattionID, Title) Values( 0, 'other or not specified')
,(  1,  'academic/educator')
,(  2,  'artist')
,(  3,  'clerical/admin')
,(  4,  'college/grad student')
,(  5,  'customer service')
,(  6,  'doctor/health care')
,(  7,  'executive/managerial')
,(  8,  'farmer')
,(  9,  'homemaker')
,( 10,  'K-12 student')
,( 11,  'lawyer')
,( 12,  'programmer')
,( 13,  'retired')
,( 14,  'sales/marketing')
,( 15,  'scientist')
,( 16,  'self-employed')
,( 17,  'technician/engineer')
,( 18,  'tradesman/craftsman')
,( 19,  'unemployed')
,( 20,  'writer');


--- Insert Genres 
INSERT INTO genres VALUES (1,'Action'),
(2,'Adventure'),
(3,'Animation'),
(4,'Children''s'),
(5,'Comedy'),
(6,'Crime'),
(7,'Documentary'),
(8,'Drama'),
(9,'Fantasy'),
(10,'Film-Noir'),
(11,'Horror'),
(12,'Musical'),
(13,'Mystery'),
(14,'Romance'),
(15,'Sci-Fi'),
(16,'Thriller'),
(17,'War'),
(18,'Western');



-- Bulk Insert users
BULK INSERT [dbo].[users] FROM 'C:\Users\Madiha\Downloads\ml-1m\ml-1m\users.dat'
WITH (
   DATAFILETYPE = 'char',
   FIELDTERMINATOR = '::',
   ROWTERMINATOR = '0x0a'
)

-- Bulk Insert Movies

Create table movies_dumy
(
	MovieID int primary key,
	Title varchar(500),
	genres_Title varchar(500),
)

BULK INSERT movies_dumy FROM 'C:\Users\Madiha\Downloads\ml-1m\ml-1m\movies.dat'
WITH (
   DATAFILETYPE = 'char',
   FIELDTERMINATOR = '::',
   ROWTERMINATOR = '0x0a'
   
)
---- Insert into Movie
Insert into movies
select MovieID, Title from movies_dumy	

Insert into [dbo].[movies_genres]
Select MovieID, g.GenresID  from [dbo].[genres] g join 
(SELECT A.[MovieID], Split.a.value('.', 'VARCHAR(100)') AS mGenres  
 FROM  
 (  -- Split Genres '|'
     SELECT [MovieID],  
         CAST ('<M>' + REPLACE([genres_Title], '|', '</M><M>') + '</M>' AS XML) AS Data  
     FROM  [dbo].[movies_dumy]
 ) AS A CROSS APPLY Data.nodes ('/M') AS Split(a)) m
 on g.Title=m.mGenres

 Drop table [dbo].[movies_dumy]

 --- Insert into rating
BULK INSERT [dbo].[ratings] FROM 'E:\Semester 1\ADB\Orient DB\ml-20m\ratings.dat'
WITH (
   DATAFILETYPE = 'char',
   FIELDTERMINATOR = '::',
   ROWTERMINATOR = '0x0a'
   
)

