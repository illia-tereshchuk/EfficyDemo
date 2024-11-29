I am Illia Tereshchuk, and this is my demo for Efficy.

1. Create database tables with following structure:

COUNTERS
- Id (int)
- Value (int)
- EmployeeId (int)

EMPLOYEES
- Id (int)
- Name (nvarchar(50))
- TeamId (int)

TEAMS
- Id (int)
- Name (nvarchar(50))

Use "SQL Database Server" project to create database tables.
Deploy this database locally and fill with random test data.

2. Create data access layer for the database tables. Use Entity Framework.




All the technical task revolves around REST API.
For this, I will shorten user stories dead simple.
And then, describe a REST API endpoints for them.
For that endpoints I will also name future DTOs.
This will allow to keep consistency in naming.

1. Add counter						/Counters/add				CounterAddDto
2. Increase counter					/Counters/increase/{id}		CounterIncreaseDto
3. Get steps by team				/Teams/steps/{id}			[Int]
4. List all teams with steps		/Teams/all					TeamsAllDto
5. For team, employees with steps	/Teams/{id}/employees		TeamEmployeesDto 
6. Add and delete teams				/Teams/add					[String]
									/Teams/delete/{id}			[Int]
7. Delete counters					/Counters/delete/{id}		[Int]