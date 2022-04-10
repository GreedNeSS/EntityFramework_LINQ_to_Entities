using IEnumerableAndIQueryable;

Console.WriteLine("***** IEnumerable And IQueryable *****");

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
    Console.WriteLine("\n=> IEnumerable:\n");
    IEnumerable<User> userIEnum = db.Users;
    Console.WriteLine("userIEnum.GetType(): " + userIEnum.GetType().Name);
    var users = userIEnum.Where(u => u.Age < 35).ToList();
    Console.WriteLine("users.GetType(): " + users.GetType().Name);

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> IQuerible:\n");
    IQueryable<User> userIQuer = db.Users;
    Console.WriteLine("userIQuer.GetType(): " + userIQuer.GetType().Name);
    var users = userIQuer.Where(u => u.Age < 35).ToList();
    Console.WriteLine("users.GetType(): " + users.GetType().Name);

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> IQuerible:\n");
    IQueryable<User> userIQuer = db.Users;
    Console.WriteLine("userIQuer.GetType(): " + userIQuer.GetType().Name);
    userIQuer = userIQuer.Where(u => u.Age < 35);
    Console.WriteLine("userIQuer.GetType(): " + userIQuer.GetType().Name);
    userIQuer = userIQuer.Where(u => u.Id < 10);
    Console.WriteLine("userIQuer.GetType(): " + userIQuer.GetType().Name);
    var users = userIQuer.Where(u => u.Name == "GreedNeSS").ToList();
    Console.WriteLine("users.GetType(): " + users.GetType().Name);

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}