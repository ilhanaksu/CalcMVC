using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Extensions
{
    public static class Extensions
    {
        public static MvcHtmlString MyValidationSummary(this HtmlHelper helper, string validationMessage = "")
        {
            StringBuilder retVal = new StringBuilder();
            if (helper.ViewData.ModelState.IsValid)
                return MvcHtmlString.Create("");

            retVal.Append("<div class = 'alert alert-danger alert-dismissable'>");
            retVal.Append("<button type = 'button' class = 'close' data-dismiss = 'alert' aria-hidden = 'true'> &times; </button>");
            if (!String.IsNullOrEmpty(validationMessage))
                  retVal.Append(helper.Encode(validationMessage));
           
            foreach (var key in helper.ViewData.ModelState.Keys)
            {
                retVal.Append("<ul>");
                foreach (var err in helper.ViewData.ModelState[key].Errors)
                    retVal.Append("<li  style='list-style-type: none;'>" + helper.Encode(err.ErrorMessage) + "</li>");
                retVal.Append("</ul>");
            }
            retVal.Append("</div>");
            return MvcHtmlString.Create(retVal.ToString());
        }
    }
}