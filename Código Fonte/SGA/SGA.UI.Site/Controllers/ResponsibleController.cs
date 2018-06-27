using Microsoft.AspNetCore.Mvc;
using SGA.Application.Domain.Responsible;
using SGA.Domain.Entities.Models;
using SGA.Infra.CrossCutting.Messages;
using SGA.UI.Site.Models;

namespace SGA.UI.Site.Controllers
{
    public class ResponsibleController : BaseController
    {
        private readonly IRegisterNewResponsibleCommand _command;


        public ResponsibleController(IRegisterNewResponsibleCommand command)
        {
            _command = command;
        }
        public IActionResult Index()
        {
            return View(new ResponsibleViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ResponsibleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _command.Execute(model);

            if (!_command.HasErrors())
            {
                TempData["Success"] = Message.MS_001;
                return RedirectToAction(nameof(Index), "Home");
            }

            TempData["ErrorNotifications"] = string.Join(",", _command.GetErrors());

            return View(model);

        }
    }
}