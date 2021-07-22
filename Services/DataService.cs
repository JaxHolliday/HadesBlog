using HadesBlog.Data;
using HadesBlog.Enums;
using HadesBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HadesBlog.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        //Main Constructor
        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task ManageDataAsync()
        {
            //Task: Create DB from the Migrations
            await _dbContext.Database.MigrateAsync();

            //Step 1: Seed a user
            await SeedRolesAsync();

            //Step 2: Seed roles
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are roles in the system, dont do anything
            if (_dbContext.Roles.Any()) 
            {
                return;
            }

            //Otherwise create a few roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the role manager to create roles 
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            //if theere are already users in the system, dont sdo anything
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Step 1 : Creates a new instance of blog user
            var adminUser = new BlogUser()
            {
                Email = "jaxholliday@gmail.com",
                UserName = "jaxholliday@gmail.com",
                FirstName = "Jackson",
                LastName = "Holliday",
                EmailConfirmed = true,
            };

            //Step 2: user manager to create a neew user defined by admin user
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());
            
            //Creating the mod user
            //Step 1.2: Creeating the Moderator Role
            var modUser = new BlogUser()
            {
                Email = "jeffholliday11@gmail.com",
                UserName = "jeffholliday11@gmail.com",
                FirstName = "Jeff",
                LastName = "Holliday",
                EmailConfirmed = true,
            };

            //Step 2.2: user manager to create a neew user defined by admin user
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3.2: Add this new user to the administrator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());


        }





    }
}
