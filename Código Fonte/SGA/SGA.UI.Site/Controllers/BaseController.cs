using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGA.Infra.CrossCutting.Messages;
using System;

namespace SGA.UI.Site.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IActionResult SafeResult(Func<IActionResult> action)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception)
            {

                TempData["ErrorNotifications"] = Message.MS_003;

                return NotFound();
            }
        }
    }
}