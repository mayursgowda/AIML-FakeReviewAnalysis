using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace DATAMINING_ASSOCIATIONRULE
{
    public partial class PostReviews : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            TrainingDS();

            lblProductName.Font.Bold = true;
            lblProductName.ForeColor = System.Drawing.Color.Black;
            lblProductName.Text = "Item Name: " + Request.QueryString["ItemName"].ToString();
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
            OleDbCommand cmdReviewcnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdReviewcnt.Connection = connExcel;
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
                //        cmdReviewcnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where RESULT=" + dtDistinct.Rows[i]["RESULT"].ToString() + "";
                //        _arrayReviewCnt.Add(cmdReviewcnt.ExecuteScalar());
                //    }
                //}

                connExcel.Close();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }


        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();
        
        //Algorithm steps
        //function which contains the algorithm steps
        private string _NaiveBayes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 11;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;


            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < 11; j++)
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

        //Lesk algorithm
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //int _cntD = 0;
            //int _cntS = 0;

            Member_Class obj = new Member_Class();

            //string dipressed = null;
            //string satisfied = null;

            DataTable tabDipressed = new DataTable();
            DataTable tabSatisfied = new DataTable();

            tabDipressed = obj.GetWordnetByType("Depressed");
            tabSatisfied = obj.GetWordnetByType("Satisfied");

            //code to remove the stop words [preprocessing of data]
            string[] stopwords = { "a", "about", "above", "above", "across", "after", "afterwards", "again", "against", "all", "almost", "alone", "along", "already", "also", "although", "always", "am", "among", "amongst", "amoungst", "amount", "an", "and", "another", "any", "anyhow", "anyone", "anything", "anyway", "anywhere", "are", "around", "as", "at", "back", "be", "became", "because", "become", "becomes", "becoming", "been", "before", "beforehand", "behind", "being", "below", "beside", "besides", "between", "beyond", "bill", "both", "bottom", "but", "by", "call", "can", "cannot", "cant", "co", "con", "could", "couldnt", "cry", "de", "describe", "detail", "do", "done", "down", "due", "during", "each", "eg", "eight", "either", "eleven", "else", "elsewhere", "empty", "enough", "etc", "even", "ever", "every", "everyone", "everything", "everywhere", "except", "few", "fifteen", "fify", "fill", "find", "fire", "first", "five", "for", "former", "formerly", "forty", "found", "four", "from", "front", "full", "further", "get", "give", "go", "had", "has", "hasnt", "have", "he", "hence", "her", "here", "hereafter", "hereby", "herein", "hereupon", "hers", "herself", "him", "himself", "his", "how", "however", "hundred", "ie", "if", "in", "inc", "indeed", "interest", "into", "is", "it", "its", "itself", "keep", "last", "latter", "latterly", "least", "less", "ltd", "made", "many", "may", "me", "meanwhile", "might", "mill", "mine", "more", "moreover", "most", "mostly", "move", "much", "must", "my", "myself", "name", "namely", "neither", "never", "nevertheless", "next", "nine", "no", "nobody", "none", "noone", "nor", "nothing", "now", "nowhere", "of", "off", "often", "on", "once", "one", "only", "onto", "or", "other", "others", "otherwise", "our", "ours", "ourselves", "out", "over", "own", "part", "per", "perhaps", "please", "put", "rather", "re", "same", "see", "seem", "seemed", "seeming", "seems", "serious", "several", "she", "should", "show", "side", "since", "sincere", "six", "sixty", "so", "some", "somehow", "someone", "something", "sometime", "sometimes", "somewhere", "still", "such", "system", "take", "ten", "than", "that", "the", "their", "them", "themselves", "then", "thence", "there", "thereafter", "thereby", "therefore", "therein", "thereupon", "these", "they", "thickv", "thin", "third", "this", "those", "though", "three", "through", "throughout", "thru", "thus", "to", "together", "too", "top", "toward", "towards", "twelve", "twenty", "two", "un", "under", "until", "up", "upon", "us", "very", "via", "was", "we", "well", "were", "what", "whatever", "when", "whence", "whenever", "where", "whereafter", "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which", "while", "whither", "who", "whoever", "whole", "whom", "whose", "why", "will", "with", "within", "without", "would", "yet", "you", "your", "yours", "yourself", "yourselves", "the" };

            string[] sentance = null;
            sentance = txtReview.Text.Split('.');
            List<string> specialWords = new List<string>();
            int depressedCnt = 0;
            int satisfiedCnt = 0;

            int msgSize = 0;

            //load positive and negetive words
            List<string> _arrayDips = new List<string>();
            List<string> _arraySats = new List<string>();

            for (int k = 0; k < tabDipressed.Rows.Count; k++)
            {
                _arrayDips.Add(tabDipressed.Rows[k]["Keyword"].ToString());
            }

            for (int k = 0; k < tabSatisfied.Rows.Count; k++)
            {
                _arraySats.Add(tabSatisfied.Rows[k]["Keyword"].ToString());
            }

            //load end

            for (int z = 0; z < sentance.Length; z++)
            {
                specialWords.Clear();

                string[] opinion = sentance[z].Split(' ');

                msgSize += opinion.Length;

                for (int y = 0; y < sentance.Length; y++)
                {
                    sentance[y] = sentance[y].Replace(",", String.Empty);
                    sentance[y] = sentance[y].Replace("?", String.Empty);
                    sentance[y] = sentance[y].Replace(":", String.Empty);
                    sentance[y] = sentance[y].Replace("(", String.Empty);
                    sentance[y] = sentance[y].Replace(")", String.Empty);
                }

                for (int j = 0; j < opinion.Length; j++)
                {
                    if (!stopwords.Contains(opinion[j], StringComparer.InvariantCultureIgnoreCase))
                    {
                        specialWords.Add(opinion[j]);
                    }
                }


                //loading the keywords into string array
                string[] Keywords = specialWords.ToArray();

                //main code
                for (int q = 0; q < Keywords.Length; q++)
                {
                    if (Keywords[q].Contains("Not") || Keywords[q].Contains("not") || Keywords[q].Contains("NOT"))
                    {
                        string _nextword = Keywords[q + 1];

                        if (_arrayDips.Contains(_nextword, StringComparer.OrdinalIgnoreCase))
                        {
                            ++satisfiedCnt;
                            ++q;
                        }
                        else if (_arraySats.Contains(_nextword, StringComparer.OrdinalIgnoreCase))
                        {
                            ++depressedCnt;
                            ++q;
                        }
                    }
                    else
                    {
                        if (_arrayDips.Contains(Keywords[q], StringComparer.OrdinalIgnoreCase))
                        {
                            ++depressedCnt;
                        }
                        else if (_arraySats.Contains(Keywords[q], StringComparer.OrdinalIgnoreCase))
                        {
                            ++satisfiedCnt;
                        }
                    }
                }
                //end main code

                //for (int k = 0; k < tabDipressed.Rows.Count; k++)
                //{
                //    if (Keywords.Contains(tabDipressed.Rows[k]["Keyword"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                //    {
                //        if (Keywords.Contains("Not") || Keywords.Contains("not") || Keywords.Contains("NOT"))
                //        {
                //            satisfied += "Not " + tabDipressed.Rows[k]["Keyword"].ToString() + ",";
                //            ++satisfiedCnt;
                //        }
                //        else
                //        {
                //            dipressed += tabDipressed.Rows[k]["Keyword"].ToString() + ",";
                //            ++depressedCnt;
                //        }
                //    }
                //}

                //for (int k = 0; k < tabSatisfied.Rows.Count; k++)
                //{
                //    if (Keywords.Contains(tabSatisfied.Rows[k]["Keyword"].ToString(), StringComparer.InvariantCultureIgnoreCase))
                //    {
                //        if (Keywords.Contains("Not") || Keywords.Contains("not") || Keywords.Contains("NOT"))
                //        {
                //            dipressed += "Not " + tabSatisfied.Rows[k]["Keyword"].ToString() + ",";
                //            ++depressedCnt;
                //        }
                //        else
                //        {
                //            satisfied += tabSatisfied.Rows[k]["Keyword"].ToString() + ",";
                //            ++satisfiedCnt;
                //        }
                //    }
                //}
            }

            if (depressedCnt > 0 || satisfiedCnt > 0)
            {

                //if (depressedCnt > satisfiedCnt)
                //{
                //    ++_cntD;
                //}
                //else
                //{
                //    ++_cntS;
                //}
                if (depressedCnt == satisfiedCnt)
                {
                    lblPercentage.Text = "Type: Neutral";

                }

                else if (depressedCnt > satisfiedCnt)
                {
                    lblPercentage.Text = "Type : Negative";

                }
                else
                {
                    lblPercentage.Text = "Type : Positive";

                }

                Label2.Text = "Negative Cnt : " + depressedCnt.ToString();
                Label1.Text = "Positive Cnt : " + satisfiedCnt.ToString();
            }
            else
            {
                lblPercentage.Text = "No Keywords Matchings!!!";
            }

            Label5.Text ="Msg Size : "+ msgSize.ToString();
            Label6.Text = "Sentence : " + (sentance.Length-1).ToString();
            string _time = null;
            string _date = DateTime.Now.ToShortDateString();
            DateTime dateValue = DateTime.Parse(_date);
            string _day = dateValue.DayOfWeek.ToString();

            int _dayy = 0;

            if (_day.Equals("monday"))
            {
                _dayy = 1;
            }
            else if (_day.Equals("tuesday"))
            {
                _dayy = 2;
            }
            else if (_day.Equals("wednesday"))
            {
                _dayy = 3;
            }
            else if (_day.Equals("thursday"))
            {
                _dayy = 4;
            }
            else if (_day.Equals("friday"))
            {
                _dayy = 5;
            }
            else if (_day.Equals("saturday"))
            {
                _dayy = 6;
            }
            else if (_day.Equals("sunday"))
            {
                _dayy = 7;
            }
            

            if (DateTime.Now.Hour < 12)
            {
                _time = "morning";
                _time = "1";
            }

            else if (DateTime.Now.Hour < 16)
            {
                _time = "afternoon";
                _time = "2";
            }
            else if (DateTime.Now.Hour < 18)
            {
                _time = "evening";
                _time = "3";
            }
            else
            {
                _time = "night";
                _time = "4";
            }

            obj.InsertReview(Session["Customer_ID"].ToString(), int.Parse(Request.QueryString["ItemId"].ToString()), txtReview.Text);
            Label3.Text =" Time : "+ DateTime.Now.Hour.ToString();
            Label4.Text = " Day : " + dateValue.DayOfWeek.ToString();



            //algorithm
            DataTable tab = new DataTable();

            tab = obj.GetCustomerDetails(Session["Customer_ID"].ToString());

            int _loc = 0;
            int _howoften = 0;
            int _gender = 0;

            if (tab.Rows[0]["location"].ToString().Equals("Shimoga"))
            {
                _loc = 1;
            }
            else if (tab.Rows[0]["location"].ToString().Equals("Bengaluru"))
            {
                _loc = 2;

            }
            else if (tab.Rows[0]["location"].ToString().Equals("Mysuru"))
            {
                _loc = 3;
            }
            else if (tab.Rows[0]["location"].ToString().Equals("Mandya"))
            {
                _loc = 4;
            }

            //howoften
            if (tab.Rows[0]["Howoften"].ToString().Equals("daily"))
            {
                _howoften = 1;
            }
            else if (tab.Rows[0]["Howoften"].ToString().Equals("weekly"))
            {
                _howoften = 2;

            }
            else if (tab.Rows[0]["Howoften"].ToString().Equals("monthly"))
            {
                _howoften = 3;
            }

            //gender
            if (tab.Rows[0]["Gender"].ToString().Equals("male"))
            {
                _gender = 1;
            }
            else
            {
                _gender = 2;
            }

            string _data = _gender + "," + tab.Rows[0]["Age"].ToString() + "," +
                              tab.Rows[0]["Experience"].ToString() + "," + tab.Rows[0]["TotalPosts"].ToString() + "," +
                               msgSize + "," +
                                _howoften + "," + satisfiedCnt + "," +
                               depressedCnt + "," + _loc + "," +
                               _dayy + "," + _time;


            string[] values = _data.Split(',');

            string _output = _NaiveBayes(values);

            string _result = null;

            if (_output.Equals("1"))
            {
                _result = "FAKE";
            }
            else
            {
                _result = "REAL";
            }

            int _id = obj.GetMaxReviewId();
            obj.UpdateReview(_result, _id);

            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Review Posted Successfully')</script>");

            //Response.Redirect(string.Format("FakePrediction.aspx?Type={0}&Size={1}&PositiveCnt={2}&NegativeCnt={3}&Day={4}&Time={5}", lblProductName.Text, msgSize, satisfiedCnt, depressedCnt, _day, _time));

        }
    }
}