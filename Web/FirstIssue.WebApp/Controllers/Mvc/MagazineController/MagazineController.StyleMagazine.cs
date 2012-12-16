using FirstIssue.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public partial class MagazineController
    {
        public virtual ActionResult StyleCreator()
        {
            var viewModel = new StyleCreatorViewModel();
            viewModel.PrebuiltStyles = _dbContext.PrebuiltStyles;
            return View(viewModel);
        }

        public virtual JsonResult GetPrebuiltStyle(int prebuiltStyleId)
        {
            return Json(_dbContext.PrebuiltStyles.
                Include("TitleStyle").
                Include("TitleStyle.Font").
                Include("SubTitleStyle").
                Include("SubTitleStyle.Font").
                Include("BodyStyle").
                Include("BodyStyle.Font").
                Include("ByLineStyle").
                Include("ByLineStyle.Font").
                Single(s => s.PrebuiltStyleID == prebuiltStyleId));
        }
    }
}
