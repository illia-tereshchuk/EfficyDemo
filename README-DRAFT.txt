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


DB Name:	EfficyDemo.Db
Server:		efficy-demo-db-server.database.windows.net
Login:		efficy-demo-admin
Password:	DifficultPassword123

Server=tcp:efficy-demo-db-server.database.windows.net,1433;Initial Catalog=EfficyDemo.Db;Persist Security Info=False;User ID=efficy-demo-admin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

Server=tcp:efficy-demo-db-server.database.windows.net,1433;Initial Catalog=EfficyDemo.Db;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication="Active Directory Default";