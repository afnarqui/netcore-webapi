SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='travels')
		drop database travels
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE travels
  ON PRIMARY (NAME = N''travels'', FILENAME = N''' + @device_directory + N'travels.mdf'')
  LOG ON (NAME = N''travels_log'',  FILENAME = N''' + @device_directory + N'travels.ldf'')')
go

if CAST(SERVERPROPERTY('ProductMajorVersion') AS INT)<12 
BEGIN
  exec sp_dboption 'travels','trunc. log on chkpt.','true'
  exec sp_dboption 'travels','select into/bulkcopy','true'
END
ELSE ALTER DATABASE [travels] SET RECOVERY SIMPLE WITH NO_WAIT
GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO
use "travels"
go
if exists (select * from sysobjects where id = object_id('dbo.Persons') and sysstat & 0xf = 3)
	drop table "dbo"."Persons"
GO
CREATE TABLE "Persons" (
	"personsId" "int" IDENTITY (1, 1) NOT NULL ,
	"identity"  "int" NOT NULL ,
	"password" nvarchar (50) NULL,
	CONSTRAINT "PK_Persons" PRIMARY KEY  CLUSTERED 
	(
		"PersonsId"
	))
GO
if exists (select * from sysobjects where id = object_id('dbo.Works') and sysstat & 0xf = 3)
	drop table "dbo"."Works"
GO
CREATE TABLE "Works" (
	"worksId" "int" IDENTITY (1, 1) NOT NULL ,
	"personsId" "int" NOT NULL ,
	"numberDays" "int" NOT NULL ,
	"numberItemsForDays" "int" NOT NULL ,
	"numberOfWeightForElement" varchar(max)
	CONSTRAINT "PK_Works" PRIMARY KEY  CLUSTERED 
	(
		"worksId"
	),
    CONSTRAINT FK_Works_Persons FOREIGN KEY (personsId)     
        REFERENCES Persons (personsId)     
        ON DELETE CASCADE    
        ON UPDATE CASCADE    
    )
GO
