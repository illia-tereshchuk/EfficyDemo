# Efficy Demo by Illia Tereshchuk

Welcome to my Efficy demo! This project demonstrates a **data-first approach** by leveraging SQL Server, Entity Framework, and RESTful APIs.

## Data Model

The project revolves around three core entities: **Counters**, **Employees**, and **Teams**. Below is the schema design:

### Tables

#### COUNTERS
| Column       | Type   |
|--------------|--------|
| `Id`         | `int`  |
| `Value`      | `string` |
| `EmployeeId` | `int`  |

#### EMPLOYEES
| Column   | Type   |
|----------|--------|
| `Id`     | `int`  |
| `Name`   | `string` |
| `TeamId` | `int`  |

#### TEAMS
| Column   | Type   |
|----------|--------|
| `Id`     | `int`  |
| `Name`   | `string` |

## Project Setup

1. **Database Design**:
   - The tables and post-deployment scripts were created using the **"SQL Database Server" project template** in Visual Studio.
   - The database was published locally for testing and validation using **SQL Explorer**.

2. **Data Access Layer**:
   - Designed using **Entity Framework** for seamless interaction with the database.

## REST API Design

The project’s main functionality is encapsulated in REST API endpoints. Below are the user stories and their respective endpoints.

### Endpoints

#### **Counters**
- **Add Counter**  
  `POST /Counters/addCounter`  
  Parameters: `employeeId`, `value`  
  Response: `OK` / `ERROR`

- **Increase Counter**  
  `POST /Counters/increaseCounter`  
  Parameters: `counterId`, `value`  
  Response: `OK` / `ERROR`

- **Delete Counter**  
  `DELETE /Counters/deleteCounter`  
  Parameters: `counterId`  
  Response: `OK` / `ERROR`

- **Get Counters for Employee**  
  `GET /Counters/getForEmployee`  
  Parameters: `employeeId`  
  Response: `[{ id, value, employeeId }]`

#### **Teams**
- **Add Team**  
  `POST /Teams/addTeam`  
  Parameters: `teamName`  
  Response: `OK` / `ERROR`

- **Delete Team**  
  `DELETE /Teams/deleteTeam`  
  Parameters: `teamId`  
  Response: `OK` / `ERROR`

- **Get Steps by Team**  
  `GET /Teams/getSteps`  
  Parameters: `teamId`  
  Response: `int`

- **List All Teams with Steps**  
  `GET /Teams/getAll`  
  Response: `[{ id, name, totalSteps }]`

- **Get Employees in a Team with Steps**  
  `GET /Teams/getEmployees`  
  Parameters: `teamId`  
  Response: `[{ id, name, teamId, teamName, totalSteps }]`

#### **Employees**
- **Switch Employee's Team**  
  `PUT /Employees/switchTeam`  
  Parameters: `employeeId`, `newTeamId`  
  Response: `OK` / `ERROR`

- **List All Employees**  
  `GET /Employees/getAll`  
  Response: `[{ id, name, teamId, teamName, totalSteps }]`

---

## Future Plans

1. Enhance the API with more robust error handling and validation.
2. Develop a user interface to interact with the APIs seamlessly.
3. Expand test coverage for all endpoints.

---

Feel free to explore and adapt this project as needed! 😊
