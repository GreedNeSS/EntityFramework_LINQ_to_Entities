using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoinAndGroupBy.Models;
using Microsoft.EntityFrameworkCore;

namespace JoinAndGroupBy
{
    public static class Utils
    {
        public static void CterateEmployeeDB(List<User> users, List<Company> companies, List<Country> countries)
        {
            Console.WriteLine("\n=> CterateEmployeeDB()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Countries.AddRange(countries);
                db.Companies.AddRange(companies);
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        public static void ShowEmployeeInfo()
        {
            Console.WriteLine("\n=> ShowEmployeeInfo()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = from u in db.Users
                            join c in db.Companies on u.CompanyId equals c.Id
                            join country in db.Countries on c.CountryId equals country.Id
                            select new
                            {
                                u.Name,
                                Company = c.Title,
                                Country = country.Name
                            };

                foreach (var user in users)
                {
                    Console.WriteLine($"Name: {user.Name}, Company: {user.Company}, Country: {user.Country}");
                }
            }
        }

        public static void ShowEmployeeInfo_Alternate()
        {
            Console.WriteLine("\n=> ShowEmployeeInfo_Alternate()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Join(db.Companies,
                    u => u.CompanyId,
                    c => c.Id,
                    (u, c) => new
                    {
                        u.Name,
                        Company = c.Title,
                        c.CountryId
                    })
                    .Join(db.Countries,
                    u => u.CountryId,
                    c => c.Id,
                    (u, c) => new
                    {
                        u.Name,
                        u.Company,
                        Country = c.Name
                    });


                foreach (var user in users)
                {
                    Console.WriteLine($"Name: {user.Name}, Company: {user.Company}, Country: {user.Country}");
                }
            }
        }

        public static void ShowGroupingByCompany()
        {
            Console.WriteLine("\n=> ShowGroupingByCompany()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var groupUsers = from u in db.Users.Include(u => u.Company)
                            group u by u.Company!.Title into g
                            select new
                            {
                                g.Key,
                                Count = g.Count(),
                                UserList = g.ToList()
                            };

                foreach (var group in groupUsers)
                {
                    Console.WriteLine($"\nCompany: {group.Key}, EmployeesCount: {group.Count}");

                    foreach (var user in group.UserList)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(user);
                        Console.ResetColor();
                    }
                }
            }
        }

        public static void ShowGroupingByCompany_Alternate()
        {
            Console.WriteLine("\n=> ShowGroupingByCompany_Alternate()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var groupUsers = db.Users.GroupBy(u => u.Company!.Title)
                    .Select(g => new
                    {
                        g.Key,
                        Count = g.Count(),
                        UserList = g.ToList()
                    });

                foreach (var group in groupUsers)
                {
                    Console.WriteLine($"\nCompany: {group.Key}, EmployeesCount: {group.Count}");

                    foreach (var user in group.UserList)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(user);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
