CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [TeamId] INT NOT NULL, 
    CONSTRAINT [FK_Employees_To_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)
