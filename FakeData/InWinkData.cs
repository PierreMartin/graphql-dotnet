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

        public InWinkData()
        {
            _users.Add(new User
            {
                Id = "1",
                FirstName = "Luke",
                LastName = "toto"
            });
            _users.Add(new User
            {
                Id = "2",
                FirstName = "Vader",
                LastName = "titi"
            });
        }

        public User GetUsers()
        {
            // return _users.ToList(); TODO finir ca !!
            return null;
        }

        public Task<User> GetUserByIdAsync(string id)
        {
            return Task.FromResult(_users.FirstOrDefault(h => h.Id == id));
        }

        public User AddPost(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);

            return user;
        }
    }
}
