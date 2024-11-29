CREATE TABLE [dbo].[Employees]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [TeamId] INT NOT NULL, 
    CONSTRAINT [FK_Employees_To_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)
