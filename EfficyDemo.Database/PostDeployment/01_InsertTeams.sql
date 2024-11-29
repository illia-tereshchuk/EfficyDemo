/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Teams] ON;
INSERT INTO [dbo].[Teams] (Id, Name)
VALUES 
    (1, 'Marketing'),
    (2, 'Sales'),
    (3, 'Human Resources'),
    (4, 'Finance'),
    (5, 'Research and Development'),
    (6, 'Customer Support'),
    (7, 'IT'),
    (8, 'Operations'),
    (9, 'Legal'),
    (10, 'Product Management');
SET IDENTITY_INSERT [dbo].[Teams] OFF;