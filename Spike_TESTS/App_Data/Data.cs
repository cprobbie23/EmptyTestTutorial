using System.Collections.Generic;
using Ploeh.AutoFixture;
using Spike_TESTS.Models;

namespace Spike_TESTS.App_Data
{
    public static class Data
    {
        // this is a class constant, call it by Data.Users
        public static IEnumerable<User> Users => new Fixture().CreateMany<User>(100);
    }
}