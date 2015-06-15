using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using PeopleSearch.WebApi.Data;
using PeopleSearch.WebApi.Data.Entities;

namespace PeopleSearch.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DirectoryDbContext>(options => options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString")));

            services.AddMvc();

            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddScoped<IDirectoryDbContext, DirectoryDbContext>();
            services.AddScoped<IDirectoryRepository, DbContextDirectoryRepository>();
        }

        private void GenerateSeedData(DirectoryDbContext context)
        {
            if (context.People.FirstOrDefault() == null)
            {
                var a1 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "1728 Candlelight Drive",
                    City = "Houston",
                    StateOrProvince = "TX",
                    PostalCode = "77032"
                });

                var a2 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "3439 Viking Drive",
                    City = "Byesville",
                    StateOrProvince = "OH",
                    PostalCode = "43723"
                });
                var a3 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "4594 Berkley Street",
                    City = "Philadelphia",
                    StateOrProvince = "PA",
                    PostalCode = "19103"
                });
                var a4 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "3202 Briercliff Road",
                    City = "Hicksville",
                    StateOrProvince = "NY",
                    PostalCode = "11612"
                });
                var a5 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "2016 Overlook Drive",
                    City = "Indianapolis",
                    StateOrProvince = "IN",
                    PostalCode = "46225"
                });
                var a6 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "3021 Stadium Drive",
                    City = "Brockton",
                    StateOrProvince = "MA",
                    PostalCode = "02401"
                });
                var a7 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "3403 Benedum Drive",
                    City = "New Paltz",
                    StateOrProvince = "NY",
                    PostalCode = "12561"
                });
                var a8 = context.Addresses.Add(new Address
                {
                    StreetLineOne = "161 Clarence Court",
                    City = "Long Beach",
                    StateOrProvince = "NC",
                    PostalCode = "28461"
                });

                context.SaveChanges();

                context.People.Add(new Person { FirstName = "Susan", LastName = "Nicholson", Gender = Gender.Female, HomeAddress = a1.Entity });
                context.People.Add(new Person { FirstName = "Albert", LastName = "Porter", Gender = Gender.Male, HomeAddress = a2.Entity });
                context.People.Add(new Person { FirstName = "Helen", LastName = "Short", Gender = Gender.Female, HomeAddress = a3.Entity });
                context.People.Add(new Person { FirstName = "Wendell", LastName = "Ford", Gender = Gender.Male, HomeAddress = a4.Entity });
                context.People.Add(new Person { FirstName = "Billy", LastName = "Lane", Gender = Gender.Male, HomeAddress = a5.Entity });
                context.People.Add(new Person { FirstName = "Roberto", LastName = "Peloquin", Gender = Gender.Male, HomeAddress = a6.Entity });
                context.People.Add(new Person { FirstName = "Carrie", LastName = "Crawford", Gender = Gender.Female, HomeAddress = a7.Entity });
                context.People.Add(new Person { FirstName = "Linwood", LastName = "McCarter", Gender = Gender.Female, HomeAddress = a8.Entity });

                context.SaveChanges();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DirectoryDbContext context)
        {
            //todo: replace with seed data in entity framework 7 when they implement it
            GenerateSeedData(context);

            //// Configure the HTTP request pipeline.
            //// Add the console logger.
            //loggerfactory.AddConsole();

            //// Add the following to the request pipeline only in development environment.
            //if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            //{
            //    app.UseBrowserLink();
            //    app.UseErrorPage(ErrorPageOptions.ShowAll);
            //    app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            //}
            //else
            //{
            //    // Add Error handling middleware which catches all application specific errors and
            //    // send the request to the following path or controller action.
            //    app.UseErrorHandler("/Home/Error");
            //}

            //// Add static files to the request pipeline.
            //app.UseStaticFiles();

            //// Add cookie-based authentication to the request pipeline.
            //app.UseIdentity();

            //// Add MVC to the request pipeline.
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{controller}/{action}/{id?}",
            //    defaults: new { controller = "Home", action = "Index" });
            //});

            app.UseMvc();
            app.UseWelcomePage();
        }
    }
}
