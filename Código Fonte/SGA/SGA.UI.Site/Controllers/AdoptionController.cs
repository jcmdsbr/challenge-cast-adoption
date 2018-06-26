using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.Domain.Adoption;
using SGA.Application.Domain.Responsible;

namespace SGA.UI.Site.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAdoptionQuery _query;


        public AdoptionController(IAdoptionQuery query)
        {
            _query = query;
        }
        public IActionResult Index() => View(_query.GetReponsablesAndTheirAdoptions());

        public IActionResult Adoption(Guid id)
        {
            return null;
        }
    }
}