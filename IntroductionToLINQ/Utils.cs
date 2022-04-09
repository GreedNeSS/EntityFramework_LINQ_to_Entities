using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroductionToLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToLINQ
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

        public static void ShowCompanyEmployees_LINQOperators(int companyId)
        {
            Console.WriteLine($"\n=> ShowCompanyEmployees_LINQOperators({companyId})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = from user in db.Users.Include(u => u.Company)
                            where user.CompanyId == companyId
                            select user;

                if (users != null)
                {
                    Console.WriteLine($"\nCompanyName: {users.FirstOrDefault()?.Company?.Title}");

                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                }            
            }
        }

        public static void ShowCompanyEmployees_LINQMethods(int companyId)
        {
            Console.WriteLine($"\n=> ShowCompanyEmployees_LINQMethods({companyId})");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(u => u.Company).Where(u => u.CompanyId == companyId);

                if (users != null)
                {
                    Console.WriteLine($"\nCompanyName: {users.FirstOrDefault()?.Company?.Title}");

                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                }            
            }
        }
    }
}
