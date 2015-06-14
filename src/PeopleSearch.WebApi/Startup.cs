using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace PeopleSearch.WebApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration().AddJsonFile("config.json").AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            //todo
            //services.AddEntityFramework(Configuration).AddSqlServer().AddDbContext<RegistrationDbContext>();

            services.AddMvc();

            //todo: register repositories and database contexts
            //services.AddScoped<IPersonRepo, RegistrationRepo>();
            //services.AddScoped<RegistrationDbContext, RegistrationDbContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseWelcomePage();
        }
    }
}
