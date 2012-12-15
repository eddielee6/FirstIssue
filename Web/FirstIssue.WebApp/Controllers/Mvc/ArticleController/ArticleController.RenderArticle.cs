using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using FirstIssue.WebApp.AppCode.ExtensionMethods;

using System.Data.Entity;

using System.Text.RegularExpressions;

using FirstIssue.WebApp.Models.Azure;

namespace FirstIssue.WebApp.Controllers
{
    public partial class ArticleController
    {
        public virtual ViewResult RenderArticle()
        {

            return View();
        }

        public virtual ContentResult RenderCSS()
        {
            var style = _dbContext.MagazineStyles.First();

            var stylesheet = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Content.Resources.MagazineTemplate.css");

            //General
            stylesheet = stylesheet.Replace("/*_BACKGROUND-COLOUR_*/", style.BackgroundColour);

            //Body
            stylesheet = stylesheet.Replace("/*_BODY-FONT-FAMILY_*/", style.BodyStyle.Font.Name);
            stylesheet = stylesheet.Replace("/*_BODY-FONT-COLOUR_*/", style.BodyStyle.FontColour);
            stylesheet = stylesheet.Replace("/*_BODY-FONT-SIZE_*/", string.Format("{0}em", style.BodyStyle.FontSize));

            //Title
            stylesheet = stylesheet.Replace("/*_TITLE-FONT-FAMILY_*/", style.TitleStyle.Font.Name);
            stylesheet = stylesheet.Replace("/*_TITLE-FONT-COLOUR_*/", style.TitleStyle.FontColour);
            stylesheet = stylesheet.Replace("/*_TITLE-FONT-SIZE_*/", string.Format("{0}em", style.TitleStyle.FontSize));

            //Subtitle
            stylesheet = stylesheet.Replace("/*_SUBTITLE-FONT-FAMILY_*/", style.SubTitleStyle.Font.Name);
            stylesheet = stylesheet.Replace("/*_SUBTITLE-FONT-COLOUR_*/", style.SubTitleStyle.FontColour);
            stylesheet = stylesheet.Replace("/*_SUBTITLE-FONT-SIZE_*/", string.Format("{0}em", style.SubTitleStyle.FontSize));

            //Byline
            stylesheet = stylesheet.Replace("/*_BYLINE-FONT-FAMILY_*/", style.ByLineStyle.Font.Name);
            stylesheet = stylesheet.Replace("/*_BYLINE-FONT-COLOUR_*/", style.ByLineStyle.FontColour);
            stylesheet = stylesheet.Replace("/*_BYLINE-FONT-SIZE_*/", string.Format("{0}em", style.ByLineStyle.FontSize));

            return Content(stylesheet, "text/css");
        }
    }
}
