--create database MeetUkraineToday


--use MeetUkraineToday


create table Users(
  UserID int NOT NULL,
  FirstName varchar (20) NOT NULL,
  LastName varchar (20) NOT NULL,
  UserLogin varchar (20) NOT NULL,
  UserPassword varchar (20) NOT NULL,
  Email varchar (20) NOT NULL,
  Constraint PK_Users_UserID Primary Key (UserID)
  );


create table Ratings (
  RatingID int NOT NULL, 
  UserID int NOT NULL,
  PlaceID int NOT NULL,
  Rate int NOT NULL, 
  Constraint PK_Ratings_RatingID Primary Key (RatingID),
  Constraint CK_Ratings_Rate Check (Rate in (0,1,2,3,4,5,6,7,8,9,10))
);


create table PlaceComments (

  PlaceCommentID int NOT NULL,
  UserID int NOT NULL,
  PlaceID int NOT NULL,
  Comment varchar (1000),
  Constraint PK_PlaceComments_PlaceCommentID Primary Key (PlaceCommentID)
);


create table Addresses
(
  AddressID int NOT NULL,
  City varchar (30) NOT NULL,
  Street varchar (30) NOT NULL,
  Building varchar (30) NOT NULL,
  Constraint PK_Addresses_AddressID Primary Key (AddressID)

);

create table Photos 
(
  PhotoID int NOT NULL,
  PhotoURL varchar NOT NULL,
  PlaceID int NOT NULL,
  PhotoDate date NOT NULL, 
  Constraint PK_Photos_PhotoID Primary Key (PhotoID)

);

create table Places (

  PlaceID int NOT NULL,
  PlaceName varchar (30) NOT NULL,   
  AddressID int NOT NULL, 
  RatingID int NOT NULL,
  PhotoID int NOT NULL,
  PlaceCommentID int NOT NULL,
  Longitude varchar (30) NOT NULL,
  Latitude varchar (30) NOT NULL,

  Constraint PK_Places_PlaceID Primary Key (PlaceID),
  CONSTRAINT FK_Places_to_Addresses Foreign key (AddressID) References Addresses(AddressID) 
  On Update Cascade 
  On Delete Cascade,
  CONSTRAINT FK_Places_to_Ratings Foreign key (RatingID) References Ratings(RatingID) 
  On Update Cascade 
  On Delete Cascade,
  CONSTRAINT FK_Places_to_Photos Foreign key (PhotoID) References Photos(PhotoID) 
  On Update Cascade 
  On Delete Cascade,
  CONSTRAINT FK_Places_to_PlaceComments Foreign key (PlaceCommentID) References PlaceComments(PlaceCommentID) 
  On Update Cascade 
  On Delete Cascade,  
);

create table SavedPlaces(
  SavedPlaceID int NOT NULL,
  UserID int NOT NULL,
  PlaceID int NOT NULL,
  UserStatus varchar (30) NOT NULL,
  Constraint PK_SavedPlaces_SavedPlace Primary Key (SavedPlaceID),
  Constraint CK_SavedPlaces_UserStatus Check (UserStatus in (0,1)),

  CONSTRAINT FK_SavedPlaces_to_Users Foreign key (UserID) References  Users(UserID) 
  On Update Cascade 
  On Delete Cascade,
  CONSTRAINT FK_SavedPlaces_to_Places Foreign key (PlaceID) References  Places(PlaceID) 
  On Update Cascade 
  On Delete Cascade,


  );



