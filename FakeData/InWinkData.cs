using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfiniteSquare_InWink_GraphQl.Models;

namespace InfiniteSquare_InWink_GraphQl.FakeData
{
    public class InWinkData
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<Post> _posts = new List<Post>();

        public InWinkData()
        {
            // users:
            _users.Add(new User{
                Id = "1",
                FirstName = "Luke",
                LastName = "toto"
            });
            _users.Add(new User{
                Id = "2",
                FirstName = "Vader",
                LastName = "titi"
            });
            _users.Add(new User{
                Id = "3",
                FirstName = "Pierre",
                LastName = "Martin"
            });

            // posts:
            _posts.Add(new Post{
                Id = "1",
                Content = "Post 1 sddsdsds msdsmdlsdmds sdldslsdmsdlmds "
            });
            _posts.Add(new Post{
                Id = "2",
                Content = "Post 2"
            });
            _posts.Add(new Post{
                Id = "3",
                Content = "Post 3"
            });
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.ToList();
        }

        public IEnumerable<Post> GetPosts()
        {
            return _posts.ToList();
        }

        public Task<User> GetUserByIdAsync(string id)
        {
            return Task.FromResult(_users.FirstOrDefault(h => h.Id == id));
        }

        public Task<Post> GetPostsByIdAsync(string id)
        {
            return Task.FromResult(_posts.FirstOrDefault(h => h.Id == id));
        }

        public User AddPost(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);

            return user;
        }
    }
}
