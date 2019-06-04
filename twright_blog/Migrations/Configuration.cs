namespace twright_blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using twright_blog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<twright_blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(twright_blog.Models.ApplicationDbContext context)

        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // I want to write some code that allow me to introduce a few Roles

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            // I want to write some code that allow me to introduce a few Users

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "travwright3@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "travwright3@gmail.com",
                    UserName = "travwright3@gmail.com",
                    FirstName = "Travis",
                    LastName = "Wright",
                    DisplayName = "twright"
                };

                userManager.Create(user, "TKkhhW41010!");
            }

            var userId = userManager.FindByEmail("travwright3@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(u => u.Email == "traviswright2@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "traviswright2@gmail.com",
                    UserName = "traviswright2@gmail.com",
                    FirstName = "Eugene",
                    LastName = "Wright",
                    DisplayName = "ewright"
                };

                userManager.Create(user, "TKkhhW41010!");
            }

            userId = userManager.FindByEmail("traviswright2@gmail.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
