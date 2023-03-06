using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using System.Configuration;


namespace MahaReport
{
    public partial class Report : System.Web.UI.Page
    {
        string strTahsilID = "";
        string strSubDistID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strTahsilID = Request.QueryString["TahsilID"];
                strSubDistID = Request.QueryString["SubDistID"];

                string strReportServerURL = ConfigurationManager.AppSettings["ReportServerURL"].ToString();
                string strReportServerPath = ConfigurationManager.AppSettings["ReportServerPath"].ToString();

                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                ServerReport serverReport = ReportViewer1.ServerReport;

                // Set the report server URL and report path
                serverReport.ReportServerUrl = new Uri(strReportServerURL);
                serverReport.ReportPath = "/MahaRep1"; //"/" + strReportServerPath + 
                                                       //serverReport.ReportServerUrl = new Uri("http://novum-3/ReportServer");
                                                       //serverReport.ReportPath = "/eAdangal/AdangalReportVao";
                                                       //ReportViewer1.ServerReport.SetDataSourceCredentials(new[] { new DataSourceCredentials() { Name = "DataSource1", Password = "sys123$" } });


                ReportParameter[] RptParameters = new ReportParameter[2];

                RptParameters[0] = new ReportParameter("TahsildarID", strTahsilID);
                RptParameters[1] = new ReportParameter("SubDistrictCode", strSubDistID);

                ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials("mahavmrs1", "Maharashtra@#$321", "");

                ReportViewer1.ServerReport.SetParameters(RptParameters);

                ReportViewer1.ShowParameterPrompts = false;
            }
        }
    }
}