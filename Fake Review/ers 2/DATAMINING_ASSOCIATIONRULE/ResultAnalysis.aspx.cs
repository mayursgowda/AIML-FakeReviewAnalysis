using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;


namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class ResultAnalysis : System.Web.UI.Page
    {
        double _outcomeCntKNN = 0;
        string _timeKNN = null;
        int _ActualCnt = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _Results();
            }
            catch
            {

            }
        }

        private void _Results()
        {
            Table1.Rows.Clear();

            Table1.BorderStyle = BorderStyle.Double;
            Table1.GridLines = GridLines.Both;
            Table1.BorderColor = System.Drawing.Color.Black;

            //mainrow
            TableRow mainrow = new TableRow();
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
            mainrow.BackColor = System.Drawing.Color.Black;

            TableCell cell1 = new TableCell();
            cell1.Width = 350;
            cell1.Text = "<b>Constraint</b>";
            mainrow.Controls.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Width = 200;
            cell2.Text = "<b>NB Algorithm</b>";
            mainrow.Controls.Add(cell2);

            Table1.Controls.Add(mainrow);

            CompareResults();

            //1st row
            TableRow row1 = new TableRow();

            TableCell cellAcc = new TableCell();
            cellAcc.Text = "<b>Accuracy</b>";
            row1.Controls.Add(cellAcc);

            TableCell cellAccKNN = new TableCell();
            //cal
            double _percentageKNN = (_outcomeCntKNN / _ActualCnt) * 100;
            cellAccKNN.Text = Math.Round(_percentageKNN,2).ToString() + "%";
            row1.Controls.Add(cellAccKNN);

            Table1.Controls.Add(row1);

            //2nd row           
            TableRow row2 = new TableRow();

            TableCell cellTime = new TableCell();
            cellTime.Text = "<b>Time (milli secs)</b>";
            row2.Controls.Add(cellTime);

            TableCell cellTimeKNN = new TableCell();
            cellTimeKNN.Text = _timeKNN;
            row2.Controls.Add(cellTimeKNN);

            Table1.Controls.Add(row2);

            //3rd row           
            TableRow row3 = new TableRow();

            TableCell cellCorrect = new TableCell();
            cellCorrect.Text = "<b>Correctly Classified</b>";
            row3.Controls.Add(cellCorrect);

            TableCell cellCorrectKNN = new TableCell();
            cellCorrectKNN.Text = Math.Round(_percentageKNN, 2).ToString() + "%";
            row3.Controls.Add(cellCorrectKNN);

            Table1.Controls.Add(row3);

            //4th row           
            TableRow row4 = new TableRow();

            TableCell cellInCorrect = new TableCell();
            cellInCorrect.Text = "<b>InCorrectly Classified</b>";
            row4.Controls.Add(cellInCorrect);

            TableCell cellInCorrectKNN = new TableCell();
            cellInCorrectKNN.Text = (100 - Math.Round(_percentageKNN, 2)).ToString() + "%";
            row4.Controls.Add(cellInCorrectKNN);

            Table1.Controls.Add(row4);

            TableRow row5 = new TableRow();

            TableCell outc = new TableCell();
            outc.Text = "<b>outcome</b>";
            row5.Controls.Add(outc);

            TableCell outcome = new TableCell();
            outcome.Text = _outcomeCntKNN.ToString();
            row5.Controls.Add(outcome);

            Table1.Controls.Add(row5);


            TableRow row6 = new TableRow();

            TableCell actual = new TableCell();
            actual.Text = "<b>actual</b>";
            row6.Controls.Add(actual);

            TableCell act = new TableCell();
            act.Text = _ActualCnt.ToString();
            row6.Controls.Add(act);

            Table1.Controls.Add(row6);
        }

        private void CompareResults()
        {
            string FileName = "ActualDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "ActualDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            string conStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                _ActualCnt = dt.Rows.Count;

                string[] _PResult = Session["Output1"].ToString().Split(',');

                _timeKNN = _PResult[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["result"].ToString().Equals(_PResult[i + 1]))
                    {
                        ++_outcomeCntKNN;
                    }
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Actual Dataset Found!!!')</script>");
            }

            connExcel.Close();

        }

       
    }
}