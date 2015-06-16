using System;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using PeopleSearch.Entities;
using PeopleSearch.WebApi.Data;

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
                .AddDbContext<DirectoryDbContext>(builder => builder.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString")));

            services.AddMvc();

            services.AddInstance(Configuration);
            services.AddScoped<IDirectoryDbContext, DirectoryDbContext>();
            services.AddScoped(DirectoryRepositoryImplementationFactory);
        }

        private IDirectoryRepository DirectoryRepositoryImplementationFactory(IServiceProvider serviceProvider)
        {
            var dbContext = (IDirectoryDbContext)serviceProvider.GetService(typeof(IDirectoryDbContext));
            var repository = new DbContextDirectoryRepository(dbContext);

            var delay = int.Parse(Configuration["Services:RepositorySimulatedDelayInMilliseconds"]);

            if (delay <= 0)
            {
                return repository;
            }

            return new DelaySimulatedDirectoryRepositoryDecorator(repository, delay);
        }

        /// <remarks>
        /// Seed Data Generation isn't possible in EF7 yet
        /// </remarks>
        private static void GenerateSeedData(DirectoryDbContext context)
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

                context.People.Add(new Person { Id = 1, FirstName = "Susan", LastName = "Nicholson", Gender = Gender.Female, HomeAddress = a1.Entity });
                context.People.Add(new Person { Id = 2, FirstName = "Albert", LastName = "Porter", Gender = Gender.Male, HomeAddress = a2.Entity });
                context.People.Add(new Person { Id = 3, FirstName = "Helen", LastName = "Short", Gender = Gender.Female, HomeAddress = a3.Entity });
                context.People.Add(new Person { Id = 4, FirstName = "Wendell", LastName = "Ford", Gender = Gender.Male, HomeAddress = a4.Entity });
                context.People.Add(new Person { Id = 5, FirstName = "Billy", LastName = "Lane", Gender = Gender.Male, HomeAddress = a5.Entity });
                context.People.Add(new Person { Id = 6, FirstName = "Roberto", LastName = "Peloquin", Gender = Gender.Male, HomeAddress = a6.Entity });
                context.People.Add(new Person { Id = 7, FirstName = "Carrie", LastName = "Crawford", Gender = Gender.Female, HomeAddress = a7.Entity });
                context.People.Add(new Person { Id = 8, FirstName = "Linwood", LastName = "McCarter", Gender = Gender.Female, HomeAddress = a8.Entity });

                context.SaveChanges();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DirectoryDbContext context)
        {
            //todo: replace with seed data in entity framework 7 when they implement it
            GenerateSeedData(context);

            app.UseStaticFiles();
            app.UseMvc();
            app.UseWelcomePage();
        }
    }
}
