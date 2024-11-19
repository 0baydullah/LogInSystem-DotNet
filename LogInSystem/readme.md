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