using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using TeamComeback_V2.Models;

namespace TeamComeback_V2.Models
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();


            AddTestAccount(userManager, roleManager, "password", "admin@efshell.com", "Admin");
            AddTestAccount(userManager, roleManager, "password", "user@efshell.com", "User");
        }

        private static void AddTestAccount(ApplicationUserManager userManager, ApplicationRoleManager roleManager, string password, string username, string rolename)
        {
            var adminRole = roleManager.FindByName(rolename);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(rolename);
                var roleresult = roleManager.Create(adminRole);
            }

            var adminUser = userManager.FindByName(username);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = username,
                    Email = username
                };

                var result = userManager.Create(adminUser, password);
                result = userManager.SetLockoutEnabled(adminUser.Id, false);

            }

            var roleForUser = userManager.GetRoles(adminUser.Id);
            if (!roleForUser.Contains(adminRole.Name))
            {
                var result = userManager.AddToRole(adminUser.Id, adminRole.Name);
            }
        }
    }
}