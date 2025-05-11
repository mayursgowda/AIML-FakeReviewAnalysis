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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class ViewItemDetails : System.Web.UI.Page
    {
        DataTable tab = new DataTable();
        Visitor obj = new Visitor();
        Member_Class obj1 = new Member_Class();
        static int serial_no = 1;
        static int incrementbyOne = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Item_ID"] != null)
                {
                    ItemDetails(int.Parse(Session["Item_ID"].ToString()));
                    loadComments();
                }
                else
                {
                    TableBD.Rows.Clear();
                    TableBD.GridLines = GridLines.None;

                    TableHeaderRow row = new TableHeaderRow();
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Font.Bold = true;
                    cell.ForeColor = System.Drawing.Color.Red;
                    cell.ColumnSpan = 5;
                    cell.Text = "Item Name Not Found";
                    row.Controls.Add(cell);

                    TableBD.Controls.Add(row);
                }
            }
            catch
            {

            }
        }

        private void ItemDetails(int ItemID)
        {
            tab.Rows.Clear();
            tab = obj.GetItemDetails(ItemID);

            Session["subCategoryId"] = null;
            Session["subCategoryId"] = tab.Rows[0]["SubCategory_ID"].ToString();



            if (tab.Rows.Count > 0)
            {
                ImageButton img = new ImageButton();
                img.ImageUrl = "../images/search.gif";
                img.ID = tab.Rows[0]["Item_ID"].ToString();
                TableCell cell2 = new TableCell();
                cell2.HorizontalAlign = HorizontalAlign.Center;
                cell2.Controls.Add(img);
                TableRow rc1 = new TableRow();
                rc1.Controls.Add(cell2);
                TableCell C1 = new TableCell();
                TableCell cell1 = new TableCell();
                cell1.Text = "<a href='#'><img src='" + tab.Rows[0]["Item_Image"].ToString() + "' width=75px height=100px border=0/>" + "<span><img src='" + tab.Rows[0]["Item_Image"].ToString() + "' width=125px height=150px border=0/><br/> </span></a>";
                C1.HorizontalAlign = HorizontalAlign.Left;
                C1.Width = 130;

                DataTable tabRatings = new DataTable();
                tabRatings = obj.GetRatingByItem(int.Parse(tab.Rows[0]["Item_ID"].ToString()));

                double rating = 0;
                double _rate = 0;
                double _RCnt = 0;

                if (tabRatings.Rows.Count > 0)
                {
                    _RCnt = tabRatings.Rows.Count;
                    rating = obj.GetItemRating(int.Parse(tab.Rows[0]["Item_ID"].ToString()));
                    _rate = rating / _RCnt;
                }
                else
                {
                    rating = 0;
                }

                TableRow rc2 = new TableRow();
                rc2.Controls.Add(cell1);
                Table t1 = new Table();
                t1.Controls.Add(rc2);

                t1.Controls.Add(rc1);
                C1.Controls.Add(t1);
                TableCell c1 = new TableCell();
                c1.ColumnSpan = 2;
                c1.Text = "<b>" + tab.Rows[0]["Item_Name"].ToString() + "</b>";
                TableRow r1 = new TableRow();
                r1.Controls.Add(c1);

                TableCell c3 = new TableCell();
                c3.ColumnSpan = 2;
                c3.Text = "<b><font size='2px'>Quantity </b></font>:<font color='#85584C'>" + tab.Rows[0]["Quantity"].ToString() + "</font>";
                TableRow r3 = new TableRow();
                r3.Controls.Add(c3);

                TableCell c5 = new TableCell();
                c5.ColumnSpan = 2;
                c5.Text = "<b><font size='2px'>Price </b></font>: Rs<font color='#85584C'>" + tab.Rows[0]["Item_Cost"].ToString() + "</font>";
                TableRow r5 = new TableRow();
                r5.Controls.Add(c5);

                ImageButton imgA = new ImageButton();
                imgA.ImageUrl = "../images/cart6.jpg";

                imgA.ToolTip = "Click to add the Item into the cart";
                imgA.ID = tab.Rows[0]["Item_ID"].ToString() + "_99";
                imgA.Click += new ImageClickEventHandler(imgA_Click);
                TableCell txt = new TableCell();
                txt.HorizontalAlign = HorizontalAlign.Left;
                int totalquantity = 0;

                totalquantity = int.Parse(tab.Rows[0]["Quantity"].ToString());

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
               
                li.ToolTip = "Click here to add to Cart";
                li.ID = tab.Rows[0]["Item_ID"].ToString() + "_999";
                li.Click += new EventHandler(li_Click);
                txt.Controls.Add(li);

                TableCell cartimg = new TableCell();
                cartimg.Width = 25;
                cartimg.HorizontalAlign = HorizontalAlign.Left;
                cartimg.Controls.Add(imgA);
                TableRow r6 = new TableRow();
                r6.Controls.Add(cartimg);
                r6.Controls.Add(txt);
                Table t2 = new Table();
                t2.Controls.Add(r1);
                //t2.Controls.Add(r2);
                t2.Controls.Add(r3);
                //t2.Controls.Add(r4);
                t2.Controls.Add(r5);
                t2.Controls.Add(r6);
                TableCell C2 = new TableCell();
                C2.VerticalAlign = VerticalAlign.Top;
                C2.Controls.Add(t2);
                TableRow Row1 = new TableRow();
                Row1.Controls.Add(C1);
                Row1.Controls.Add(C2);
                TableCell C3 = new TableCell();
                C3.ColumnSpan = 2;
                C3.Text = "<br/><br/><br/><b>Item Description</b>";
                TableRow Row2 = new TableRow();
                Row2.Controls.Add(C3);
                TableCell C4 = new TableCell();
                C4.ColumnSpan = 2;
                Label det = new Label();
                det.Text = tab.Rows[0]["Item_Details"].ToString();
                det.Width = 400;

                C4.Controls.Add(det);
                TableRow Row3 = new TableRow();
                Row3.Controls.Add(C4);
                TableBD.Controls.Add(Row1);
                TableBD.Controls.Add(Row2);
                TableBD.Controls.Add(Row3);
            }
        }

        void li_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_page.aspx");
        }

        void imgA_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login_page.aspx");
        }

        void btnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login_page.aspx");
        }


        //function to load comments
        private void loadComments()
        {
            DataTable tab = new DataTable();
            Admin_Class adminObj = new Admin_Class();

            tab.Rows.Clear();
            tab = adminObj.GetReviewsByItem(int.Parse(Session["Item_ID"].ToString()));

            if (tab.Rows.Count > 0)
            {
                Table1.Rows.Clear();

                Table1.BorderStyle = BorderStyle.Double;
                Table1.GridLines = GridLines.Both;
                //Table1.BackImageUrl = "Images/Opera-Background-Light-Blue";
                Table1.BorderColor = System.Drawing.Color.Black;

                TableRow mainrow = new TableRow();
                mainrow.Height = 20;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                mainrow.BackColor = System.Drawing.Color.Red;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>EmailId</b>";
                mainrow.Controls.Add(cell1);


                TableCell cell5 = new TableCell();
                cell5.Text = "<b>Review</b>";
                mainrow.Controls.Add(cell5);



                Table1.Controls.Add(mainrow);

                for (int cnt = 0; cnt < tab.Rows.Count; cnt++)
                {
                    TableRow row = new TableRow();

                    TableCell cell_details = new TableCell();
                    cell_details.Width = 250;
                    cell_details.Text = tab.Rows[cnt]["Email_ID"].ToString();
                    row.Controls.Add(cell_details);



                    TableCell cell_email = new TableCell();
                    cell_email.Width = 200;
                    cell_email.Text = tab.Rows[cnt]["Review"].ToString();
                    row.Controls.Add(cell_email);



                    Table1.Controls.Add(row);
                }
            }
            else
            {
                Table1.Rows.Clear();
                Table1.GridLines = GridLines.None;

                TableRow rno = new TableRow();

                TableCell cellno = new TableCell();
                cellno.ColumnSpan = 10;
                cellno.ForeColor = System.Drawing.Color.Red;
                cellno.Font.Size = 10;
                cellno.Text = "<b>No Reviews Found!!!</b>";
                cellno.HorizontalAlign = HorizontalAlign.Center;
                rno.Controls.Add(cellno);
                Table1.Controls.Add(rno);
            }
        }
       


    }
}
