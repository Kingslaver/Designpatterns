using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        ILogger _logger = null;

        public BaseController()
        {
            _logger = Log.GetLogger;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _logger.LogMessage(filterContext.Exception);
        }
    }
}