using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.Configuration;
using Reporting.Services.MVC.Example.Models;

namespace Reporting.Services.MVC.Example.Controllers
{
    public class ReportViewerController : Controller
    {

        /// <summary>
        /// Descarga directa del reporte en formato pdf
        /// </summary>
        /// <returns></returns>
        //public ActionResult DownloadPDF(ReportingServicesComponentModel model)
        //{
        //    model.reportPath = "/ReportServicesProject/Report1";
        //    Stream fs = this.Report(ReportFormat.Pdf,
        //                            model.reportPath).FileStream;

        //    FileStreamResult fsr = new FileStreamResult(fs,ReportFormat.Pdf.ToString());
        //    fsr.FileDownloadName = "ReportServicesProject_Report1_" + DateTime.Now.Ticks.ToString() + "." + ReportFormat.Pdf.ToString();
        //    return fsr;
        //}

        /// <summary>
        /// Reporte con encabezado de menu
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportViewerComponentWithHead(string reportPath)
        {
            ReportingServicesComponentModel model = new ReportingServicesComponentModel();
            model.reportServerUrl = ConfigurationManager.AppSettings["MvcReportViewer.ReportServerUrl"].ToString();
            model.reportPath = reportPath;
            model.username = ConfigurationManager.AppSettings["MvcReportViewer.Username"].ToString();
            model.password = ConfigurationManager.AppSettings["MvcReportViewer.Password"].ToString();
            model.htmlAttributes = new { Height = 1500, Width = 1320, style = "border: none" };
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            return View("_ReportingServicesComponentWithHead", model);
        }

        /// <summary>
        /// Reporte con encabezado de menu y lista de parametros (json)
        /// </summary>
        /// <param name="reportPath"></param>
        /// <param name="jSonParms"></param>
        /// <returns></returns>
        public ActionResult ReportViewerComponentWithHeadAndParam(string reportPath, string jSonParms)
        {
            ReportingServicesComponentModel model = new ReportingServicesComponentModel();
            model.reportServerUrl = ConfigurationManager.AppSettings["MvcReportViewer.ReportServerUrl"].ToString();
            model.reportPath = reportPath;
            model.username = ConfigurationManager.AppSettings["MvcReportViewer.Username"].ToString();
            model.password = ConfigurationManager.AppSettings["MvcReportViewer.Password"].ToString();
            ListJsonParameter parms = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<ListJsonParameter>(jSonParms);
            var list = new List<KeyValuePair<string, object>>();
            KeyValuePair<string, object> entry;
            foreach (JsonParameter item in parms.data)
            {
                entry = new KeyValuePair<string, object>(item.Key, item.Value);
                list.Add(entry);
            }
            model.reportParameters = list;
            model.htmlAttributes = new { Height = 1500, Width = 1320, style = "border: none" };            
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            return View("_ReportingServicesComponentWithHead", model);
        }

        private string EscapeQuotedLiterals(string cadena)
        {
            return cadena
                    .Replace('á', 'a')
                    .Replace('é', 'e')
                    .Replace('í', 'i')
                    .Replace('ó', 'o')
                    .Replace('ú', 'u');
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}