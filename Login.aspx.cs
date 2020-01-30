#region Assemblies
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
#endregion

#region namespace
namespace LMSNamespace
{
    public partial class Login : System.Web.UI.Page
    {
        LMSsecurity BLayerobj = new LMSsecurity();
        public string LoginType;

        protected void Page_Init(object Sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            //string Ipaddress = Request.UserHostAddress;
            //string IP = "";

            //string strHostName = "";
            //strHostName = System.Net.Dns.GetHostName();

            //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            //IPAddress[] addr = ipEntry.AddressList;

            //IP = addr[2].ToString();

            ////Initializing a new xml document object to begin reading the xml file returned
            //XmlDocument doc = new XmlDocument();
            //doc.Load("http://www.freegeoip.net/json");
            //XmlNodeList nodeLstCity = doc.GetElementsByTagName("City");
            //IP = "" + nodeLstCity[0].InnerText + "<br>" + IP;
            string browsertoken = HdntokenID.Value;


            if (TxtCompanyCode.Text == "AWN1001" && TxtUserId.Text == "admin" && TxtPassword.Text == "@dmin123")
            {
                Response.Redirect("AdminDashboard.aspx", false);
                Session["LoginType"] = "Admin";
                Session["UserId"] = "1";
                Session["MainImage"] = "Images/tech_soc_icon.png";
                Session["CompanyCode"] = "1";
            }
            else
            {
                DataSet dsselect = new DataSet();
                dsselect = BLayerobj.LoginPage("1", TxtCompanyCode.Text, 0, TxtUserId.Text, TxtPassword.Text, myIP, browsertoken);
                string Error = BLayerobj.checkErrorinDataSet(dsselect);
                if (Error == "No Error")
                {
                    string Status = dsselect.Tables[0].Rows[0][0].ToString();
                    if (Status == "Invalid Username")
                    {
                        lblStatus.Text = "Invalid Username or Password";
                    }
                    else if (Status == "Invalid Password")
                    {
                        lblStatus.Text = Status;
                    }
                    else
                    {
                        LoginType = dsselect.Tables[0].Rows[0]["Logintype"].ToString();
                        if (LoginType == "Company")
                        {
                            Session["LoginType"] = "Company";
                            Session["UserId"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                            Session["CompanyCode"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                            Session["CompanyName"] = dsselect.Tables[0].Rows[0]["CompanyName"].ToString();
                            Session["UserName"] = dsselect.Tables[0].Rows[0]["Name"].ToString();
                            Session["MainImage"] = dsselect.Tables[0].Rows[0]["ComapanyImage"].ToString();
                            Session["CompanyEmail"] = dsselect.Tables[0].Rows[0]["Email"].ToString();
                            Response.Redirect("main.aspx", false);
                        }
                        else if (LoginType == "Employee")
                        {
                            Session["LoginType"] = "Employee";
                            Session["UserId"] = dsselect.Tables[0].Rows[0]["EmpCode"].ToString();
                            Session["EmployeeCode"] = dsselect.Tables[0].Rows[0]["EmpCode"].ToString();
                            Session["EmployeeName"] = dsselect.Tables[0].Rows[0]["EmpName"].ToString();
                            Session["UserName"] = dsselect.Tables[0].Rows[0]["Name"].ToString();
                            Session["MainImage"] = dsselect.Tables[0].Rows[0]["EmpImage"].ToString();
                            Session["EmpEmail"] = dsselect.Tables[0].Rows[0]["Email"].ToString();
                            Session["CompanyCode"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                            Session["CompanyName"] = dsselect.Tables[0].Rows[0]["CompanyName"].ToString();
                            Response.Redirect("employeedashboard.aspx", false);
                        }
                        else if (LoginType == "Client")
                        {
                            Session["LoginType"] = "Client";
                            string DepLoginType = dsselect.Tables[0].Rows[0]["Deptype"].ToString();

                            Session["DepLoginType"] = DepLoginType;
                            Session["UserId"] = dsselect.Tables[0].Rows[0]["ClientCode"].ToString();
                            Session["ClientCode"] = dsselect.Tables[0].Rows[0]["ClientCode"].ToString();
                            Session["CompanyCode"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                            Session["CompanyName"] = dsselect.Tables[0].Rows[0]["CompanyName"].ToString();
                            Session["UserName"] = dsselect.Tables[0].Rows[0]["Name"].ToString();
                            Session["User"] = dsselect.Tables[0].Rows[0]["username"].ToString();
                            Session["MainImage"] = dsselect.Tables[0].Rows[0]["EmpImage"].ToString();
                            Session["ShowCompanyName"] = dsselect.Tables[0].Rows[0]["ShowCompanyName"].ToString();
                            Session["EmpEmail"] = dsselect.Tables[0].Rows[0]["Email"].ToString();
                            Session["ClientName"] = dsselect.Tables[0].Rows[0]["ClientName"].ToString();
                            if (DepLoginType == "OWNER_LOGIN")
                            {
                                Response.Redirect("clientmain.aspx", false);
                            }

                            if (DepLoginType == "GUARD_LOGIN")
                            {
                                Response.Redirect("dep_guarddashboard.aspx", false);
                            }
                        }
                        else if (LoginType == "Deployment Client")
                        {
                             
                            //if (DepLoginType == "OWNER_LOGIN")
                            //{
                            //    Session["LoginType"] = "Deployment Client";
                              
                                Session["ClientCode"] = dsselect.Tables[0].Rows[0]["Created_by"].ToString();
                                Session["CompanyCode"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                                Session["ShowCompanyName"] = dsselect.Tables[0].Rows[0]["ShowCompanyName"].ToString();
                                Session["ClientName"] = dsselect.Tables[0].Rows[0]["DE_Name"].ToString();
                                Session["UserName"] = dsselect.Tables[0].Rows[0]["Name"].ToString();
                                Session["UserRole"] = dsselect.Tables[0].Rows[0]["DE_Userroll"].ToString();
                                Session["EmpEmail"] = dsselect.Tables[0].Rows[0]["DE_Email"].ToString();
                                Session["Client_Empcode"] = dsselect.Tables[0].Rows[0]["DE_Code"].ToString();
                                Session["MainImage"] = dsselect.Tables[0].Rows[0]["EmpImage"].ToString();
                                Response.Redirect("clientmain.aspx", false);
                            //}
                            //if (DepLoginType == "GUARD_LOGIN")
                            //{

                            //    Session["LoginType"] = "Deployment Client";
                            //    Session["ClientCode"] = dsselect.Tables[0].Rows[0]["Created_by"].ToString();
                            //    Session["CompanyCode"] = dsselect.Tables[0].Rows[0]["CompanyCode"].ToString();
                            //    Session["ShowCompanyName"] = dsselect.Tables[0].Rows[0]["ShowCompanyName"].ToString();
                            //    Session["ClientName"] = dsselect.Tables[0].Rows[0]["DE_Name"].ToString();
                            //    Session["UserName"] = dsselect.Tables[0].Rows[0]["Name"].ToString();
                            //    Session["UserRole"] = dsselect.Tables[0].Rows[0]["DE_Userroll"].ToString();
                            //    Session["EmpEmail"] = dsselect.Tables[0].Rows[0]["DE_Email"].ToString();
                            //    Session["Client_Empcode"] = dsselect.Tables[0].Rows[0]["DE_Code"].ToString();
                            //    Session["MainImage"] = dsselect.Tables[0].Rows[0]["EmpImage"].ToString();
                            //    Response.Redirect("clientmain.aspx", false);
                            //}
                        }
                    }
                }
                else if (Error == "No Records")
                {
                }
            }
        }
    }
}
#endregion