using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class ViewReviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReviews();
        }


        //function to load reviews
        private void GetReviews()
        {
            try
            {
                DataTable tab = new DataTable();
                Member_Class obj = new Member_Class();

                int serialNo = 1;

                tab = obj.GetAllReviews();

                if (tab.Rows.Count > 0)
                {
                    tableNews.Rows.Clear();

                    tableNews.BorderStyle = BorderStyle.Double;
                    tableNews.GridLines = GridLines.Both;
                    tableNews.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.Black;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Member Id</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Review</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell31 = new TableCell();
                    cell31.Text = "<b>Status</b>";
                    mainrow.Controls.Add(cell31);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell6);

                    tableNews.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellUserId = new TableCell();
                        cellUserId.Width = 150;
                        cellUserId.Text = tab.Rows[i]["Email_ID"].ToString();
                        row.Controls.Add(cellUserId);

                        TableCell cellName = new TableCell();
                        cellName.Width = 550;
                        cellName.Text = tab.Rows[i]["Review"].ToString();
                        row.Controls.Add(cellName);

                        TableCell cellstatus = new TableCell();
                        cellstatus.Width = 150;
                        cellstatus.Text = tab.Rows[i]["Status"].ToString();
                        row.Controls.Add(cellstatus);


                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = tab.Rows[i]["ReviewId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this User?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        tableNews.Controls.Add(row);
                    }
                }
                else
                {
                    tableNews.Rows.Clear();

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Reviews Found!!!";

                    rno.Controls.Add(cellno);
                    tableNews.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        //event to delete member
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            Member_Class obj = new Member_Class();
            LinkButton lbtn = (LinkButton)sender;

            try
            {
                obj.DeleteReview(int.Parse(lbtn.ID));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Review Deleted Successfully!!!')</script>");
                GetReviews();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }
    }
}