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
using System.IO;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class Categories : System.Web.UI.Page
    {
        Admin_Class obj = new Admin_Class();
        static DataTable tab = new DataTable();
       static int serial_no = 1;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_ID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                GetAllCategories();

            }
        }



        #region -------- MANAGE ITEM CATEGORIES ------------

        private void GetAllCategories()
        {
            tab.Rows.Clear();
            tab = obj.GetAllCategories();

            if (tab.Rows.Count > 0)
            {
                Table1.Rows.Clear();

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row1 = new TableRow();

                    TableCell row1_cell1 = new TableCell();
                    row1_cell1.Width = 10;
                    row1_cell1.Font.Size = 10;
                    row1_cell1.Text = serial_no + cnt + ".";
                    row1.Controls.Add(row1_cell1);

                    TableCell row1_cell2 = new TableCell();
                    row1_cell2.HorizontalAlign = HorizontalAlign.Left;
                    row1_cell2.Width = 400;
                    row1_cell2.Text = tab.Rows[cnt]["Category_Name"].ToString();
                    row1.Controls.Add(row1_cell2);

                    TableRow row2 = new TableRow();

                    TableCell row2_cell1 = new TableCell();
                    row2_cell1.Width = 10;
                    row2_cell1.Text = " ";
                    row2.Controls.Add(row2_cell1);

                    TableCell row2_Cell2 = new TableCell();
                    row2_Cell2.Width = 400;
                    row2_Cell2.HorizontalAlign = HorizontalAlign.Right;
                    Button btn_deletecategory = new Button();
                    btn_deletecategory.ID = tab.Rows[cnt]["Category_ID"].ToString();
                    btn_deletecategory.Text = "Delete";
                    btn_deletecategory.OnClientClick = "return confirm('Are you sure want to delete?')";
                    btn_deletecategory.Click += new EventHandler(btn_deletecategory_Click);
                    row2_Cell2.Controls.Add(btn_deletecategory);
                    row2.Controls.Add(row2_Cell2);

                    TableRow row3 = new TableRow();
                    TableCell row3_cell1 = new TableCell();
                    row3_cell1.Width = 10;
                    row3_cell1.Text = " ";
                    row3.Controls.Add(row3_cell1);

                    TableCell row3_cell2 = new TableCell();
                    row3_cell2.Width = 400;
                    row3_cell2.Text = "<hr/>";
                    row3.Controls.Add(row3_cell2);

                    Table1.Controls.Add(row1);
                    Table1.Controls.Add(row2);
                    Table1.Controls.Add(row3);

                }


            }
            else
            {
                Table1.Rows.Clear();
                Table1.GridLines = GridLines.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ColumnSpan = 5;
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Text = "No ItemCategories Found";
                row.Controls.Add(cell);

                Table1.Controls.Add(row);

            }

        }

        void btn_deletecategory_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
                      
            try
            {
                int subcategoryID = 0, ItemID = 0;
                DataTable t1 = new DataTable();
                t1.Rows.Clear();
                t1 = obj.GetCategorySubCategories(int.Parse(btn.ID));

                if (t1.Rows.Count > 0)
                {
                    for (int x = 0; x < t1.Rows.Count; x++)
                    {
                        subcategoryID = int.Parse(t1.Rows[x]["SubCategory_ID"].ToString());

                        DataTable t2 = new DataTable();
                        t2.Rows.Clear();
                        t2 = obj.GetSubcategoryItems(subcategoryID);

                        if (t2.Rows.Count > 0)
                        {
                            for (int y = 0; y < t2.Rows.Count; y++)
                            {
                                ItemID = int.Parse(t2.Rows[y]["Item_ID"].ToString());
                                string path = t2.Rows[y]["Item_Image"].ToString();

                                if (obj.CheckItemRatings(ItemID))
                                {
                                    obj.DeleteProductRatings(ItemID);
                                }

                                File.Delete(path);
                                obj.DeleteItem(ItemID);
                               
                            }

                            obj.DeleteItemSubCategory(subcategoryID);
                        }
                        else
                        {
                            obj.DeleteItemSubCategory(subcategoryID);
                        }

                    }

                    obj.DeleteItemCategory(int.Parse(btn.ID));
                }
                else
                {
                    obj.DeleteItemCategory(int.Parse(btn.ID));
                }

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('ItemCategory Deleted Successfully (With SubCategories & Items)')</script>");
                GetAllCategories();
                ClearTextBoxes();
                btn_newcategories.Text = "Submit";

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Server Error!')</script>");
            }

        }

        protected void btn_newcategories_Click(object sender, EventArgs e)
        {
            try
            {

                if (obj.CheckItemCategory(txt_categoryname.Text))
                {
                    obj.NewItemCategory(txt_categoryname.Text);
                    ClearTextBoxes();
                    GetAllCategories();
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('New ItemCategory Added Successfully')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('ItemCategory Exists')</script>");
                }


            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Server Error!')</script>");
            }
        }

        private void ClearTextBoxes()
        {
            txt_categoryname.Text = string.Empty;
        }

       
        #endregion

    }
}