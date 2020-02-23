USE [PeopleDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddNewPerson]  
(  
   @Name nvarchar (50),  
   @Address nvarchar (100),  
   @Phone int,  
   @Email nvarchar (50)  
)  
as  
begin  
   Insert into Person values(@Name,@Address,@Phone,@Email)  
End
GO

Create procedure [dbo].[DeletePerson]  
(  
   @Id int  
)  
as   
begin  
   Delete from Person where Id=@Id  
End
GO

Create Procedure [dbo].[GetPersonDetails]  
as  
begin  
   select * from Person
End
GO

Create procedure [dbo].[UpdatePersonDetails]  
(  
   @Id int,  
   @Name nvarchar (50),  
   @Address nvarchar (100),  
   @Phone int,  
   @Email nvarchar (50)  
)  
as  
begin  
   Update Person   
   set 
   Name=@Name,  
   Address=@Address,  
   Phone=@Phone,  
   Email=@Email  
   where Id=@Id  
End
GO


