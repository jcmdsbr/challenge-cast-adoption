using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGA.Infra.CrossCutting.Messages;
using System;

namespace SGA.UI.Site.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        protected const string ErrorNotifications = "ErrorNotifications";
        protected const string Success = "Success";

        protected IActionResult SafeResultResponse(Func<IActionResult> action, Func<IActionResult> err)
        {
            try
            {
                return action?.Invoke();
            }
            catch (Exception e)
            {
                NotifyError(string.Format(Message.MS_003));

                return err();
            }
        }


        protected void NotifyError(string message)
        {
            TempData[ErrorNotifications] = message;
        }

        protected void NotifySucess()
        {
            TempData[Success] = Message.MS_001;
        }

        protected IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        protected void KeepErrorNotifications()
        {
            if (TempData != null && TempData.ContainsKey(ErrorNotifications))
                TempData.Keep(ErrorNotifications);

        }
    }
}