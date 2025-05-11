using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class Login_page : System.Web.UI.Page
    {
        Visitor obj = new Visitor();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    txt_username.Focus();                    
                }
            }
            catch
            {

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (obj.Check_Customerlogin(txt_username.Text, txt_password.Text))
                {                   
                    Session["Customer_ID"] = txt_username.Text;
                  
                    Response.Redirect("BrowseItems.aspx");
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('InvalidID or Password')</script>");
                   
                }
            }
            catch
            {

            }
        }

        protected void lbtn_newuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration_page.aspx?value=e");
        }

        
    }
}
