using System.Collections.Generic;
using System.Web.Mvc;
using Spike_TESTS.Models;
using Spike_TESTS.Services;
//using spike_tests.app_data;

namespace Spike_TESTS.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        public ActionResult Index()
        {
            var model = _userService.GetUsers();

            return View(new HomeViewModel {
                List = model
            });
        }

        [HttpPost]
        public ActionResult Save(NewUserViewModel model)
        {
            _userService.Save(new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            });
            return null;
        }
    }

    public class HomeViewModel
    {
        public object List { get; set; }
    }

    public class NewUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


}