using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.Domain.Pet;

namespace SGA.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetQuery _petQuery;

        public HomeController(IPetQuery petQuery)
        {
            _petQuery = petQuery;
        }
        public IActionResult Index()
        {
            return View(_petQuery.GetPetsNotAdopted());
        }
    }
}