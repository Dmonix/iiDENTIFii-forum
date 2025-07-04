using iiDENTIFii.Forum.Models;
using Microsoft.AspNetCore.Identity;

namespace iiDENTIFii.Forum.Seeding
{
    public class ApplicationDataSeed
    {
        private readonly DatabaseContext db;

        public ApplicationDataSeed(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task SeedData(UserManager<User> userManager) 
        {
            var modUser = new User()
            {
                DisplayName = "Donald",
                UserName = "donald@gmail.com",
                Email = "donald@gmail.com",
                IsModerator = true,
            };

            var standardUser = new User()
            {
                DisplayName = "Tim",
                UserName = "tim@gmail.com",
                Email = "tim@gmail.com",
                IsModerator = false,
            };

            await userManager.CreateAsync(modUser, "no_3ntrY");
            await userManager.CreateAsync(standardUser, "no_3ntrY");
        }
    }
}