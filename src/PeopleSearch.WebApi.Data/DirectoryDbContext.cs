using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using PeopleSearch.Entities;

namespace PeopleSearch.WebApi.Data
{
    public class DirectoryDbContext : DbContext, IDirectoryDbContext
    {
        /// <summary>
        /// see: http://stackoverflow.com/questions/29110241/how-do-you-configure-the-dbcontext-when-creating-migrations-in-entity-framework
        /// until there is a fix for that, the migration string is hard coded.
        /// </summary>
        private const string MigrationConnectionString = "Server=localhost;Database=peoplesearchdb;Integrated Security=True;";
        private readonly IConfiguration _config;

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        /// <remarks>
        /// provided for migrations
        /// </remarks>
        public DirectoryDbContext() : this(null)
        {
        }

        public DirectoryDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config == null ? MigrationConnectionString : _config["Data:DefaultConnection:ConnectionString"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Address>()
                .Property(a => a.StreetLineOne)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .MaxLength(30)
                .Required();

            //modelBuilder.Entity<Person>()
            //    .Reference(p => p.HomeAddress);

            base.OnModelCreating(modelBuilder);
        }
    }
}
