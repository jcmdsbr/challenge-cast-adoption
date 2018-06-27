using Microsoft.AspNetCore.Mvc;
using SGA.Application.Domain.Pet;

namespace SGA.UI.Site.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPetQuery _petQuery;
        public HomeController(IPetQuery petQuery)
        {
            _petQuery = petQuery;
        }
        public IActionResult Index() => SafeResult(() => View(_petQuery.GetPetsNotAdopted()));
    }
}