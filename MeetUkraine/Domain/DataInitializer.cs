using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DataInitializer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, MeetUkraineContext context)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager, context);
        }

        public static async Task SeedUsers(UserManager<User> userManager, MeetUkraineContext context)
        {
            string username = "admin@gmail.com";
            string password = "mainadmin";
            if (await userManager.FindByNameAsync(username) == null)
            {
                User admin = new User() { UserName = username, Email = username,FirstName="Andriy",LastName="Galiv" };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                    await userManager.AddToRoleAsync(admin, "Traveller");
                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Traveller", "Admin" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (roleExist == false)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
