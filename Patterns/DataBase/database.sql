create DATABASE [db_master]
GO

use [db_master]
GO


CREATE TABLE person (
	PersonId bigint IDENTITY(1,1) NOT NULL,
	Name varchar(500) ,
	Gender varchar(100) ,
	Age decimal(18,0) NULL,
	DocumentNumber varchar(100) ,
	Address varchar(500) ,
	Phone varchar(250) ,
	CONSTRAINT PK_person_AA2FFBE515886962 PRIMARY KEY (PersonId)
);
GO

CREATE TABLE client (
	ClientId bigint IDENTITY(1,1) NOT NULL,
	PersonId bigint NULL,
	Password varchar(250) ,
	Status bit NULL,
	CONSTRAINT PK_client_E67E1A2498AFB50F PRIMARY KEY (ClientId)
);


ALTER TABLE client ADD CONSTRAINT FK_clientPersonId_4AB81AF0 FOREIGN KEY (PersonId) REFERENCES person(PersonId);
GO

CREATE TABLE account (
	AccountNumber bigint NOT NULL,
	AccountType varchar(250) ,
	AccountInitialBalance float NULL,
	AccountStatus bit NULL,
	ClientId bigint NULL,
	CONSTRAINT account_PK PRIMARY KEY (AccountNumber),
	CONSTRAINT account_UN UNIQUE (AccountNumber)
);
CREATE UNIQUE NONCLUSTERED INDEX account_UN ON account (AccountNumber);

ALTER TABLE account ADD CONSTRAINT FK_accountClientI_4D94879B FOREIGN KEY (ClientId) REFERENCES client(ClientId);
GO   

CREATE TABLE movement (
	MovementId bigint IDENTITY(1,1) NOT NULL,
	MovementDate datetime NULL,
	MovementValue float NULL,
	MovementBalance float NULL,
	AccountNumber bigint NULL,
	MovementType varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

ALTER TABLE movement ADD CONSTRAINT movement_FK FOREIGN KEY (AccountNumber) REFERENCES account(AccountNumber);
GO   