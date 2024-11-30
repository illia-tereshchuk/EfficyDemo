I am Illia Tereshchuk, and this is my demo for Efficy.
As I like "data first" approach, let's define the model.

COUNTERS
[Id]			int
[Value]			string
[EmployeeId]	int

EMPLOYEES
[Id]			int
[Name]			string
[TeamId]		int

TEAMS
[Id]			int
[Name]			string

In Visual Studio, I use "SQL Database Server" project template.
I design the tables and post-deployment scripts to fill them.
Then I publish database locally and check it in SQL Explorer.

Next, I design Data Access Layer, which utilizes Entity Framework.

All the technical task revolves around REST API.
For this, I will shorten user stories to meaning.
And then, describe a REST API endpoints for them.
For that endpoints I will also name future DTOs.
This will allow to keep consistency in naming.

1. Add counter						/Counters/addCounter		?employeeId=1&value=1		OK / ERROR					
2. Increase counter					/Counters/increaseCounter	?counterId=1&value=1		OK / ERROR
3. Get steps by team				/Teams/getSteps				?teamId=1					int
4. List all teams with steps		/Teams/getAll											[{ id, name, totalSteps }]
5. For team, employees with steps	/Teams/getEmployees			?teamId=1					[{ id, name, teamId, teamName, totalSteps }]		
6. Add and delete teams				/Teams/addTeam				?teamName=abc				OK / ERROR
									/Teams/deleteTeam			?teamId=1					OK / ERROR
7. Delete counter					/Counters/deleteCounter		?counterId=1				OK / ERROR

We also need additional methods to make this work:

A. Switch employee's team 		/Employees/switchTeam		?employeeId=1&newTeamId=2	OK / ERROR
B. Get all employees			/Employees/getAll										[{ id, name, teamId, teamName, totalSteps }]
C. Get counters for employee	/Counters/getForEmployee	?employeeId=1				[{ id, value, employeeId }]
