SAMPLE Web APP in .NETCORE with Swagger API documentation, SQL Server DB connection, Dockerfile and docker-compose.yml
1) Dockerfile is a text file that contains commands to assemble an image
2) docker-compose is a tool for defining and running multi-container docker application.
	1) Written in YAML format.
	2) Defines the App's enviornment with a Dockerfile.
	3) Defines the services that make up the app.
	4) docker-compose up : Single command to RUN the entire app.
3) SQL Server DB connection
	1) https://www.microsoft.com/en-us/download/details.aspx?id=101064 - SQLEXPRESS 2019
	2) After installation, Enable TCP/IP and port 1433 - In SQL Server Configuration Manager
	   https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/configure-a-server-to-listen-on-a-specific-tcp-port?view=sql-server-ver15
	3) Repository Pattern - DB access in ASP.NET CORE
	   https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7
	4) Swagger API documentation
	   https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
