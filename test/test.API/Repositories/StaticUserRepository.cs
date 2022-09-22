using test.API.Models.Domain;

namespace test.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            //new User()
            //{
            //    FirstName = "Readonly",
            //    LastName = "User",
            //    EmailAddress = "readonly@user.com",
            //    Id = Guid.NewGuid(),
            //    Username = "readonly@user.com",
            //    Password = "Readonly@user",
            //    Roles = new List<String>{"reader"}
            //},
            //new User()
            //{
            //    FirstName = "Readwrite",
            //    LastName = "User",
            //    EmailAddress = "readwrite@user.com",
            //    Id = Guid.NewGuid(),
            //    Username = "readwrite@user.com",
            //    Password = "Readwrite@user",
            //    Roles = new List<String>{"reader", "writer"}
            //},
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)
            && x.Password.Equals(password));

            return user;
        }
    }
}
