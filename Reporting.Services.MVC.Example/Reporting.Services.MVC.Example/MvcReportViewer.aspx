<%@ Page Language="C#" AutoEventWireup="true" Inherits="MvcReportViewer.MvcReportViewer, MvcReportViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet"/>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
</head>
<body>
    <form id="reportForm" runat="server">
    <div>
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
               
        <rsweb:ReportViewer ID="ReportViewer" ClientIDMode="Predictable" runat="server" OnSubmittingParameterValues="ReportViewer_SubmittingParameterValues"></rsweb:ReportViewer>

    </div>
    </form>
        <script runat="server">
            protected void ReportViewer_SubmittingParameterValues(object sender, ReportParametersEventArgs e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClearReportParameters", "var reportParameters = []; ", true);
                StringBuilder stringParametros = new StringBuilder();
                for(var x=0;x<e.Parameters.Count;x++)
                {
                    stringParametros.Append(String.Format("'{0}_{1}',", e.Parameters[x].Name, e.Parameters[x].Values[0]));
                }
                ScriptManager.RegisterArrayDeclaration(this, "reportParameters", stringParametros.ToString().Substring(0,stringParametros.Length-1));
            }
        </script>
     
        <script>
            function getReportParameters() {
                try {
                    return reportParameters;
                }
                catch (e) {
                    return [];
                }
            }
        </script>
    <script type="text/html" id="non-ie-print-button">
        <div class="" style="font-family: Verdana; font-size: 8pt; vertical-align: top; display: inline-block; width: 28px; margin-left: 6px;">
            <table style="display: inline;" cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td height="28">
                            <div>
                                <div id="mvcreportviewer-btn-print" style="border: 1px solid transparent; border-image: none; cursor: default; background-color: transparent;">
                                    <table title="Print">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <input 
                                                        id="PrintButton"
                                                        title="Print" 
                                                        style="width: 16px; height: 16px;" 
                                                        type="image" 
                                                        alt="Print" 
                                                        runat="server"
                                                        src="~/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=11.0.3442.2&amp;Name=Microsoft.Reporting.WebForms.Icons.Print.gif" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </script>
</body>
</html>
