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
Deploy this database locally and fill with generated data.

2. Create data access layer for the database tables. Use Entity Framework.




User stories can be simplified to the following:

1. Add counter - OK
/Counter/add

2. Increase counter  - OK
/Counter/increase

3. Get steps by team - OK
/Team/step

4. List all teams with steps summarized - OK
/Team/summary

5. For single team, list all employees with steps - OK
/Team/employees

6. Add and delete teams
/Team/add
/Team/delete

7. Delete counters
/Counter/delete