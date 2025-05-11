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
    public partial class AdminFakeReviews : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayReviewsCnt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();
                TestingDS();
            }
            catch
            {

            }
        }

        private void TestingDS()
        {
            string FileName = "TestingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TestingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTestingDS(FilePath, Extension, _Location);
        }

        private void ImportTestingDS(string FilePath, string Extension, string _Location)
        {
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

                //Bind Data to GridView

                GridView1.Caption = Path.GetFileName(FilePath);

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Testing Dataset Found!!!')</script>");
            }



            connExcel.Close();





        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
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
            OleDbCommand cmdDistinct = new OleDbCommand();
            OleDbCommand cmdReviewsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdReviewsCnt.Connection = connExcel;
            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdDistinct.CommandText = "SELECT DISTINCT(result) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                //if (dtDistinct.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtDistinct.Rows.Count; i++)
                //    {
                //        cmdReviewsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where RESULT=" + dtDistinct.Rows[i]["RESULT"].ToString() + "";
                //        _arrayReviewsCnt.Add(cmdReviewsCnt.ExecuteScalar());
                //    }
                //}

                connExcel.Close();

            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        protected void btnPrediction_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "TestingDataset.xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "TestingDataset";

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

                DataTable tabData = new DataTable();

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

                oda.Fill(tabData);

                //BLL obj = new BLL();

                int slNo = 1;

                if (tabData.Rows.Count > 0)
                {
                    Session["Output"] = null;
                    string _Predictedoutput = null;
                    string _timeKNN = null;

                    tablePrediction.Rows.Clear();

                    tablePrediction.BorderStyle = BorderStyle.Double;
                    tablePrediction.GridLines = GridLines.Both;
                    tablePrediction.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.Black;

                    TableCell cell0 = new TableCell();
                    cell0.Width = 100;
                    cell0.Text = "<b>SlNo</b>";
                    mainrow.Controls.Add(cell0);

                    TableCell cell1 = new TableCell();
                    cell1.Width = 100;
                    cell1.Text = "<b>gender</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>age</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>experience</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>total_posts</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>message_type</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>message_size</b>";
                    mainrow.Controls.Add(cell6);

                    TableCell cell7 = new TableCell();
                    cell7.Text = "<b>how_often</b>";
                    mainrow.Controls.Add(cell7);

                    TableCell cell8 = new TableCell();
                    cell8.Text = "<b>positive_words_count</b>";
                    mainrow.Controls.Add(cell8);

                    TableCell cell9 = new TableCell();
                    cell9.Text = "<b>negative_words_count</b>";
                    mainrow.Controls.Add(cell9);

                    TableCell cell10 = new TableCell();
                    cell10.Text = "<b>location</b>";
                    mainrow.Controls.Add(cell10);

                    TableCell cell11 = new TableCell();
                    cell11.Text = "<b>day</b>";
                    mainrow.Controls.Add(cell11);

                    TableCell cell12 = new TableCell();
                    cell12.Text = "<b>time</b>";
                    mainrow.Controls.Add(cell12);

                    TableCell cell25 = new TableCell();
                    cell25.Text = "<b>Result</b>";
                    mainrow.Controls.Add(cell25);

                    tablePrediction.Controls.Add(mainrow);

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 0; i < tabData.Rows.Count; i++)
                    {

                        string _data = tabData.Rows[i]["gender"].ToString() + "," + tabData.Rows[i]["age"].ToString() + "," +
                            tabData.Rows[i]["experience"].ToString() + "," + tabData.Rows[i]["total_posts"].ToString() + "," +
                            tabData.Rows[i]["message_type"].ToString() + "," + tabData.Rows[i]["message_size"].ToString() + "," +
                            tabData.Rows[i]["how_often"].ToString() + "," + tabData.Rows[i]["positive_words_count"].ToString() + "," +
                            tabData.Rows[i]["negative_words_count"].ToString() + "," + tabData.Rows[i]["location"].ToString() + "," + tabData.Rows[i]["day"].ToString() + "," +
                            tabData.Rows[i]["time"].ToString();


                        string[] values = _data.Split(',');

                        string _output = _NaiveBayes(values);

                        TableRow row = new TableRow();

                        TableCell _cell0 = new TableCell();
                        _cell0.Text = slNo + i + ".";
                        row.Controls.Add(_cell0);

                        TableCell _cell1 = new TableCell();
                        _cell1.Text = tabData.Rows[i]["gender"].ToString();
                        row.Controls.Add(_cell1);

                        TableCell _cell2 = new TableCell();
                        _cell2.Text = tabData.Rows[i]["age"].ToString();
                        row.Controls.Add(_cell2);

                        TableCell _cell3 = new TableCell();
                        _cell3.Text = tabData.Rows[i]["experience"].ToString();
                        row.Controls.Add(_cell3);

                        TableCell _cell4 = new TableCell();
                        _cell4.Text = tabData.Rows[i]["total_posts"].ToString();
                        row.Controls.Add(_cell4);

                        TableCell _cell5 = new TableCell();
                        _cell5.Text = tabData.Rows[i]["message_type"].ToString();
                        row.Controls.Add(_cell5);

                        TableCell _cell6 = new TableCell();
                        _cell6.Text = tabData.Rows[i]["message_size"].ToString();
                        row.Controls.Add(_cell6);

                        TableCell _cell7 = new TableCell();
                        _cell7.Text = tabData.Rows[i]["how_often"].ToString();
                        row.Controls.Add(_cell7);

                        TableCell _cell8 = new TableCell();
                        _cell8.Text = tabData.Rows[i]["positive_words_count"].ToString();
                        row.Controls.Add(_cell8);

                        TableCell _cell24 = new TableCell();
                        _cell24.Text = tabData.Rows[i]["negative_words_count"].ToString();
                        row.Controls.Add(_cell24);

                        TableCell _cell9 = new TableCell();
                        _cell9.Text = tabData.Rows[i]["location"].ToString();
                        row.Controls.Add(_cell9);

                        TableCell _cell10 = new TableCell();
                        _cell10.Text = tabData.Rows[i]["day"].ToString();
                        row.Controls.Add(_cell10);

                        TableCell _cell11 = new TableCell();
                        _cell11.Text = tabData.Rows[i]["time"].ToString();
                        row.Controls.Add(_cell11);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 250;
                        cellResult.Text = _output;
                        row.Controls.Add(cellResult);

                        tablePrediction.Controls.Add(row);

                        //if (_output.Equals("0"))
                        //{
                        //    ++_array0Res;
                        //}
                        //else if (_output.Equals("1"))
                        //{
                        //    ++_array1Res;
                        //}         

                        _Predictedoutput += _output + ",";
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeKNN = elapsedMs.ToString();

                    Session["Output1"] = _timeKNN + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);
                }
            }
            catch
            {

            }
        }

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();


        //function which contains the algorithm steps
        private string _NaiveBayes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 12;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;


            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < 12; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][j].ToString().Equals(values[j]))
                        {
                            ++n;

                            if (dt.Rows[d][m].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            string _output = null;

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();

                    //if (_output.Equals("0"))
                    //{
                    //    _output = "No";
                    //}
                    //else
                    //{
                    //    _output = "Yes";
                    //}

                    return _output;
                }
            }
            //}
            //catch
            //{

            //}

            return _output;
        }


        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    if (dtDistinct.Rows[i]["result"].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        s.Add(dtDistinct.Rows[i]["result"].ToString());
                    }
                }
            }

            return s;
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            btnPrediction_Click(sender, e);
            Response.Redirect("ResultAnalysis.aspx");
        }               
      
    }
}