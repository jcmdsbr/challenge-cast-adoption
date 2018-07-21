using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGA.Infra.CrossCutting.Messages;
using System;

namespace SGA.UI.Site.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IActionResult SafeResultResponse(Func<IActionResult> action, Func<IActionResult> err)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception e)
            {
                NotifyError(String.Format(Message.MS_003, e.StackTrace));

                return err();
            }
        }


        protected void NotifyError(string message)
        {
            TempData["ErrorNotifications"] = message;
        }

        protected void NotifySucess()
        {
            TempData["Success"] = Message.MS_001;
        }
    }
}