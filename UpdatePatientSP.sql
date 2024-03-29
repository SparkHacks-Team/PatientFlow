USE [PatientFlow]
GO
/****** Object:  StoredProcedure [dbo].[UpdatePatient]    Script Date: 2/10/2024 11:31:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[UpdatePatient]
@Patient_ID int,
@FirstName varchar(50),
@LastName varchar(50),
@Gender varchar(50),
@Age int

as 
begin 
	set nocount on;
	update PatientInfo
	set FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Age = @Age where Patient_ID = @Patient_ID

end 