using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public class InitializeMagazineController : ApiBaseController
    {
        // API/{MagazineId}/IsLatestForward/
        public bool IsLatestForward(int magazineId, string forwardHash)
        {
            return true;
        }

        // API/{MagazineId}/Forward/
        public string GetForward(int magazineId)
        {
            return string.Empty;
        }


        // API/{MagazineId}/IsLatestStylesheet/
        public bool IsLatestStylesheet(int magazineId, string stylesheetHash)
        {
            return true;
        }

        // API/{MagazineId}/Stylesheet/
        public string GetStylesheet(int magazineId)
        {
            return string.Empty;
        }


        // API/{MagazineId}/IsLatestAppStyle/
        public bool IsLatestAppStyle(int magazineId, string appStyleHash)
        {
            return true;
        }

        // API/{MagazineId}/AppStyle/
        public JsonResult GetAppStyle(int magazineId)
        {
            return new JsonResult();
        }
    }
}
