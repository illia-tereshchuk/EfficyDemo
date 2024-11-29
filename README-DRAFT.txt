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

Use "SQL Database Server" project to create database tables."
Deploy this database locally and fill with generated data.

2. Create data access layer for the database tables. Use Entity Framework.








REQUIREMENTS

1. Add new counter for single employee - OK

2. Increment a single counter  - OK

3. Get total steps taken by a team - OK

4. List all teams and show their step counts - OK

5. List all employees and their step count for certain team - OK

6. Add and delete teams

7. Add and delete counters