## Running Migrations

You shouldn't need to do this to use this template, but if you want migrations set up properly in the Infrastructure project, you need to specify that project name when you run the migrations command.

In Visual Studio, open the Package Manager Console, and run `Add-Migration InitialMigrationName -StartupProject Your.ProjectName.Web -Context AppDbContext -Project Your.ProjectName.Infrastructure`.

In a terminal with the CLI, the command is similar. Run this from the Web project directory:

<!-- ```powershell
dotnet ef migrations add MIGRATIONNAME -c AppDbContext -p ../Ticketer.Message.Infrastructure/Your.Ticketer.Message.Infrastructure.csproj -s Ticketer.Message.Web.csproj -o Data/Migrations
``` -->

```shell 
dotnet ef migrations add init-db -c AppDbContext -p ../Ticketer.Message.Infrastructure/Ticketer.Message.Infrastructure.csproj -s Ticketer.Message.Web.csproj -o Data/Migrations```

To use SqlServer, change `options.UseSqlite(connectionString));` to `options.UseSqlServer(connectionString));` in the `Your.ProjectName.Infrastructure.StartupSetup` file. Also remember to replace the `SqliteConnection` with `DefaultConnection` in the `Your.ProjectName.Web.Program` file, which points to your Database Server.
