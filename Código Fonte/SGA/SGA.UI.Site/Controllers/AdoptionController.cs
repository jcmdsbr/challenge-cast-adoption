using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.Domain.Adoption;
using SGA.Application.Domain.Pet;
using SGA.Application.Domain.Responsible;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Models;
using System;
using System.Linq;

namespace SGA.UI.Site.Controllers
{
    public class AdoptionController : BaseController
    {
        private readonly IAdoptionQuery _adoptionQuery;
        private readonly IPetQuery _petQuery;
        private readonly IResponsibleQuery _responsibleQuery;
        private readonly IRegisterNewAdoptionCommand _command;

        public AdoptionController(IAdoptionQuery adoptionQuery, IPetQuery petQuery, IResponsibleQuery responsibleQuery, IRegisterNewAdoptionCommand command)
        {
            _adoptionQuery = adoptionQuery;
            _petQuery = petQuery;
            _responsibleQuery = responsibleQuery;
            _command = command;
        }
        public IActionResult Index() => View(_adoptionQuery.GetReponsablesAndTheirAdoptions());

        [HttpGet]
        public IActionResult ToAdopt(Guid id) => SafeResult(() =>
        {
            ViewBag.Pets = _petQuery.GetPetsNotAdopted().Select(PopularItens());

            return View((AdoptionViewModel)_adoptionQuery.FindReponsableAndTheirAdoptionsBy(x => x.Id == id));
        });

        [HttpPost]
        public IActionResult ToAdopt(AdoptionViewModel model)
        {

            return SafeResult(() =>
            {
                if (!model.Pets.Any())
                {
                    TempData["ErrorNotifications"] = Message.MS_008;
                    return RedirectToAction(nameof(ToAdopt), model.Responsible.Id);
                }
                _command.Execute(model);

                if (!_command.HasErrors())
                {
                    TempData["Success"] = Message.MS_001;
                    return RedirectToAction(nameof(Index), "Home");
                }

                TempData["ErrorNotifications"] = string.Join(",", _command.GetErrors());
                return RedirectToAction(nameof(ToAdopt), model.Responsible.Id);
            });
        }

        private static Func<Domain.Entities.Models.Pet, SelectListItem> PopularItens() => x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name };
    }

}