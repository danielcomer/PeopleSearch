using PeopleSearch.Data.Entity;
using System.Data.Entity.Migrations;

namespace PeopleSearch.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PeopleSearchDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PeopleSearchDbContext context)
        {
            PeopleSearchDataSeeder.Seed(context);

            base.Seed(context);
        }
    }
}
