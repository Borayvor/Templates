namespace MyMvcProjectTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            StaticDataSeeder.SeedRoles(context);
            StaticDataSeeder.SeedUsers(context);
        }
    }
}
