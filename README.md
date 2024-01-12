# cmcbeassisgnment
# Your Project Name
CMC Market backend assessment
## Introduction

# Task 1: Data Persistence
Integrate a database (SQL Server or SQLite) to persist user-related data, such as user profiles and
roles. Implement a database schema that supports the authentication and authorization
requirements.
# Task 2: Advanced Query
Implement a complex query functionality in one of your API endpoints. For example, if your API deals
with tasks, create an endpoint that retrieves tasks based on specific criteria (e.g., tasks completed in
the last 7 days).

# Task 3: Asynchronous Programming
Demonstrate the use of asynchronous programming in at least one part of your C# back-end. This
could involve asynchronous database operations or using async/await in the API controllers.
# Task 4: Exception Handling
Implement robust exception handling for your API. Ensure that the application gracefully handles
common errors, returns appropriate HTTP status codes, and provides informative error messages.

## Prerequisites

List the prerequisites that the user needs to have installed before running the project.
 # Install Required NuGet Packages
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) (optional but recommended)
- SQL Server instance and connection string


## Getting Started

Provide step-by-step instructions to set up the project locally.

1. Clone the repository:

    ```bash
    git clone https://github.com/venkatweb1234/cmcbeassisgnment.git
    ```

2. Open the project in Visual Studio or your preferred IDE.

3. Configure the database connection string in `appsettings.json`.
   -  "ConnectionStrings": {
   "SqlConn": "Data Source=.\\sqlexpress;Initial Catalog=userroletask;Integrated Security=True;Encrypt=False"
 } (Aready is there no need to config)

4. Run the following commands in the terminal to apply database migrations:

    ```bash
    Add-Migration "User Role Task Migration"
    Update-Database
    ```

5. Run the application:

    ```bash
    dotnet run or directly run under Visual studio it will open the swagger for API end points
    ```

- Visit `https://localhost:7021/swagger/index.html` to access Swagger documentation and test your API endpoints.

## Production Release

The steps to prepare the project for production release.

1. Update the `appsettings.json` file with production-specific configurations.

2. Set the environment variable to `Production`:

    ```bash
    export ASPNETCORE_ENVIRONMENT=Production
    ```

3. Publish the application:

    ```bash
    dotnet publish -c Release
    ```

4. Deploy the published files to your production server.

## Usage

### API Endpoints

# Task1
1. **Persist User Profiles to Database(Post)**
   - Endpoint: `POST /api/UserProfiles`
   - Description: Persisting User Data to Database.
   - Request Body:
     ```json
    {
      "userName": "Jasmin",
      "email": "jasmin@gmail.com",
      "password": "Test@23",
      "roleKey": "Admin"
    }
     ```
   - Response:
     - User has been created successfully: HTTP 200 OK
     - userName is not correct: HTTP 400 Bad Request
     - If any error occured during persisting data 500 (Internal server error)
**To see saved user records**
   - Endpoint: `GET /api/UserProfiles`
     
2. **Persist Roles to Database(Post)**
   - Endpoint: `POST /api/Roles`
   - Description: Persisting Role Data to Database.
   - Request Body:
     ```json
    {
      "roleKey": "Admin",
      "roleName": "Administartor"
    }
     ```
   - Response:
     - Role has been created successfully: HTTP 200 OK
     - roleKey or roleName is not correct: HTTP 400 Bad Request
     - If any error occured during persisting data 500 (Internal server error)
 **To see saved role records**
   - Endpoint: `GET /api/Roles`

3. **User Login**
   - Endpoint: `POST /api/Login`
   - Description: Authenticate a user.
   - Request Body:
     ```json
     {
      "userName": "Venkat",
      "password": "Test@123"
    }
     ```
   - Response:
     - Successful login: HTTP 200 OK with an authentication
     - Invalid credentials: HTTP 401 Unauthorized
     - If any error occured during process 500 (Internal server error)

# Task 2
3. **Tasks completed in the last 7 days.**
   - Endpoint: `GET /api/Tasks/Completed-last-7-days`
   - Description: Implement a complex query functionality in one of your API endpoints. For example, if your API deals with tasks, create an endpoint that retrieves tasks based on specific criteria.
   - Response:
     - Successful HTTP 200 OK with an last 7 days tasks or empty
     - If any error occured during process 500 (Internal server error)


# Task 3: Asynchronous Programming
- Added async/await all controllers ((Tasks Controller, UserProfile controller, Role Controller, Login Controller) and asynchronous database operations

# Task 4: Exception Handling
- Implemented robust exception handling for all API endpoint. Added common errors to find try/catch/finally. Implemented required HTTP status codes for all tasks(end points)

# Additionally added Log4net for log the all logs
- I added Log4net for log the files.
- Look at the logs folder for all logs
## Handover Instructions

1. **Project Structure:**
   - The project follows a standard ASP.NET Core Web API structure.
   - Important directories include `Controllers`, `Models`, and `Data` for database-related code.

2. **Database Schema:**
   - The database schema includes tables for user information, roles, and tasks.
   - Migrations have been applied using Entity Framework Core.

3. **Authentication and Authorization:**
   - User authentication and authorization is done based on Username, password, role.
     only the user who has role Admin can be authorised along with success username and password.
   - Note: In the task just mention databse schema I have done that.
   - ** Coming to reality we can use JWT Token for authorization, that I did not implement that because in task mentioned only database Schema **.

4. **API Endpoints:**
   - Refer to the "Usage" section for a list of key API endpoints.

5. **Development Environment:**
   - The project was developed using Visual Studio with .NET SDK installed.
   - Ensure the target .NET runtime version is compatible.

6. **Deployment:**
   - Deploy the application by publishing it in Release mode (`dotnet publish -c Release`).
   - Set the environment variable `ASPNETCORE_ENVIRONMENT` to `Production` for production-specific configurations.

7. **Known Issues:**
   - No known issues at the time of handover.

  ## Process
   1) For Fist task persist User profile and Role (User Controller and Role Controller), For Authentication and Authrozation (Login Controller)
   2) For Second Task (last 7 days tasks) TasksController
   3) For DB, used SQL Server , With DBContext, tables (UserProfile, Role, Tasks) are create dautomatically once run the program
   4) For Tasks , we have to insert data manually
      insertion script is

   5) Async/await, Exception Handling, Logging were implemented
   6) Use /swagger/index.html to view and test end points
   7) All logs are captured in log.txt file
  
  screen shots for each end point  are attached
  ## Screen Shot for All End Points
 - Please refer this path: cmcmarketsbetask\cmcmarketsbetask\images\All end points.png
 ## How to excute endpoint in Swagger
     ## Go to UserProfile end point click on Tryit button
     - Please refer this path:  cmcmarketsbetask/cmcmarketsbetask/images/UserProfile Try it button.png
     ## Change request body and press execute button
     - Please refer this path: cmcmarketsbetask\cmcmarketsbetask\images\Changing requested body and press execute button.png
     ## Then see the Success Message
    - Please refer this path: cmcmarketsbetask\cmcmarketsbetask\images\Success response for userprofile.png
     ## Verify Stored UserProfile Data By using GetUserProfile End point
    - Please refer this path: cmcmarketsbetask\cmcmarketsbetask\images\using get userprofiles we can see added user .png
