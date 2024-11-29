CREATE TABLE [dbo].[Counters]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Value] INT NOT NULL, 
    [EmployeeId] INT NOT NULL, 
    CONSTRAINT [FK_Counters_To_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)
