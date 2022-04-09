using SortingAndProjection;
using SortingAndProjection.Models;

Console.WriteLine("***** Sorted and Projection from Database *****");

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft" });
companies.Add(new Company { Title = "Apple" });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", Age = 30, CompanyId = 1 });
users.Add(new User { Name = "Marcus", Age = 45, CompanyId = 1 });
users.Add(new User { Name = "Marc", Age = 32, CompanyId = 2 });
users.Add(new User { Name = "Marc", Age = 22, CompanyId = 1 });
users.Add(new User { Name = "Henry", Age = 40, CompanyId = 2 });
users.Add(new User { Name = "Henry", Age = 20, CompanyId = 1 });
users.Add(new User { Name = "Henry", Age = 36, CompanyId = 2 });
users.Add(new User { Name = "Alice", Age = 27, CompanyId = 1 });

Utils.CterateEmployeeDB(users, companies);
List<UserModel> userModels = Utils.GetAllUserModels(Utils.GetAllUser());
Utils.ShowUserModels(userModels);
Utils.ShowUserModels(Utils.OrderedUserModelsByName(userModels));
Utils.ShowUserModels(Utils.OrderedUserModelsByNameAndAge(userModels));