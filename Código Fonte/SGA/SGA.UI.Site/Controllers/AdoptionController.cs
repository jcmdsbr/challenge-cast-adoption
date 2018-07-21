using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.Domain.Commands;
using SGA.Application.Domain.Queries;
using SGA.Application.UI.Models;
using SGA.Infra.CrossCutting.Messages;
using System;
using System.Linq;

namespace SGA.UI.Site.Controllers
{
    public class AdoptionController : BaseController
    {
        private readonly IAdoptionQuery _adoptionQuery;
        private readonly IRegisterNewAdoptionCommand _command;
        private readonly IPetQuery _petQuery;

        public AdoptionController(IAdoptionQuery adoptionQuery, IPetQuery petQuery, IRegisterNewAdoptionCommand command)
        {
            _adoptionQuery = adoptionQuery;
            _petQuery = petQuery;
            _command = command;
        }

        public IActionResult Index()
        {
            return View(_adoptionQuery.GetReponsablesAndTheirAdoptions());
        }

        [HttpGet]
        public IActionResult ToAdopt(Guid id)
        {
            return SafeResultResponse(() =>
            {
                var petsNotAdopted = _petQuery.GetPetsNotAdopted();

                if (!petsNotAdopted.Any())
                {
                    NotifyError(Message.MS_004);

                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewBag.Pets = petsNotAdopted.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

                return View((AdoptionViewModel)_adoptionQuery.FindReponsableAndTheirAdoptionsBy(id));

            }, err: () => RedirectToAction(nameof(Index)));
        }

        [HttpPost]
        public IActionResult ToAdopt(AdoptionViewModel model)
        {
            return SafeResultResponse(() =>
            {
                if (!model.Pets.Any())
                {
                    NotifyError(Message.MS_008);

                    return RedirectToAction(nameof(ToAdopt), model.Responsible.Id);
                }

                _command.Execute(model);

                if (!_command.HasErrors())
                {
                    NotifySucess();

                    return RedirectToAction(nameof(Index), "Home");
                }

                NotifyError(string.Join(",", _command.GetErrors()));

                return RedirectToAction(nameof(ToAdopt), model.Responsible.Id);

            }, err: () => RedirectToAction(nameof(Index)));
        }
    }
}