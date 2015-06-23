using System.Data.Entity.Migrations;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Migrations
{
    public sealed class PeopleSearchMigrationsConfiguration : DbMigrationsConfiguration<PeopleServiceDbContext>
    {
        public PeopleSearchMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PeopleServiceDbContext dbContext)
        {
            PeopleSearchDataSeeder.Seed(dbContext);

            base.Seed(dbContext);
        }
    }
}
