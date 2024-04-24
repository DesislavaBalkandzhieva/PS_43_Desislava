using DataLayer.Database;
using DataLayer.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "User",
                    Password = "password",
                    Role = Weclome.Others.UserRolesEnum.ANONYMOUS
                });

                context.SaveChanges();
                var users = context.Users.ToList();
                Console.ReadKey();
            }
        }
    }
}
