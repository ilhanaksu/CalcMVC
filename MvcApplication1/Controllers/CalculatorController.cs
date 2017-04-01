using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
      [Authorize]
    public class CalculatorController : Controller
    {
       
        public ActionResult Index()
        {
            CalculatorModel model = new CalculatorModel();
            
            return View(model);
        }

      
        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
           model.result =  Convert.ToDouble(new DataTable().Compute(model.FullInput, null));
            return Json(model, JsonRequestBehavior.AllowGet);
            
        }
    }
}
