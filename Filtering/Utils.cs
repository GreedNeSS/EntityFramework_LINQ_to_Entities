using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filtering.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtering
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

        public static void ShowUsers(List<User> users)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=> ShowUsers():");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.ResetColor();
        }

        public static void ShowUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=> ShowUser():");
            Console.WriteLine(user);
            Console.ResetColor();
        }

        public static List<User> GetCompanyEmployees(string companyTitle)
        {
            Console.WriteLine($"\n=> GetCompanyEmployees({companyTitle})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(u => u.Company)
                    .Where(u => u.Company!.Title == companyTitle)
                    .ToList();

                return users;           
            }
        }

        public static List<User> GetUsersByName(string namePattern)
        {
            Console.WriteLine($"\n=> GetUsersByName({namePattern})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(u => u.Company)
                    .Where(u => EF.Functions.Like(u.Name!, namePattern))
                    .ToList();

                return users;           
            }
        }

        public static List<User> GetUsersByAge(string agePattern)
        {
            Console.WriteLine($"\n=> GetUsersByAge({agePattern})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = from user in db.Users.Include(u => u.Company)
                            where EF.Functions.Like(user.Age.ToString(), agePattern)
                            select user;

                return users.ToList();           
            }
        }

        public static User? GetUser(int userId)
        {
            Console.WriteLine($"\n=> GetUser({userId})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.Include(u => u.Company)
                    .Where(u => u.Id == userId).FirstOrDefault();

                return user;
            }
        }
    }
}
