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

1. Add counter
/Counter/add

2. Increase counter
/Counter/increase

3. Get steps by team
/Team/steps

4. List all teams with steps summarized
/Team/all

5. For single team, list all employees with steps - OK
/Team/employees

6. Add and delete teams
/Team/add
/Team/delete

7. Delete counters
/Counter/delete

DTOs:
1. CounterAddDto
2. CounterIncreaseDto
3. TeamStepsDto
4. TeamAllDto
5. TeamEmployeesDto
6. TeamAddDto, TeamDeleteDto
7. [Just ID]

