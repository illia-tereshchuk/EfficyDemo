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

1. Add counter - DONE
/Counters/add

2. Increase counter - DONE
/Counters/increase/{id}

3. Get steps by team - DONE
/Teams/steps/{id}

4. List all teams with steps summarized - DONE
/Teams/all

5. For single team, list all employees with steps - DONE
/Teams/{id}/employees

6. Add and delete teams
/Teams/add
/Teams/delete/{id}

7. Delete counters - DONE
/Counters/delete/{id}

DTOs:
1. CounterAddDto - DONE
2. CounterIncreaseDto - DONE
3. [Int (Quantity)] - DONE
4. TeamsAllDto - DONE
5. TeamEmployeesDto (+ EmployeeStepsDto)
6. TeamAddDto, [Int (Id)]
7. [Int (Id)]

