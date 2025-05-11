using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class _ProfileUpdation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                LoadItemCategories();

                _GetProfile();
            }

            
        }

        private void LoadItemCategories()
        {
            Visitor obj = new Visitor();

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

        private void _GetProfile()
        {
            Visitor obj = new Visitor();
            DataTable tabCust = new DataTable();

            tabCust = obj.GetCustomerDetails(Session["Customer_ID"].ToString());

            if (tabCust.Rows.Count > 0)
            {
                //emailId
                txt_EmailID.Text = tabCust.Rows[0]["Email_ID"].ToString();
                txt_EmailID.Enabled = false;

                //AOI
                DataTable tabCateg123 = new DataTable();
                tabCateg123 = obj.GetCategoryByName(tabCust.Rows[0]["AOI"].ToString());

                int categId = int.Parse(tabCateg123.Rows[0]["Category_ID"].ToString());

                string datatextfield = DropDownListAOI.Items.FindByValue(categId.ToString()).ToString();

                ListItem item = new ListItem(datatextfield, categId.ToString());
                int index = DropDownListAOI.Items.IndexOf(item);

                if (index != -1)

                    DropDownListAOI.SelectedIndex = index;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Visitor obj = new Visitor();

                obj.UpdateAOI(DropDownListAOI.SelectedItem.Text, Session["Customer_ID"].ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('AOI Updated Successfully')</script>");
            }
            catch
            {

            }
        }
    }
}