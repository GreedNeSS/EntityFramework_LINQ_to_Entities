using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregateFunctions.Models;
using Microsoft.EntityFrameworkCore;

namespace AggregateFunctions
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

        public static void ShowAny()
        {
            Console.WriteLine("\n=> ShowAny()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                bool isWorkingFromMicrosoft= db.Users.Any(u => u.Company!.Title == "Microsoft");

                Console.WriteLine($"db.Users.Any(u => u.Company!.Title == \"Microsoft\"): {isWorkingFromMicrosoft}");
            }
        }

        public static void ShowAll()
        {
            Console.WriteLine("\n=> ShowAll()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                bool isAllUsersWorkingFromMicrosoft = db.Users.All(u => u.Company!.Title == "Microsoft");

                Console.WriteLine($"db.Users.All(u => u.Company!.Title == \"Microsoft\"): {isAllUsersWorkingFromMicrosoft}");
            }
        }

        public static void ShowSum()
        {
            Console.WriteLine("\n=> ShowSum()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                int sum = db.Users.Where(u => u.Company!.Title == "Yandex").Sum(u => u.Age);

                Console.WriteLine($"db.Users.Where(u => u.Company!.Title == \"Yandex\").Sum(u => u.Age): {sum}");
            }
        }

        public static void ShowCount()
        {
            Console.WriteLine("\n=> ShowCount()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                int count = db.Users.Where(u => u.Company!.Title == "Yandex").Count();

                Console.WriteLine($"db.Users.Where(u => u.Company!.Title == \"Yandex\").Count(): {count}");
            }
        }

        public static void ShowMin()
        {
            Console.WriteLine("\n=> ShowMin()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                int minAge = db.Users.Where(u => u.Company!.Title == "Apple").Min(u => u.Age);

                Console.WriteLine($"db.Users.Where(u => u.Company!.Title == \"Apple\").Min(u => u.Age): {minAge}");
            }
        }

        public static void ShowMax()
        {
            Console.WriteLine("\n=> ShowMax()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                int maxAge = db.Users.Where(u => u.Company!.Title == "Microsoft").Max(u => u.Age);

                Console.WriteLine($"db.Users.Where(u => u.Company!.Title == \"Microsoft\").Max(u => u.Age): {maxAge}");
            }
        }

        public static void ShowAverage()
        {
            Console.WriteLine("\n=> ShowAverage()\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                double avgAge = db.Users.Average(u => u.Age);

                Console.WriteLine($"db.Users.Average(u => u.Age): {avgAge}");
            }
        }
    }
}
