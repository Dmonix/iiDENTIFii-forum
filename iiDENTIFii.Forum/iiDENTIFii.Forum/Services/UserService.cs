using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext db;

        public UserService(DatabaseContext databaseContext)
        {
            this.db = databaseContext;
        }

        public User GetUser(string email)
        {
            return db.Users.Single(user  => user.Email == email);
        }
    }
}