using System.Data.Entity.Migrations;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Migrations
{
    public sealed class PeopleSearchMigrationsConfiguration : DbMigrationsConfiguration<PeopleServiceContext>
    {
        public PeopleSearchMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PeopleServiceContext context)
        {
            PeopleSearchDataSeeder.Seed(context);

            base.Seed(context);
        }
    }
}
