using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class _MemberSearch : System.Web.UI.Page
    {
        DataTable tab = new DataTable();
        Visitor obj = new Visitor();
        TableCell[] c;
        static int i = 0;
        static int j = 15;
        static string records = "All";
        static string Category_Name = null;
        static string SubCategName = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                records = "All";
                //i = 0;
                //j = 15;

            }

            try
            {
                if (txtSearch.Text.Equals(""))
                {

                }
                else
                {
                    if (records.Equals("All"))

                        GetAllItems();

                    else if (records.Equals("Categorywise"))

                        GetCategoryItems(Category_Name);

                    else if (records.Equals("SubCategory"))

                        GetItems_Categ_SubCategID(SubCategName);
                }
            }
            catch
            {

            }
        }

        private void GetAllItems()
        {
            Table1.Controls.Clear();
            Table1.Rows.Clear();

            tab.Rows.Clear();
            tab = obj.SearchItems("%" + txtSearch.Text + "%");

            if (tab.Rows.Count > 0)
            {
                lblError.Font.Bold = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "";

                for (int cnt = i; cnt < j; cnt += 3)
                {
                    if (cnt < tab.Rows.Count)
                    {
                        //PanelBtns.Visible = true;                       
                        int count = 0;
                        int k = 0;
                        c = new TableCell[3];
                        try
                        {
                            while (count < 3)
                            {
                                c[count] = new TableCell();
                                if (k + cnt < tab.Rows.Count)
                                {
                                    Table t = new Table();
                                    t.Width = 250;
                                    TableCell c1 = new TableCell();
                                    c1.ColumnSpan = 3;
                                    c1.Height = 30;
                                    c1.Text = "<b><font color='#006699' size='2px'>" + tab.Rows[k + cnt]["Item_Name"].ToString() + "</font></b>";
                                    TableRow R1 = new TableRow();
                                    R1.Controls.Add(c1);
                                    t.Controls.Add(R1);
                                    TableCell c2 = new TableCell();

                                    c2.RowSpan = 3;
                                    c2.Width = 70;
                                    c2.Text = "<img src='" + tab.Rows[k + cnt]["Item_Image"].ToString() + "' width=75px height=100px border=0 />";
                                    TableCell c3 = new TableCell();
                                    c3.HorizontalAlign = HorizontalAlign.Left;
                                    c3.ColumnSpan = 2;

                                    c3.Text = "<b><font color='#993366' size='2px'> Rs. " + tab.Rows[k + cnt]["Item_Cost"].ToString() + " /- </font></b>";
                                    ImageButton imgA = new ImageButton();
                                    imgA.ImageUrl = "../images/cart6.jpg";

                                    imgA.ToolTip = "Click to add the Item into the cart";
                                    imgA.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_10" + k + cnt;
                                    imgA.Click += new ImageClickEventHandler(imgA_Click);
                                    TableCell txt = new TableCell();
                                    txt.HorizontalAlign = HorizontalAlign.Left;

                                    int totalquantity = 0;
                                    //totalquantity = obj.ItemSaledQuantity(int.Parse(tab.Rows[k + cnt]["Item_ID"].ToString()));

                                    totalquantity = int.Parse(tab.Rows[k + cnt]["Quantity"].ToString());

                                    LinkButton li = new LinkButton();
                                    if (totalquantity > 0)
                                    {
                                        li.Enabled = true;
                                        imgA.Enabled = true;

                                        li.Text = "<font size='2px'>Add To Cart</font>";
                                    }
                                    else
                                    {
                                        li.Enabled = false;
                                        imgA.Enabled = false;

                                        li.Text = "<font size='2px'>Out of Stock</font>";
                                    }

                                    li.Font.Underline = false;
                                    li.Text = "<font size='2px'>Add To Cart</font>";
                                    li.ToolTip = "Click here to add to Cart";
                                    li.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_101" + k + cnt;
                                    li.Click += new EventHandler(li_Click);
                                    txt.Controls.Add(li);

                                    TableCell cartimg = new TableCell();
                                    cartimg.Width = 25;
                                    cartimg.HorizontalAlign = HorizontalAlign.Left;
                                    cartimg.Controls.Add(imgA);


                                    LinkButton l = new LinkButton();
                                    l.Font.Underline = false;
                                    l.Text = "<font size='1px' color='#006699'>More Details</font>";
                                    l.ToolTip = "Click here to view the details";
                                    l.Font.Underline = true;
                                    l.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_0" + k + cnt;
                                    l.Click += new EventHandler(l_Click);
                                    TableCell c5 = new TableCell();
                                    c5.ColumnSpan = 2;
                                    //c5.Width = 100;
                                    c5.HorizontalAlign = HorizontalAlign.Left;
                                    c5.Controls.Add(l);
                                    TableRow R2 = new TableRow();
                                    R2.Controls.Add(c2);
                                    R2.Controls.Add(c3);
                                    TableRow R3 = new TableRow();
                                    R3.Controls.Add(cartimg);
                                    R3.Controls.Add(txt);
                                    TableRow R4 = new TableRow();

                                    R4.Controls.Add(c5);

                                    t.Controls.Add(R2);
                                    t.Controls.Add(R3);
                                    t.Controls.Add(R4);
                                    c[count].Controls.Add(t);

                                }
                                else
                                {

                                }
                                k++;
                                count++;
                            }
                            TableRow row = new TableRow();
                            row.Controls.Add(c[0]);
                            row.Controls.Add(c[1]);
                            row.Controls.Add(c[2]);
                            Table1.Controls.Add(row);
                            TableCell cell = new TableCell();
                            cell.ColumnSpan = 3;
                            cell.Text = "<br/><br/>------------------------------------------------------------------------------------------------------------------------<br/>";
                            TableRow row1 = new TableRow();
                            row1.Controls.Add(cell);
                            Table1.Controls.Add(row1);


                        }
                        catch
                        {

                        }
                    }

                }
            }
            else
            {
                Table1.Rows.Clear();
                Table1.GridLines = GridLines.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.ColumnSpan = 5;
                cell.Text = "No Items Found";
                row.Controls.Add(cell);

                Table1.Controls.Add(row);

                lblError.Font.Bold = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "No Matches Found for the Input!!!";
            }
        }

        private void GetCategoryItems(string categ_Name)
        {
            Table1.Controls.Clear();
            Table1.Rows.Clear();


            tab.Rows.Clear();

            DataTable tabCate = new DataTable();
            tabCate = obj.GetCategoryByName(categ_Name);

            tab = obj.GetCategoryItems(int.Parse(tabCate.Rows[0]["Category_ID"].ToString()));

            if (tab.Rows.Count > 0)
            {
                Table1.Rows.Clear();

                for (int cnt = i; cnt < j; cnt += 3)
                {
                    if (cnt < tab.Rows.Count)
                    {
                        //PanelBtns.Visible = true;                        
                        int count = 0;
                        int k = 0;
                        c = new TableCell[3];
                        try
                        {
                            while (count < 3)
                            {
                                c[count] = new TableCell();
                                if (k + cnt < tab.Rows.Count)
                                {
                                    Table t = new Table();
                                    t.Width = 250;
                                    TableCell c1 = new TableCell();
                                    c1.ColumnSpan = 3;
                                    c1.Height = 30;
                                    c1.Text = "<b><font color='#006699' size='2px'>" + tab.Rows[k + cnt]["Item_Name"].ToString() + "</font></b>";
                                    TableRow R1 = new TableRow();
                                    R1.Controls.Add(c1);
                                    t.Controls.Add(R1);
                                    TableCell c2 = new TableCell();

                                    c2.RowSpan = 3;
                                    c2.Width = 70;
                                    c2.Text = "<img src='" + tab.Rows[k + cnt]["Item_Image"].ToString() + "' width=75px height=100px border=0 />";
                                    TableCell c3 = new TableCell();
                                    c3.HorizontalAlign = HorizontalAlign.Left;
                                    c3.ColumnSpan = 2;

                                    c3.Text = "<b><font color='#993366' size='2px'> Rs. " + tab.Rows[k + cnt]["Item_Cost"].ToString() + " /- </font></b>";
                                    ImageButton imgA1 = new ImageButton();
                                    imgA1.ImageUrl = "../images/cart6.jpg";

                                    imgA1.ToolTip = "Click to add the Item into the cart";
                                    imgA1.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_10" + k + cnt;
                                    imgA1.Click += new ImageClickEventHandler(imgA1_Click);
                                    TableCell txt = new TableCell();
                                    txt.HorizontalAlign = HorizontalAlign.Left;
                                    int totalquantity = 0;
                                    //totalquantity = obj.ItemSaledQuantity(int.Parse(tab.Rows[k + cnt]["Item_ID"].ToString()));

                                    totalquantity = int.Parse(tab.Rows[k + cnt]["Quantity"].ToString());

                                    LinkButton li1 = new LinkButton();
                                    if (totalquantity > 0)
                                    {
                                        li1.Enabled = true;
                                        imgA1.Enabled = true;
                                    }
                                    else
                                    {
                                        li1.Enabled = false;
                                        imgA1.Enabled = false;
                                    }

                                    li1.Font.Underline = false;
                                    li1.Text = "<font size='2px'>Add To Cart</font>";
                                    li1.ToolTip = "Click here to add to Cart";
                                    li1.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_101" + k + cnt;
                                    li1.Click += new EventHandler(li1_Click);
                                    txt.Controls.Add(li1);

                                    TableCell cartimg = new TableCell();
                                    cartimg.Width = 25;
                                    cartimg.HorizontalAlign = HorizontalAlign.Left;
                                    cartimg.Controls.Add(imgA1);


                                    LinkButton l1 = new LinkButton();
                                    l1.Font.Underline = false;
                                    l1.Text = "<font size='1px' color='#006699'>More Details</font>";
                                    l1.ToolTip = "Click here to view the details";
                                    l1.Font.Underline = true;
                                    l1.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_0" + k + cnt;
                                    l1.Click += new EventHandler(l1_Click);
                                    TableCell c5 = new TableCell();
                                    c5.ColumnSpan = 2;
                                    //c5.Width = 100;
                                    c5.HorizontalAlign = HorizontalAlign.Left;
                                    c5.Controls.Add(l1);
                                    TableRow R2 = new TableRow();
                                    R2.Controls.Add(c2);
                                    R2.Controls.Add(c3);
                                    TableRow R3 = new TableRow();
                                    R3.Controls.Add(cartimg);
                                    R3.Controls.Add(txt);
                                    TableRow R4 = new TableRow();

                                    R4.Controls.Add(c5);

                                    t.Controls.Add(R2);
                                    t.Controls.Add(R3);
                                    t.Controls.Add(R4);
                                    c[count].Controls.Add(t);

                                }
                                else
                                {

                                }
                                k++;
                                count++;
                            }
                            TableRow row = new TableRow();
                            row.Controls.Add(c[0]);
                            row.Controls.Add(c[1]);
                            row.Controls.Add(c[2]);
                            Table1.Controls.Add(row);
                            TableCell cell = new TableCell();
                            cell.ColumnSpan = 3;
                            cell.Text = "<br/><br/>------------------------------------------------------------------------------------------------------------------------<br/>";
                            TableRow row1 = new TableRow();
                            row1.Controls.Add(cell);
                            Table1.Controls.Add(row1);


                        }
                        catch
                        {

                        }
                    }


                }
            }
            else
            {
                Table1.Rows.Clear();
                Table1.GridLines = GridLines.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.ColumnSpan = 5;
                cell.Text = "No Items Found";
                row.Controls.Add(cell);

                Table1.Controls.Add(row);

            }
        }

        void l1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton link = (LinkButton)sender;
            string[] id = link.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            Response.Redirect("MemberViewDetails.aspx");
        }

        void li1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton Or = (LinkButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        void imgA1_Click(object sender, ImageClickEventArgs e)
        {
            //throw new NotImplementedException();
            ImageButton Or = (ImageButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        private void GetItems_Categ_SubCategID(string subName)
        {
            tab.Rows.Clear();
            Table1.Controls.Clear();
            Table1.Rows.Clear();

            DataTable tabSubCate = new DataTable();
            tabSubCate = obj.GetSubCategoryByName(subName);

            tab = obj.GetSubcategoryItems(int.Parse(tabSubCate.Rows[0]["SubCategory_ID"].ToString()));

            if (tab.Rows.Count > 0)
            {
                Table1.Rows.Clear();


                for (int cnt = i; cnt < j; cnt += 3)
                {
                    if (cnt < tab.Rows.Count)
                    {
                        //PanelBtns.Visible = true;                       
                        int count = 0;
                        int k = 0;
                        c = new TableCell[3];
                        try
                        {
                            while (count < 3)
                            {
                                c[count] = new TableCell();
                                if (k + cnt < tab.Rows.Count)
                                {
                                    Table t = new Table();
                                    t.Width = 250;
                                    TableCell c1 = new TableCell();
                                    c1.ColumnSpan = 3;
                                    c1.Height = 30;
                                    c1.Text = "<b><font color='#006699' size='2px'>" + tab.Rows[k + cnt]["Item_Name"].ToString() + "</font></b>";
                                    TableRow R1 = new TableRow();
                                    R1.Controls.Add(c1);
                                    t.Controls.Add(R1);
                                    TableCell c2 = new TableCell();

                                    c2.RowSpan = 3;
                                    c2.Width = 70;
                                    c2.Text = "<img src='" + tab.Rows[k + cnt]["Item_Image"].ToString() + "' width=75px height=100px border=0 />";
                                    TableCell c3 = new TableCell();
                                    c3.HorizontalAlign = HorizontalAlign.Left;
                                    c3.ColumnSpan = 2;

                                    c3.Text = "<b><font color='#993366' size='2px'> Rs. " + tab.Rows[k + cnt]["Item_Cost"].ToString() + " /- </font></b>";
                                    ImageButton imgA2 = new ImageButton();
                                    imgA2.ImageUrl = "../images/cart6.jpg";

                                    imgA2.ToolTip = "Click to add the Item into the cart";
                                    imgA2.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_10" + k + cnt;
                                    imgA2.Click += new ImageClickEventHandler(imgA2_Click);
                                    TableCell txt = new TableCell();
                                    txt.HorizontalAlign = HorizontalAlign.Left;



                                    int totalquantity = 0;
                                    //totalquantity = obj.ItemSaledQuantity(int.Parse(tab.Rows[k + cnt]["Item_ID"].ToString()));

                                    totalquantity = int.Parse(tab.Rows[k + cnt]["Quantity"].ToString());

                                    LinkButton li2 = new LinkButton();
                                    if (totalquantity > 0)
                                    {
                                        li2.Enabled = true;
                                        imgA2.Enabled = true;
                                    }
                                    else
                                    {
                                        li2.Enabled = false;
                                        imgA2.Enabled = false;
                                    }

                                    li2.Font.Underline = false;
                                    li2.Text = "<font size='2px'>Add To Cart</font>";
                                    li2.ToolTip = "Click here to add to Cart";
                                    li2.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_101" + k + cnt;
                                    li2.Click += new EventHandler(li2_Click);
                                    txt.Controls.Add(li2);

                                    TableCell cartimg = new TableCell();
                                    cartimg.Width = 25;
                                    cartimg.HorizontalAlign = HorizontalAlign.Left;
                                    cartimg.Controls.Add(imgA2);


                                    LinkButton l2 = new LinkButton();
                                    l2.Font.Underline = false;
                                    l2.Text = "<font size='1px' color='#006699'>More Details</font>";
                                    l2.ToolTip = "Click here to view the details";
                                    l2.Font.Underline = true;
                                    l2.ID = tab.Rows[k + cnt]["Item_ID"].ToString() + "_0" + k + cnt;
                                    l2.Click += new EventHandler(l2_Click);
                                    TableCell c5 = new TableCell();
                                    c5.ColumnSpan = 2;
                                    //c5.Width = 100;
                                    c5.HorizontalAlign = HorizontalAlign.Left;
                                    c5.Controls.Add(l2);
                                    TableRow R2 = new TableRow();
                                    R2.Controls.Add(c2);
                                    R2.Controls.Add(c3);
                                    TableRow R3 = new TableRow();
                                    R3.Controls.Add(cartimg);
                                    R3.Controls.Add(txt);
                                    TableRow R4 = new TableRow();

                                    R4.Controls.Add(c5);

                                    t.Controls.Add(R2);
                                    t.Controls.Add(R3);
                                    t.Controls.Add(R4);
                                    c[count].Controls.Add(t);

                                }
                                else
                                {

                                }
                                k++;
                                count++;
                            }
                            TableRow row = new TableRow();
                            row.Controls.Add(c[0]);
                            row.Controls.Add(c[1]);
                            row.Controls.Add(c[2]);
                            Table1.Controls.Add(row);
                            TableCell cell = new TableCell();
                            cell.ColumnSpan = 3;
                            cell.Text = "<br/><br/>------------------------------------------------------------------------------------------------------------------------<br/>";
                            TableRow row1 = new TableRow();
                            row1.Controls.Add(cell);
                            Table1.Controls.Add(row1);


                        }
                        catch
                        {

                        }
                    }



                }
            }
            else
            {
                Table1.Rows.Clear();
                Table1.GridLines = GridLines.None;

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.Font.Bold = true;
                cell.ForeColor = System.Drawing.Color.Red;
                cell.ColumnSpan = 5;
                cell.Text = "No Items Found";
                row.Controls.Add(cell);

                Table1.Controls.Add(row);

            }
        }

        void l2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton link = (LinkButton)sender;
            string[] id = link.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            Response.Redirect("MemberViewDetails.aspx");
        }

        void li2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            LinkButton Or = (LinkButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        void imgA2_Click(object sender, ImageClickEventArgs e)
        {
            //throw new NotImplementedException();
            ImageButton Or = (ImageButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        void li_Click(object sender, EventArgs e)
        {
            LinkButton Or = (LinkButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        void imgA_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Or = (ImageButton)sender;
            string[] id = Or.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            if (obj.CountItem(int.Parse(id[0]), Session["Customer_ID"].ToString()))
            {
                if (obj.AddCartDetails(Session["Customer_ID"].ToString(), int.Parse(id[0]), 1))
                {
                    Response.Redirect("MemberCart.aspx");
                }
            }
            else
                Response.Redirect("MemberCart.aspx");
        }

        void l_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string[] id = link.ID.ToString().Split('_');
            Session["Item_ID"] = id[0];
            Response.Redirect("MemberViewDetails.aspx");
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Table1.Controls.Clear();
            Table1.Rows.Clear();

            //check category
            Visitor obj = new Visitor();
            DataTable tabCateg = new DataTable();
            ArrayList arrayCategs = new ArrayList();

            tabCateg = obj.GetAllCategories();

            if (tabCateg.Rows.Count > 0)
            {
                for (int i = 0; i < tabCateg.Rows.Count; i++)
                {
                    arrayCategs.Add(tabCateg.Rows[i]["Category_Name"].ToString());
                }
            }



            //check subcategory  
            Admin_Class obj1 = new Admin_Class();
            DataTable tabSubCateg = new DataTable();
            ArrayList arraySubCategs = new ArrayList();

            tabSubCateg = obj1.GetAllSubCategories();

            if (tabSubCateg.Rows.Count > 0)
            {
                for (int i = 0; i < tabSubCateg.Rows.Count; i++)
                {
                    arraySubCategs.Add(tabSubCateg.Rows[i]["SubCategory_Name"].ToString());
                }
            }



            //check item            
            DataTable tabItem = new DataTable();
            ArrayList arrayItem = new ArrayList();

            tabItem = obj1.GetAllItems();

            if (tabItem.Rows.Count > 0)
            {
                for (int i = 0; i < tabItem.Rows.Count; i++)
                {
                    arrayItem.Add(tabItem.Rows[i]["Item_Name"].ToString());
                }
            }


            if (arrayCategs.Contains(txtSearch.Text))
            {
                records = "Categorywise";
                Category_Name = txtSearch.Text;

                GetCategoryItems(txtSearch.Text);
            }
            else if (arraySubCategs.Contains(txtSearch.Text))
            {
                records = "SubCategory";
                SubCategName = txtSearch.Text;

                GetItems_Categ_SubCategID(txtSearch.Text);
            }
            else 
            {
                records = "All";
                GetAllItems();
            }            
        }

    }
}