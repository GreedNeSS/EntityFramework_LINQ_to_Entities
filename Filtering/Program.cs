using Filtering;
using Filtering.Models;

Console.WriteLine("***** Filtering *****");

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft" });
companies.Add(new Company { Title = "Apple" });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", Age = 30, CompanyId = 1 });
users.Add(new User { Name = "Marcus", Age = 45, CompanyId = 1 });
users.Add(new User { Name = "Marc", Age = 32, CompanyId = 2 });
users.Add(new User { Name = "Henry", Age = 20, CompanyId = 2 });
users.Add(new User { Name = "Alice", Age = 27, CompanyId = 2 });

Utils.CterateEmployeeDB(users, companies);
Utils.ShowUsers(Utils.GetCompanyEmployees("Microsoft"));
Utils.ShowUsers(Utils.GetUsersByName("%Marc%"));
Utils.ShowUsers(Utils.GetUsersByAge("3_"));
User? user3 = Utils.GetUser(3);

if (user3 != null)
{
    Utils.ShowUser(user3);
}