using ChangeTrackerAndAsNoTracking;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** ChangeTracker And AsNoTracking *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    User greedNess = new User { Name = "GreedNeSS", Age = 30 };
    User marcus = new User { Name = "Marcus", Age = 45 };
    User tom = new User { Name = "Tom", Age = 22 };
    User terry = new User { Name = "Terry", Age = 36 };

    db.Users.AddRange(greedNess, marcus, tom, terry);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    User? user = db.Users.AsNoTracking().FirstOrDefault();

    if (user != null)
    {
        user.Age = 12;
        db.SaveChanges();
    }

    Console.WriteLine("\n=>db.Users.AsNoTracking().FirstOrDefault()\n");
    var users = db.Users.ToList();

    foreach (var u in users)
    {
        Console.WriteLine(u);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    User? user = db.Users.FirstOrDefault();

    if (user != null)
    {
        user.Age = 12;
        db.SaveChanges();
    }

    Console.WriteLine("\n=> db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking\n");
    var users = db.Users.ToList();

    foreach (var u in users)
    {
        Console.WriteLine(u);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> \n");
    var users = db.Users.ToList();

    foreach (var u in users)
    {
        Console.WriteLine(u);
    }

    int count = db.ChangeTracker.Entries().Count();

    Console.WriteLine($"\n=> db.ChangeTracker.Entries().Count() = {count}");
}