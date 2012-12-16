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
        public virtual ActionResult StyleMagazine()
        {
            var viewModel = new StyleCreatorViewModel();
            viewModel.DefaultStyles = _dbContext.DefaultStyles;
            return View(viewModel);
        }

    }
}
