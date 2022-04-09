using AggregateFunctions;
using AggregateFunctions.Models;

Console.WriteLine("***** Aggregate Functions *****");

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft" });
companies.Add(new Company { Title = "Yandex" });
companies.Add(new Company { Title = "Apple" });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", Age = 30, Company = companies[1] });
users.Add(new User { Name = "Marcus", Age = 45, Company = companies[1] });
users.Add(new User { Name = "Marc", Age = 32, Company = companies[0] });
users.Add(new User { Name = "Marc", Age = 19, Company = companies[2] });
users.Add(new User { Name = "Henry", Age = 40, Company = companies[0] });
users.Add(new User { Name = "Henry", Age = 20, Company = companies[2] });
users.Add(new User { Name = "Henry", Age = 36, Company = companies[0] });
users.Add(new User { Name = "Alice", Age = 27, Company = companies[1] });

Utils.CterateEmployeeDB(users, companies);
Utils.ShowAll();
Utils.ShowAny();
Utils.ShowAverage();
Utils.ShowCount();
Utils.ShowMax();
Utils.ShowMin();
Utils.ShowSum();