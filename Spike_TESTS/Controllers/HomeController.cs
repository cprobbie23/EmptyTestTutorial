using System.Collections.Generic;
using System.Web.Mvc;
using Spike_TESTS.App_Data;
using Spike_TESTS.Models;
using Spike_TESTS.Services;
//using spike_tests.app_data;

namespace Spike_TESTS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            var userService = new UserService();
            viewModel.Users = userService.ListUsers();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(HomeViewModel model)
        {
            return null;
        }
    }

    public class HomeViewModel
    {

        //For the list
        public IEnumerable<User> Users { get; set; }

        //For the form
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    
}