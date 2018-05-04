using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Shouldly;
using Spike_TESTS.Controllers;
using Spike_TESTS.Models;
using Spike_TESTS.Repositories;
using Spike_TESTS.Services;
using Spike_TESTS.Tests.Unit.Infrastructure;

namespace Spike_TESTS.Tests.Unit
{
    [TestFixture]
    public class when_getting_the_main_page
    {
        private ActionResult _result;
        private List<User> _expectedUsers;
        private List<User> _newUsers;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _expectedUsers = new List<User>();
            var userService = new Mock<IUserService>();
            userService.Setup(a => a.GetUsers()).Returns(_expectedUsers);
            var SUT = new HomeController(userService.Object);

            //Act
            _result = SUT.Index();
        }

        [Test]
        public void should_get_the_correct_view()
        {
            //Assert
            _result.ViewShouldBe(ActionResultExtension.DefaultMVCViewName);
        }

        [Test]
        public void should_return_a_list_of_users()
        {
            _result.Model<HomeViewModel>().List.ShouldBe(_expectedUsers);
        }

        
    }

    [TestFixture]
    public class when_saving_a_new_user
    {
        private NewUserViewModel _newUser;

        [Test]
        public void should_save_the_new_user()
        {
            // Arrange 
            _newUser = new NewUserViewModel()
            {                
                FirstName = "Cath",
                LastName = "K"                
            };

            User actualUser = new User();
            var userService = new Mock<IUserService>();
            userService.Setup(a => a.Save(It.IsAny<User>())).Callback<User>(user => actualUser = user);

            var SUT = new HomeController(userService.Object);
            SUT.Save(_newUser);

            //userService.Verify(a => a.Save(It.Is<User>(user => 
            //    user.FirstName == _newUser.FirstName &&
            //    user.LastName== _newUser.LastName
            //    )));

            actualUser.FirstName.ShouldBe(_newUser.FirstName);
        }
    }
}
