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
    public partial class ReviewOrder : System.Web.UI.Page
    {
        Visitor obj = new Visitor();
        Member_Class obj1 = new Member_Class();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Customer_ID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    if (Session["Cart"].ToString() == "1")
                    {
                        viewCart();
                    }
                    else
                    {
                        Response.Redirect("Member_Homepage.aspx");
                    }
                }
            }
            catch
            {

            }
        }

        private void viewCart()
        {
            // PnlOF.Visible = false;
            PnlCTab.Visible = true;
            Table4.Rows.Clear();
            TableRow r1 = new TableRow();
            r1.Font.Size = 11;
            r1.Font.Bold = true;
            // r1.BackColor = System.Drawing.Color.RoyalBlue;
            Label l10 = new Label();
            l10.Text = "|";
            Label l11 = new Label();
            l11.Text = "|";
            Label l12 = new Label();
            l12.Text = "|";
            Label l13 = new Label();
            l13.Text = "|";
            Label l14 = new Label();
            l14.Text = "|";
            TableCell Ch0 = new TableCell();
            Ch0.Controls.Add(l10);
            TableCell Ch1 = new TableCell();
            Ch1.Controls.Add(l11);
            TableCell Ch2 = new TableCell();
            Ch2.Controls.Add(l12);
            TableCell Ch3 = new TableCell();
            Ch3.Controls.Add(l13);
            TableCell Ch4 = new TableCell();
            Ch4.Controls.Add(l14);

            TableCell h1 = new TableCell();

            //h1.ForeColor = System.Drawing.Color.White;
            h1.Text = "";
            TableCell h2 = new TableCell();
            h2.Width = 100;
            // h2.ForeColor = System.Drawing.Color.White;
            h2.Text = "SubCategory";
            TableCell h3 = new TableCell();
            h3.Width = 100;
            // h3.ForeColor = System.Drawing.Color.White;
            h3.Text = "Item_ID";

            TableCell h31 = new TableCell();
            h31.Width = 100;
            // h3.ForeColor = System.Drawing.Color.White;
            h31.Text = "Item_Name";
            
            TableCell h4 = new TableCell();
            h4.Width = 100;
            //  h4.ForeColor = System.Drawing.Color.White;
            h4.Text = "Quantity";
            TableCell h5 = new TableCell();
            h5.Width = 100;
            // h5.ForeColor = System.Drawing.Color.White;
            h5.Text = "Amount";

            r1.Controls.Add(h1);
            r1.Controls.Add(Ch1);
            r1.Controls.Add(h2);
            r1.Controls.Add(Ch2);
            r1.Controls.Add(h3);
            r1.Controls.Add(Ch3);
            r1.Controls.Add(h31);
            r1.Controls.Add(Ch0);
            r1.Controls.Add(h4);
            r1.Controls.Add(Ch4);
            r1.Controls.Add(h5);
            Table4.Controls.Add(r1);
            TableCell Chr = new TableCell();
            Chr.ColumnSpan = 12;
            Chr.Text = "<hr/>";
            TableRow Rhr = new TableRow();
            Rhr.Controls.Add(Chr);
            Table4.Controls.Add(Rhr);
            DataTable cart = new DataTable();
            cart = obj.GetCartDetails(Session["Customer_ID"].ToString());

            if (cart.Rows.Count > 0)
            {
                double TCost = 0;
                for (int i = 0; i < cart.Rows.Count; i++)
                {
                    Label l20 = new Label();
                    l20.Text = "|";
                    Label l21 = new Label();
                    l21.Text = "|";
                    Label l22 = new Label();
                    l22.Text = "|";
                    Label l23 = new Label();
                    l23.Text = "|";
                    Label l24 = new Label();
                    l24.Text = "|";

                    TableCell Ch10 = new TableCell();
                    Ch10.Controls.Add(l20);
                    TableCell Ch11 = new TableCell();
                    Ch11.Controls.Add(l21);
                    TableCell Ch12 = new TableCell();
                    Ch12.Controls.Add(l22);
                    TableCell Ch13 = new TableCell();
                    Ch13.Controls.Add(l23);
                    TableCell Ch14 = new TableCell();
                    Ch14.Controls.Add(l24);

                    CheckBox cb = new CheckBox();
                    cb.AutoPostBack = true;
                    cb.ToolTip = "click here to remove the book from the cart";
                    cb.ID = cart.Rows[i]["Cart_ID"].ToString() + "_04" + i;
                    cb.Checked = true;
                    cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
                    TableCell c21 = new TableCell();
                    c21.Controls.Add(cb);
                    DataTable Item=new DataTable ();
                    Item = obj.GetItemDetails(int.Parse(cart.Rows[i]["Item_ID"].ToString()));
                    DataTable cat = new DataTable();
                    cat = obj.GetSubCategoryDetails(int.Parse(Item.Rows[0]["SubCategory_ID"].ToString()));
                    TableCell c22 = new TableCell();
                    c22.Text = cat.Rows[0]["SubCategory_Name"].ToString();
                    TableCell c23 = new TableCell();
                    Label lbl_ItemID = new Label();
                    lbl_ItemID.ID = "textmatrix" + i;
                    lbl_ItemID.Text=Item.Rows[0]["Item_ID"].ToString();
                    c23.Controls.Add(lbl_ItemID);
                    TableCell c203 = new TableCell();
                    Label lbl_ItemName = new Label();
                    lbl_ItemName.ID = "textmatrix0" + i;
                    lbl_ItemName.Text = Item.Rows[0]["Item_Name"].ToString();
                    c203.Controls.Add(lbl_ItemName);
                    TableCell c24 = new TableCell();
                    Label lbl_Quantity = new Label();
                    lbl_Quantity.ID = "textmatrix1" + i;
                    lbl_Quantity.Text = cart.Rows[i]["Quantity"].ToString();
                    c24.Controls.Add(lbl_Quantity);
                    TableCell c25 = new TableCell();
                    double total = int.Parse(cart.Rows[i]["Quantity"].ToString()) * double.Parse(Item.Rows[0]["Item_Cost"].ToString());
                    c25.Text = total.ToString();
                    TCost += total;
                    TableRow r2 = new TableRow();
                    r2.Controls.Add(c21);
                    r2.Controls.Add(Ch11);
                    r2.Controls.Add(c22);
                    r2.Controls.Add(Ch12);
                    r2.Controls.Add(c23);
                    r2.Controls.Add(Ch13);

                    r2.Controls.Add(c203);
                    r2.Controls.Add(Ch10);
                   
                    r2.Controls.Add(c24);
                    r2.Controls.Add(Ch14);
                    r2.Controls.Add(c25);
                    Table4.Controls.Add(r2);

                }
                TableCell c51 = new TableCell();
                c51.Text = "<hr>";
                c51.ColumnSpan = 11;
                TableRow r5 = new TableRow();
                r5.Controls.Add(c51);
                Table4.Controls.Add(r5);
                TableCell c31 = new TableCell();
                c31.ColumnSpan = 9;
                c31.HorizontalAlign = HorizontalAlign.Right;
                c31.Text = "<b>Shipping Cost</b>";
                double Scost;
                DataTable tab_mem = obj.GetCustomerDetails(Session["Customer_ID"].ToString());
                if (tab_mem.Rows[0]["Country"].ToString().ToLower() == "india")
                    Scost = 50.00;
                else
                    Scost = 500.00;
                TCost += Scost;
                TableCell C32 = new TableCell();
                C32.Text = "|";
                TableCell c33 = new TableCell();
                c33.Text = Scost.ToString();
                TableRow r3 = new TableRow();
                r3.Controls.Add(c31);
                r3.Controls.Add(C32);
                r3.Controls.Add(c33);
                Table4.Controls.Add(r3);
                LblCost.Text = TCost.ToString();
                TableCell c41 = new TableCell();
                c41.ColumnSpan = 9;
                c41.HorizontalAlign = HorizontalAlign.Right;
                c41.Text = "<b>Total</b>";
                TableCell C42 = new TableCell();
                C42.Text = "|";
                TableCell c43 = new TableCell();
                c43.Text = TCost.ToString();
                TableRow r4 = new TableRow();
                r4.Controls.Add(c41);
                r4.Controls.Add(C42);
                r4.Controls.Add(c43);
                Table4.Controls.Add(r4);

                //CC.CurrencyConvertor obj1 = new DATAMINING_ASSOCIATIONRULE.CC.CurrencyConvertor();
                //double d = obj1.ConversionRate(DATAMINING_ASSOCIATIONRULE.CC.Currency.INR, DATAMINING_ASSOCIATIONRULE.CC.Currency.USD);
                //double Tdollar = TCost * d;
                Label5.Text = TCost.ToString();
            }
            else
            {
                Session["Cart"] = "0";
                Response.Redirect("ReviewOrder.aspx");
            }
        }

        void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbx = (CheckBox)sender;
            string[] id = chbx.ID.ToString().Split('_');
            if (chbx.Checked == false)
            {
                obj.DeleteCartDetails(int.Parse(id[0]));

            }
            viewCart();
        }

        int h = 0;

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            //if (Session["Cart"].ToString() == "1")
            //{
            //    double cost = 0.0;
            //    DataTable tabcart = new DataTable();
            //    tabcart = vobj.GetCartDetails(Session["Visitor"].ToString());
            //    if (tabcart.Rows.Count > 0)
            //    {
            //        if (mobj.CountOfOrder(Session["Visitor"].ToString()))
            //        {
            //            for (int i = 0; i < tabcart.Rows.Count; i++)
            //            {

            //                DataTable book = vobj.GetBookDetails(int.Parse(tabcart.Rows[i]["BookNo"].ToString()));
            //                cost += int.Parse(tabcart.Rows[i]["Quantity"].ToString()) * double.Parse(book.Rows[0]["Price"].ToString());
            //            }
            //            cost += int.Parse(Table4.Rows[Table4.Rows.Count - 2].Cells[2].Text);
            //            DataTable email = vobj.GetUserDetails_Id(Session["UserName"].ToString());
            //            string strpath = string.Format("payform.aspx?EmailId={0}&No={1}&amount={2}", email.Rows[0]["EmailId"].ToString(), Session["Visitor"].ToString(), Label5.Text);
            //            Response.Redirect(strpath);
            //        }

            //    }
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Failed to Order')</script>");
            //}

            //Response.Redirect("temp.aspx");

            try
            {
                int q = 0;

                obj1.NewCustomerTransaction(Session["Customer_ID"].ToString(),DateTime.Now);

                int transactionID = int.Parse(obj1.GetTransactionID().ToString());
                
                foreach (TableRow tabrow in Table4.Rows)
                {
                    int f = Table4.Rows.Count;

                    if (q <=Table4.Rows.Count - 5)
                    {
                        for (int i = 0; i < tabrow.Cells.Count - 10; i++)
                        {
                            Label l1 = (Label)Table4.FindControl("textmatrix" + h);
                            Label l2 = (Label)Table4.FindControl("textmatrix1" + h);
                            
                            h++;

                            obj1.NewTransactionDetails(transactionID, int.Parse(l1.Text.ToString()), int.Parse(l2.Text.ToString()));
                            DataTable tabitemdetails = new DataTable();
                            tabitemdetails = obj1.GetItemDetails(int.Parse(l1.Text.ToString()));
                            int itemquantity = int.Parse(tabitemdetails.Rows[0]["Quantity"].ToString());
                            int remaining = itemquantity - int.Parse(l2.Text.ToString());
                            obj1.UpdateItemQuantity(remaining, int.Parse(l1.Text.ToString()));

                        }
                       
                        ++q;
                    }
                }

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Successfull Transaction')</script>");
                obj.DeleteCartDetails(Session["Customer_ID"].ToString());
                
                Table4.Rows.Clear();

                TableHeaderRow row = new TableHeaderRow();
                TableHeaderCell cell = new TableHeaderCell();
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Bold = true;
                cell.Text = "Shopping Cart details Empty";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);
                Table4.Controls.Add(row);
                BtnPay.Visible = false;
                //viewCart();
                //Session.Remove("
                
            }
            catch
            {

            }

        }


    }
}
