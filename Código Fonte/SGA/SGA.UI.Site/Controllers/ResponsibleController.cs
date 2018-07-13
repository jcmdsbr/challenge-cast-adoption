using Microsoft.AspNetCore.Mvc;
using SGA.Application.Domain.Commands;
using SGA.Application.UI.Models;

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
            if (!ModelState.IsValid) return View(model);

            _command.Execute(model);

            if (!_command.HasErrors())
            {
                NotifySucess();

                return RedirectToAction(nameof(Index), "Home");
            }

            NotifyError(string.Join(",", _command.GetErrors()));

            return View(model);
        }
    }
}