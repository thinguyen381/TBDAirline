alter table [Flight] alter column [FlightID] int not null

alter table Flight add primary key (FlightID)

ALTER TABLE Flight
   ADD CONSTRAINT FK_Flight_Airport FOREIGN KEY (FromID)
      REFERENCES Airport (AirportID)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;

ALTER TABLE Flight
   ADD CONSTRAINT FK_FlightToID_Airport FOREIGN KEY (ToID)
      REFERENCES Airport (AirportID)

;

ALTER TABLE Reservation
   ADD CONSTRAINT FK_DepartFlightID_Reservation FOREIGN KEY (DepartFlightID)
      REFERENCES Flight (FlightID)

;

ALTER TABLE Reservation
   ADD CONSTRAINT FK_ReturnFlightID_Reservation FOREIGN KEY (ReturnFlightID)
      REFERENCES Flight (FlightID)

;

Create table Account (
	AccountID int IDENTITY (1,1) not null
	, UserName varchar(50) not null
	, [Password] varchar(50) not null
	, IsAdmin BIT not null
	, constraint PK_Account primary key clustered (AccountID)
);

Create table Passenger (
	PassengerID int IDENTITY (1,1) not null
	, PassengerName varchar(50) not null
	, Email varchar(50) not null
	, PhoneNumber varchar(15) null
	, constraint PK_Passenger primary key clustered (PassengerID)
);
