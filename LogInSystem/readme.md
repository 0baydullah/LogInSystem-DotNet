###Steps :
	- Session Related Work
	- DB Rrelated Work (DbFirstApproach)
		- install 3 packages (Ms.Efc.SqlServer+Tools+Design)
		- execute command for Scaffold DbContext 
			```
			Scaffold-DbContext "Server=MACHINEX\SQLEXPRESS;Database=MyDb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models (-force)
			```
		- move connection string from DbContext class to appsettings.json file
		- registering Connection String in Program.cs file
			```
			var provider = builder.Services.BuildServiceProvider(); 
			var config = provider.GetRequiredService<IConfiguration>();
			builder.Services.AddDbContext<MyDbContext>(item=>item.UseSqlServer(config.GetConnectionString("dbcs")));
			```
	- Login and Logout Task
		- create action methods for login and logout
		- create session variable in login action method and access it




# EF Core: LogIn/LogOut System With DbFirst Approach with Session and Authentication

This document outlines the steps of Login and logout system with set up a database-first project using EF Core with session management and login/logout functionality.

---

## Steps

### 1. **Session Related Work**
   - Set up session configuration in your `Program.cs` or `Startup.cs` file.
   - Add middleware to use sessions for handling user-specific data.

---

### 2. **Database-First Approach (DbFirst)**

#### a) Install Required EF Core Packages
Run the following commands to install the necessary packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```
