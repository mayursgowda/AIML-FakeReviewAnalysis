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
    public partial class Registration_page : System.Web.UI.Page
    {
        Visitor obj = new Visitor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadItemCategories();
            }

            txt_EmailID.Focus();
        }


        private void LoadItemCategories()
        {
            DataTable tab1 = new DataTable();
            tab1.Rows.Clear();
            tab1 = obj.GetAllCategories();

            DropDownListAOI.Items.Clear();

            if (tab1.Rows.Count > 0)
            {
                DropDownListAOI.DataSource = tab1.DefaultView;

                DropDownListAOI.DataTextField = "Category_Name";
                DropDownListAOI.DataValueField = "Category_ID";

                DropDownListAOI.DataBind();

                DropDownListAOI.Items.Insert(0, "- All -");

            }
            else
            {
                DropDownListAOI.DataSource = null;
                DropDownListAOI.DataBind();

                DropDownListAOI.Items.Insert(0, "- Input AOI -");
            }
        }

        public void cleartxtboxes()
        {
            txt_EmailID.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_contactNo.Text = string.Empty;
           
            dropdownlistGender.SelectedIndex = 0;
            
            dropdownlistMartialstatus.SelectedIndex = 0;           
            TextBox1.Text = TextBox2.Text = string.Empty;
        }

        protected void btn_registration_Click(object sender, EventArgs e)
        {
            try
            {
                if (obj.Check_CustomerID_Avail(txt_EmailID.Text) && obj.Check_AdminID(txt_EmailID.Text))
                {
                    if (obj.Check_CustomerMobile_Avail(txt_contactNo.Text))
                    {
                        //string[] s = txtDOB.Text.Split('/');

                        obj.NewRegistration(txt_EmailID.Text, txt_Name.Text, txt_password.Text, dropdownlistGender.SelectedValue, null, dropdownlistMartialstatus.SelectedValue, null, null, null, TextBox2.Text, txt_contactNo.Text, txt_address.Text, TextBox1.Text, DropDownListAOI.SelectedItem.Text, "",
                            ddlAge.SelectedItem.Text,
                            ddlExperience.SelectedItem.Text, ddlTotalPosts.SelectedItem.Text, ddlHowoften.SelectedItem.Text, ddlLocation.SelectedItem.Text);

                        //ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Registered Successfully')</script>");
                        Response.Redirect("Login_page.aspx");
                        cleartxtboxes();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Mobile Number Already Exists')</script>");
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Customer EmailID Already Exists')</script>");
                }

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Server Error!')</script>");
            }
        }
    }
}
