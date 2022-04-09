using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionIntersectExcept.Models;
using Microsoft.EntityFrameworkCore;

namespace UnionIntersectExcept
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
                db.Companies.AddRange(companies);
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }

        public static void ShowUnion()
        {
            Console.WriteLine("\n=> ShowUnion()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users
                    .Include(u => u.Company)
                    .Where(u => u.Name!.Contains("Henry"))
                    .Union(db.Users
                        .Include(u => u.Company)
                        .Where(u => u.Age < 30));

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }

        public static void ShowIntersect()
        {
            Console.WriteLine("\n=> ShowIntersect()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users
                    .Include(u => u.Company)
                    .Where(u => u.Name!.Contains("Henry"))
                    .Intersect(db.Users
                        .Include(u => u.Company)
                        .Where(u => u.Age < 30));

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }

        public static void ShowExcept()
        {
            Console.WriteLine("\n=> ShowExcept()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users
                    .Include(u => u.Company)
                    .Where(u => u.Name!.Contains("Henry"))
                    .Except(db.Users
                        .Include(u => u.Company)
                        .Where(u => u.Age < 30));

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
