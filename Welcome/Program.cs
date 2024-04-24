using Weclome.Others;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            user.Name = "Desislava";
            user.Password = "12345";
            user.Role = UserRolesEnum.ADMIN;
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            Console.ReadKey();

        }
    }
}
    