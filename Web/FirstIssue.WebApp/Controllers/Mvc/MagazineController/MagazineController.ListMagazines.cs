using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public partial class MagazineController
    {
        /// <summary>
        /// Lists Magazines for logged in user
        /// </summary>        
        public virtual ViewResult ListMagazines()
        {

            return View();
        }
    }
}
