using System;
using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class PoorMethodSignatures
    {
        public void Run()
        {
            var userService = new UserService();

            var user = userService.GetUser("username", true, "password");
            var anotherUser = userService.GetUser("username", false);
        }
    }

    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

        public User GetUser(string username, bool login, string password = "")
        {
            return login ? GetUserByPassword(username, password) : GetUserByUsername(username);
        }

        private User GetUserByUsername(string username)
        {
            var userDb = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            if (userDb != null)
                return userDb;
            return new User();
        }

        private User GetUserByPassword(string username, string password)
        {
            var userDb = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (userDb != null)
            {
                userDb.LastLogin = DateTime.Now;
                return userDb;
            }
            return new User();
        }
    }

    public class UserDbContext : DbContext
    {
        public IQueryable<User> Users { get; set; }
    }

    public class DbSet<T>
    {
    }

    public class DbContext
    {
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
