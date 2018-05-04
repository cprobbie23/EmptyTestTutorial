using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Shouldly;
using Spike_TESTS.Controllers;
using Spike_TESTS.Models;
using Spike_TESTS.Repositories;
using Spike_TESTS.Services;
using Spike_TESTS.Tests.Unit.Infrastructure;

namespace Spike_TESTS.Tests.Unit
{
    [TestFixture]
    public class when_getting_the_list_of_users
    {
        private List<User> _result;
        private List<User> _expectedList;

        [Test]
        public void should_return_the_correct_user()
        {
            _expectedList = new List<User>
            {
                new User
                {
                    FirstName = "BRobbie",
                    LastName = "Cheng"
                },
                new User
                {
                    FirstName = "AMike",
                    LastName = "Tomras"
                }
            };
            var repo = new Mock<IUserRepository>();
            repo.Setup(a => a.GetAllUsers()).Returns(_expectedList);

            var SUT = new UserService(repo.Object);
            _result = SUT.GetUsers();

            _result.Count.ShouldBe(_expectedList.Count);            
        }

        [Test]
        public void should_order_by_first_name()
        {
            _expectedList = new List<User>
            {
                new User
                {
                    FirstName = "BRobbie",
                    LastName = "Cheng"
                },
                new User
                {
                    FirstName = "AMike",
                    LastName = "Tomras"
                }
            };
            var repo = new Mock<IUserRepository>();
            repo.Setup(a => a.GetAllUsers()).Returns(_expectedList);

            var SUT = new UserService(repo.Object);
            _result = SUT.GetUsers();

            _expectedList.OrderBy(a => a.FirstName).First().FirstName.ShouldBe(_result.First().FirstName);
        }

        [Test]
        public void should_only_return_the_top_10_users_if_there_are_more()
        {
            _expectedList = new Fixture().CreateMany<User>(100).ToList();
            var repo = new Mock<IUserRepository>();
            repo.Setup(a => a.GetAllUsers()).Returns(_expectedList);

            var SUT = new UserService(repo.Object);
            _result = SUT.GetUsers();

            _result.Count.ShouldBe(10);
        }
    }

}
