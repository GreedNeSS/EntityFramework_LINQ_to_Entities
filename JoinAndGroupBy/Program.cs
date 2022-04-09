using JoinAndGroupBy;
using JoinAndGroupBy.Models;

Console.WriteLine("***** Join and GroupBy Table *****");

List<Country> countries = new List<Country>();
countries.Add(new Country { Name = "Russia" });
countries.Add(new Country { Name = "USA" });

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft", Country = countries[1] });
companies.Add(new Company { Title = "Yandex", Country = countries[0] });
companies.Add(new Company { Title = "Apple", Country = countries[1] });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", Age = 30, Company = companies[1] });
users.Add(new User { Name = "Marcus", Age = 45, Company = companies[1] });
users.Add(new User { Name = "Marc", Age = 32, Company = companies[0] });
users.Add(new User { Name = "Marc", Age = 22, Company = companies[2] });
users.Add(new User { Name = "Henry", Age = 40, Company = companies[0] });
users.Add(new User { Name = "Henry", Age = 20, Company = companies[2] });
users.Add(new User { Name = "Henry", Age = 36, Company = companies[0] });
users.Add(new User { Name = "Alice", Age = 27, Company = companies[1] });

Utils.CterateEmployeeDB(users, companies, countries);
Utils.ShowEmployeeInfo();
Utils.ShowEmployeeInfo_Alternate();
Utils.ShowGroupingByCompany();
Utils.ShowGroupingByCompany_Alternate();