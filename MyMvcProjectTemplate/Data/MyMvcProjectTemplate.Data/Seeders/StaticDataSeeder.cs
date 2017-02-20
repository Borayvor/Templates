namespace MyMvcProjectTemplate.Data.Seeders
{
    using System.Linq;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using MyMvcProjectTemplate.Common.Constants;

    internal static class StaticDataSeeder
    {
        internal static void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var administratorRole = new IdentityRole { Name = AuthConstants.AdministratorRoleName };
            roleManager.Create(administratorRole);

            context.SaveChanges();
        }

        internal static void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            // admin data
            const string AdministratorEmail = "admin@admin.com";
            const string AdministratorUsername = "Admin";
            const string AdministratorPassword = "admin";

            // Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new MinimumLengthValidator(AuthConstants.PasswordMinLength);

            var userAdmin = new ApplicationUser
            {
                Email = AdministratorEmail,
                UserName = AdministratorUsername
            };

            userManager.Create(userAdmin, AdministratorPassword);

            // Assign user to admin role
            userManager.AddToRole(userAdmin.Id, AuthConstants.AdministratorRoleName);

            // End add.
            context.SaveChanges();
        }
    }
}
