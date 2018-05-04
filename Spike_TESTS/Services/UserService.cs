using Spike_TESTS.Models;
using Spike_TESTS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spike_TESTS.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        void Save(User user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;

        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<User> GetUsers()
        {
            return userRepo.GetAllUsers()
                    .OrderBy(a => a.FirstName)
                    .Take(10)
                    .ToList();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }
    }    
}