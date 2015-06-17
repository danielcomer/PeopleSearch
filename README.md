
There are a few manual steps you have to run because Entity Framework 7 is still very much in a beta state.

I couldn't find any support for complex types yet.
Additionally, when querying sql server using EF7 I am getting exceptions if I include the Interests collection.
I couldn't find any support for seeding data in EF7 yet, so the WebApi is inserting some data during startup if it is empty.

I also couldn't figure out how to set an initialization strategy: see http://stackoverflow.com/questions/29875781/asp-net-vnext-mvc-and-entity-framework-issues

So, to run the migrations to create the database there are some manual steps.

- go to the PeopleSearch.WebApi project and modify: config.json - set the connection string to your sql server. (Additionally, there is a config value to set the simulated amount of time to delay)

- go to the PeopleSearch.WebApi.Data project and modify: DirectoryDbContext.cs - set the MigrationConnectionString to your sql server (Note: this is only hard coded until the migration tool is updated to support dependency injection as they have done with the latest asp.net mvc.)

- From a command prompt, go to the root of the PeopleSearch.WebApi.Data project and run: dnx . ef migration apply
 

Once the database is configured, running the solution in debug mode will first start the WebApi, and then the wpf client.  The connection string for the client to the api is in App.config.  The default url should work in debug mode.
