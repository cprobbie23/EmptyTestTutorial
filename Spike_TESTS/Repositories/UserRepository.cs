using Spike_TESTS.Models;
using System.Collections.Generic;

namespace Spike_TESTS.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public void Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserRepository
    {
        List<User> GetAllUsers();
        void Save(User user);
    }
}