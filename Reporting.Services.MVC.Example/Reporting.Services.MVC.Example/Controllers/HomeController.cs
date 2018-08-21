using Reporting.Services.MVC.Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reporting.Services.MVC.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult View(ReportModel model)
        {
            if(!String.IsNullOrEmpty(model.Parametros))
            {
                var parametros = new ListJsonParameter();
                parametros.data = new List<JsonParameter>();
                var parametrosView = model.Parametros.Split(';');
                foreach(var parametroView in parametrosView)
                {
                    parametros.data.Add(new JsonParameter() { Key = parametroView.Split('=')[0], Value = parametroView.Split('=')[1] });
                }
                var parms = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(parametros);
                return RedirectToAction("ReportViewerComponentWithHeadAndParam", "ReportViewer", new { reportPath = model.RutaReporte, jSonParms = parms });
            }
            else
            {
                return RedirectToAction("ReportViewerComponentWithHead", "ReportViewer", new { reportPath = model.RutaReporte });
            }            
        }
    }
}