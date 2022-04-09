using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingAndProjection.Models;
using Microsoft.EntityFrameworkCore;

namespace SortingAndProjection
{
    public static class Utils
    {
        public static void CterateEmployeeDB(List<User> users, List<Company> companies)
        {
            Console.WriteLine("\n=> CterateEmployeeDB()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Users.AddRange(users);
                db.Companies.AddRange(companies);
                db.SaveChanges();
            }
        }

        public static void ShowUserModels(List<UserModel> users)
        {
            Console.WriteLine("\n=> ShowUsers():");

            foreach (var user in users)
            {
                ShowUserModel(user);
            }
        }

        public static void ShowUserModel(UserModel user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(user);
            Console.ResetColor();
        }

        public static List<UserModel> GetAllUserModels(List<User> users)
        {
            Console.WriteLine("\n=> GetAllUserModels()");

            var userModels = users
                .Select(u => new UserModel
                {
                    Name = u.Name,
                    Age = u.Age,
                    CompanyTitle = u.Company!.Title
                })
                .ToList();

            return userModels;
        }

        public static List<User> GetAllUser()
        {
            Console.WriteLine($"\n=> GetAllUser()");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(u => u.Company).ToList();

                return users;           
            }
        }

        public static List<UserModel> OrderedUserModelsByName(List<UserModel> userModels)
        {
            Console.WriteLine($"\n=> OrderedUserModelsByName()");

            var users = from userModel in userModels
                        orderby userModel.Name
                        select userModel;

            return users.ToList();
        }

        public static List<UserModel> OrderedUserModelsByNameAndAge(List<UserModel> userModels)
        {
            Console.WriteLine($"\n=> OrderedUserModelsByNameAndAge()");

            //var users = from userModel in userModels
            //            orderby userModel.Name, userModel.Age
            //            select userModel;

            var users = userModels
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Age);

            return users.ToList();
        }
    }
}
