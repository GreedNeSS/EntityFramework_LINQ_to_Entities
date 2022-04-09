using IntroductionToLINQ;
using IntroductionToLINQ.Models;

Console.WriteLine("***** Introduction to LINQ to Entities *****");

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft" });
companies.Add(new Company { Title = "Apple" });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", CompanyId = 1 });
users.Add(new User { Name = "Marcus", CompanyId = 1 });
users.Add(new User { Name = "Henry", CompanyId = 2 });
users.Add(new User { Name = "Alice", CompanyId = 2 });

Utils.CterateEmployeeDB(users, companies);
Utils.ShowCompanyEmployees_LINQOperators(1);
Utils.ShowCompanyEmployees_LINQMethods(2);