using Microsoft.EntityFrameworkCore;
using test.API.Data;
using test.API.Models.Domain;

namespace test.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly testDbContext testDbContext;

        public UserRepository(testDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await testDbContext.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower()
            && x.Password == password);
            if (user == null)
            {
                return null;
            }

            var userRoles = await testDbContext.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await testDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
