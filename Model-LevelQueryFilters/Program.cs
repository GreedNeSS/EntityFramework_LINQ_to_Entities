using Model_LevelQueryFilters;
using Model_LevelQueryFilters.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Model-Level Query Filters *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Role user = new Role { Name = "User"};
    Role admin = new Role { Name = "Admin"};
    User greedness = new User { Name = "GreedNeSS", Role = admin, Age = 30 };
    User marcus = new User { Name = "Marcus", Role = admin, Age = 45 };
    User tom = new User { Name = "Tom", Role = user, Age = 12 };
    User alice = new User { Name = "Alice", Role = user, Age = 24 };

    db.Roles.AddRange(user, admin);
    db.Users.AddRange(greedness, marcus, tom, alice);
    db.SaveChanges();
}

ShowUsers(1);
ShowUsers(2);

void ShowUsers(int roleId)
{
    using (ApplicationContext db = new ApplicationContext() { RoleId = roleId })
    {
        Console.WriteLine("\n=> new ApplicationContext() { RoleId = 1}:\n");

        foreach (var user in db.Users.Include(u => u.Role))
        {
            Console.WriteLine(user);
        }
    }
}