using System.Collections.Generic;
using System.Web.Mvc;
using MvcReportViewer;

namespace Reporting.Services.MVC.Example.Models
{
    /// <summary>
    /// ViewModel con las propiedades que se pueden setear en el componente
    /// </summary>
    public class ReportingServicesComponentModel
    {
        public ReportingServicesComponentModel()
        {
            reportServerUrl = string.Empty;
            username = string.Empty;
            password = string.Empty;
            reportPath = string.Empty;
            htmlAttributes = null;
            reportParameters = null;
            controlSettings = null;
            method = FormMethod.Get;
            rInterface = ReportInterface.Basic;

            PermiteMandarFirmar = false;
            idDocumentacionTipo = 0;
        }
           
        public string reportServerUrl { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string reportPath { get; set; }

        public object htmlAttributes { get; set; }

        public IEnumerable<KeyValuePair<string, object>> reportParameters { get; set; }

        public ControlSettings controlSettings { get; set; }

        public FormMethod method { get; set; }

        public ReportInterface rInterface { get; set; }

        public bool PermiteMandarFirmar { get; set; }

        public int? idDocumentacionTipo { get; set; }

    }

    /// <summary>
    /// Enum que debe estar en otra clase, se ubica aca por fines practicos solamente
    /// </summary>
    public enum ReportInterface
    {
        Basic,
        Fluent
    }

    public class JsonParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ListJsonParameter
    {
        public List<JsonParameter> data { get; set; }
    }
}