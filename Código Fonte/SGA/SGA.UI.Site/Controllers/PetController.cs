using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.Domain.Pet;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Models;
using System;
using System.Linq;

namespace SGA.UI.Site.Controllers
{
    public class PetController : BaseController
    {
        private readonly IPetQuery _petQuery;

        private readonly IRegisterNewPetCommand _command;


        public PetController(IPetQuery petQuery, IRegisterNewPetCommand command)
        {
            _petQuery = petQuery;
            _command = command;
        }
        public IActionResult Index()
        {
            return SafeResult(() =>
            {
                ViewBag.TypePetId = _petQuery.GetTypeAnimals().Select(PopularItens());

                return View(new PetViewModel());
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PetViewModel model)
        {
            return SafeResult(() =>
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.TypePetId = _petQuery.GetTypeAnimals().Select(PopularItens());
                    return View(model);
                }

                _command.Execute(model);

                if (!_command.HasErrors())
                {
                    TempData["Success"] = Message.MS_001;
                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewBag.TypePetId = _petQuery.GetTypeAnimals().Select(PopularItens());
                TempData["ErrorNotifications"] = string.Join(",", _command.GetErrors());

                return View(model);
            });

        }

        private static Func<TypePet, SelectListItem> PopularItens() => x => new SelectListItem { Value = x.Id.ToString(), Text = x.Description };
    }
}