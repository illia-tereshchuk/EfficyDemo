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

1. Add counter - OK
/Counters/add

2. Increase counter - OK
/Counters/increase

3. Get steps by team
/Teams/steps

4. List all teams with steps summarized
/Teams/all

5. For single team, list all employees with steps - OK
/Teams/employees

6. Add and delete teams
/Teams/add
/Teams/delete

7. Delete counters - OK
/Counters/delete

DTOs:
1. CountersAddDto
2. CountersIncreaseDto
3. TeamsStepsDto
4. TeamsAllDto
5. TeamsEmployeesDto
6. TeamsAddDto, TeamsDeleteDto
7. [Just ID]

