using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "InitialPassword1$";
        private const string adminRoleName = "Administrator";
        private const string mngUser = "User";
        private const string mngPassword = "InitialPassword2$";
        private const string mngRoleName = "Manager";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //role general
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            
            //admin role
            IdentityRole adminRole = await roleManager.FindByNameAsync(adminRoleName);
            if(adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                await roleManager.CreateAsync(adminRole);
            }

            //manager role
            IdentityRole mngRole = await roleManager.FindByNameAsync(mngRoleName);
            if (mngRole == null)
            {
                mngRole = new IdentityRole(mngRoleName);
                await roleManager.CreateAsync(mngRole);
            }
            
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            //admin user
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if(user == null)
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
            else
            {
                if(!(await userManager.IsInRoleAsync(user, adminRoleName)))
                {
                    await userManager.AddToRoleAsync(user, adminRoleName);
                }
            }

            //manager user
            IdentityUser userMng = await userManager.FindByNameAsync(mngUser);

            if (userMng == null)
            {
                userMng = new IdentityUser(mngUser);
                await userManager.CreateAsync(userMng, mngPassword);
                await userManager.AddToRoleAsync(userMng, mngRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(userMng, mngRoleName)))
                {
                    await userManager.AddToRoleAsync(userMng, mngRoleName);
                }
            }
        }
    }
}
