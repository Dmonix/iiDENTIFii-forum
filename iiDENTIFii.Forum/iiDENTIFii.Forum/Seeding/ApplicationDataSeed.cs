using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;
using Microsoft.AspNetCore.Identity;

namespace iiDENTIFii.Forum.Seeding
{
    public class ApplicationDataSeed
    {
        private readonly DatabaseContext db;
        private readonly IPostService postService;

        public ApplicationDataSeed(DatabaseContext db, IPostService postService)
        {
            this.db = db;
            this.postService = postService;
        }

        public async Task SeedData(UserManager<User> userManager)
        {
            var users = GenerateLists.GetUsers();

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "no_3ntrY");
                await userManager.CreateAsync(user, "no_3ntrY");
                await userManager.CreateAsync(user, "no_3ntrY");
                await userManager.CreateAsync(user, "no_3ntrY");
            }

            var checkPosts = postService.GetPosts();
            if (checkPosts != null && checkPosts.Count > 0)
            {
                return;
            }

            var firstPost = new Post()
            {
                Title = "SOLID Part 1: Single-responsibility Principle",
                Content = "A class should have one and only one reason to change, meaning that a class should only have one job",
                Author = users[1],
                CreatedDate = DateTime.Parse("2024 - 07 - 06T20: 59:37.6237278Z"),
            };

            var secondPost = new Post()
            {
                Title = "SOLID Part 2: Open-Closed Principle",
                Content = "Objects or entities should be open for extension but closed for modification",
                Author = users[1],
            };

            var thirdPost = new Post()
            {
                Title = "SOLID Part 3: Liskov Substitution Principle",
                Content = "Let q(x) be a property provable about objects of x of type T. Then q(y) should be provable for objects of y of type S where S is a subtype of T",
                Author = users[1],
            };

            var fourthPost = new Post()
            {
                Title = "SOLID Part 4: Interface Segregation Principle",
                Content = "A client should never be forced to implement an interface that it doesn’t use, or clients shouldn’t be forced to depend on methods they do not use.",
                Author = users[1],
            };

            var fifthPost = new Post()
            {
                Title = "SOLID Part 5: Dependency Inversion Principle",
                Content = "Entities must depend on abstractions, not on concretions. It states that the high-level module must not depend on the low-level module, but they should depend on abstractions",
                Author = users[1],
            };

            var sixthPost = new Post()
            {
                Title = "SOLID Additional",
                Content = "SOLID is only for OOP systems",
                Author = users[1]
            };

            firstPost = postService.AddPost(firstPost);
            secondPost = postService.AddPost(secondPost);
            thirdPost = postService.AddPost(thirdPost);
            fourthPost = postService.AddPost(fourthPost);
            fifthPost = postService.AddPost(fifthPost);
            sixthPost = postService.AddPost(sixthPost);

            postService.LikePost(secondPost.Id, users[2]);
            postService.LikePost(thirdPost.Id, users[2]);

            var comment = new PostComment()
            {
                Content = "First"
            };

            postService.AddComment(firstPost.Id, comment);

            postService.TagPost(sixthPost.Id, users[3]);
        }
    }

    public static class GenerateLists
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>();
            users.Add(
                new User()
                {
                    DisplayName = "Donald",
                    UserName = "donald@gmail.com",
                    Email = "donald@gmail.com",
                    IsModerator = true,
                });

            users.Add(
                new User()
                {
                    Email = "arthur@gmail.com",
                    UserName = "arthur@gmail.com",
                    DisplayName = "Arthur",
                    IsModerator = false
                });

            users.Add(
                new User()
                {
                    Email = "luke@gmail.com",
                    UserName = "luke@gmail.com",
                    DisplayName = "Luke",
                    IsModerator = false
                });

            users.Add(
                new User()
                {
                    Email = "martin@gmail.com",
                    UserName = "martin@gmail.com",
                    DisplayName = "Martin",
                    IsModerator = true
                });

            return users;
        }
    }
}