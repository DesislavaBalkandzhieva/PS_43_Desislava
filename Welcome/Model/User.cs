using Weclome.Others;

namespace Welcome.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
    }
}
