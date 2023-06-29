CREATE DATABASE SchoolDatabase2
GO

USE SchoolDatabase2
GO

CREATE TABLE [User]
(
	[ID] INT CONSTRAINT PK_User PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(255) NOT NULL,
	[Username] VARCHAR(255) NOT NULL UNIQUE,
	[Password] VARCHAR(255) NOT NULL,
	[Role] VARCHAR(255) NOT NULL
)
GO

CREATE TABLE [Admin]
(
	[ID] INT CONSTRAINT PK_Admin PRIMARY KEY IDENTITY(1,1),
	[Age] INT NOT NULL,
	[UserID] INT NOT NULL CONSTRAINT FK_User_Admin FOREIGN KEY REFERENCES [User](ID) ON DELETE CASCADE
)
GO

CREATE TABLE [Student]
(
	[ID] INT CONSTRAINT PK_Student PRIMARY KEY IDENTITY(1,1),
	[RollNo] INT NOT NULL,
	[UserID] INT NOT NULL CONSTRAINT FK_User_Student FOREIGN KEY REFERENCES [User](ID) ON DELETE CASCADE,
	[English] DECIMAL(4,1) NOT NULL,
	[Hindi] DECIMAL(4,1) NOT NULL,
	[Science] DECIMAL(4,1) NOT NULL
)
GO

CREATE PROCEDURE usp_crudUser
(
	@Option VARCHAR(255),
	@ID INT = NULL,
	@Name VARCHAR(255) = NULL,
	@Username VARCHAR(255) = NULL,
	@Password VARCHAR(255) = NULL,
	@Role VARCHAR(255) = NULL
)
AS
BEGIN
	IF(@Option = 'InsertUser')
	BEGIN
		INSERT INTO [dbo].[User] ([Name], [Username], [Password], [Role]) VALUES (@Name, @Username, @Password, @Role)
	END
	IF(@Option = 'GetUserByID')
	BEGIN
		SELECT * FROM [dbo].[User] WHERE [ID] = @ID
	END
	IF(@Option = 'GetUserByUsername')
	BEGIN
		SELECT * FROM [dbo].[User] WHERE [Username] = @Username
	END
	IF(@Option = 'GetUserByUsernameAndPassword')
	BEGIN
		SELECT * FROM [dbo].[User] WHERE [Username] = @Username AND [Password] = @Password
	END
	IF(@Option = 'GetAllUsers')
	BEGIN
		SELECT * FROM [dbo].[User]
	END
	IF(@Option = 'UpdateUserByID')
	BEGIN
		UPDATE [dbo].[User] SET [Name] = @Name, [Username] = @Username, [Password] = @Password, [Role] = @Role WHERE [ID] = @ID
	END
	IF(@Option = 'DeleteUserByID')
	BEGIN
		DELETE FROM [dbo].[User] WHERE [ID] = @ID
	END
END
GO

CREATE PROCEDURE usp_crudStudent
(
	@Option VARCHAR(255),
	@ID INT = NULL,
	@RollNo INT = NULL,
	@UserID INT = NULL,
	@English DECIMAL(4,1) = NULL,
	@Hindi DECIMAL(4,1) = NULL,
	@Science DECIMAL(4,1) = NULL
)
AS
BEGIN
	IF(@Option = 'InsertStudent')
	BEGIN
		INSERT INTO [dbo].[Student] ([RollNo], [UserID], [English], [Hindi], [Science]) VALUES (@RollNo, @UserID, @English, @Hindi, @Science)
	END
	IF(@Option = 'GetStudentByID')
	BEGIN
		SELECT * FROM [dbo].[Student] WHERE [ID] = @ID
	END
	IF(@Option = 'GetStudentByUserID')
	BEGIN
		SELECT * FROM [dbo].[Student] WHERE [UserID] = @UserID
	END
	IF(@Option = 'GetAllStudents')
	BEGIN
		SELECT * FROM [dbo].[Student]
	END
	IF(@Option = 'UpdateStudentByID')
	BEGIN
		UPDATE [dbo].[Student] SET [RollNo] = @RollNo, [UserID] = @UserID, [English] = @English, [Hindi] = @Hindi, [Science] = @Science WHERE [ID] = @ID
	END
	IF(@Option = 'DeleteStudentByID')
	BEGIN
		DELETE FROM [dbo].[User] WHERE [ID] = @ID
	END
END
GO

CREATE PROCEDURE usp_crudAdmin
(
	@Option VARCHAR(255),
	@ID INT = NULL,
	@Age INT = NULL,
	@UserID INT = NULL
)
AS
BEGIN
	IF(@Option = 'InsertAdmin')
	BEGIN
		INSERT INTO [dbo].[Admin] ([Age], [UserID]) VALUES (@Age, @UserID)
	END
	IF(@Option = 'GetAdminByID')
	BEGIN
		SELECT * FROM [dbo].[Admin] WHERE [ID] = @ID
	END
	IF(@Option = 'GetAdminByUserID')
	BEGIN
		SELECT * FROM [dbo].[Admin] WHERE [UserID] = @UserID
	END
	IF(@Option = 'GetAllAdmins')
	BEGIN
		SELECT * FROM [dbo].[Admin]
	END
	IF(@Option = 'UpdateAdminByID')
	BEGIN
		UPDATE [dbo].[Admin] SET [Age] = @Age, [UserID] = @UserID WHERE [ID] = @ID
	END
	IF(@Option = 'DeleteAdminByID')
	BEGIN
		DELETE FROM [dbo].[Admin] WHERE [ID] = @ID
	END
END
GO