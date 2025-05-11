using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DATAMINING_ASSOCIATIONRULE.DataLayerTableAdapters;

namespace DATAMINING_ASSOCIATIONRULE
{
    public class Member_Class
    {
        Customer_TransactionsTableAdapter cust_transaction_obj = new Customer_TransactionsTableAdapter();
        Transaction_DetailsTableAdapter transactiondetails_obj = new Transaction_DetailsTableAdapter();
        Item_SubCategoryTableAdapter subcategory_obj = new Item_SubCategoryTableAdapter();
        Item_DetailsTableAdapter item_obj = new Item_DetailsTableAdapter();
        Customer_DetailsTableAdapter customer_obj = new Customer_DetailsTableAdapter();
        FeedbacksTableAdapter feedback_obj = new FeedbacksTableAdapter();
        DataTable2TableAdapter dt2Obj = new DataTable2TableAdapter();
        RatingsTableAdapter itemfeedbackObj = new RatingsTableAdapter();

        Item_DetailsTableAdapter itemObj = new Item_DetailsTableAdapter();

        Item_CategoryTableAdapter category_obj = new Item_CategoryTableAdapter();

        tblKeywordsTableAdapter keywordObj = new tblKeywordsTableAdapter();
        tblReviewsTableAdapter reviewObj = new tblReviewsTableAdapter();

        #region ------ CUSTOMER CHANGEPASSWORD -------

        public void Customer_Changepwd(string pwd, string EmailID)
        {
            customer_obj.ChangeCustomerPassword(pwd, EmailID);
        }


        #endregion

        #region ------ CUSTOMER TRANSACTIONS ---------

        public void NewCustomerTransaction(string emailID, DateTime transactiondate)
        {
            cust_transaction_obj.NewTransaction(emailID, transactiondate);
        }

        public int GetTransactionID()
        {
            return (int)cust_transaction_obj.GetTransactionID();
        }

        public void NewTransactionDetails(int transactionID, int itemID, int Quantity)
        {
            transactiondetails_obj.NewTransactionDetails(transactionID, itemID, Quantity);
        }

        public DataTable GetCustomerTransactions(string emailID)
        {
            return cust_transaction_obj.GetCustomerTransactions(emailID);
        }

        public DataTable GetCustomerTransactionsBasedonStatus(string emailID, string status)
        {
            return cust_transaction_obj.GetCustomerTransactionsBasedonStatus(emailID, status);
        }

        public DataTable GetTransactionDetails(int transactionID)
        {
            return transactiondetails_obj.GetTransactionDetails(transactionID);
        }

        public DataTable GetItemDetails(int ItemID)
        {
            return item_obj.GetItemDetails(ItemID);
        }

        public DataTable GetSubCategoryDetails(int SubcategoryID)
        {
            return subcategory_obj.GetSubCategoryDetails(SubcategoryID);
        }

        public DataTable GetCustomerDetails(string EmailID)
        {
            return customer_obj.GetCustomerDetails(EmailID);
        }

        public void UpdateItemQuantity(int Quantity, int ItemID)
        {
            item_obj.UpdateItemQuantity(Quantity, ItemID).ToString();
        }


        #endregion

        #region ------ MANAGE FEEDBACKS -------

        public void Insert_Feedback(string EmailID, string feedback, string date)
        {
            feedback_obj.Insert_Feedback(EmailID, feedback, date);
        }




        #endregion

        public DataTable GetCustomerDistinctItemsByDate(string EmailId, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetCustomerDistinctItemsByDate(EmailId, startDate, endDate);
        }

        public DataTable GetCustomerDistinctItems(string EmailId)
        {
            return dt2Obj.GetCustomerDistinctItems(EmailId);
        }



        public void NewItemFeedback(int ItemId, string EmailId, int rating, DateTime PostedDate, string comment)
        {
            itemfeedbackObj.InsertRating(ItemId, EmailId, rating, PostedDate, comment);
        }

        public DataTable GetItemFeedbacks(int ItemId)
        {
            return itemfeedbackObj.GetRatingsByItem(ItemId);
        }

        //function to check the customer rating
        public bool CheckCustomerRating(string emailId, int itemId)
        {
            int cnt = int.Parse(itemfeedbackObj.CheckCustomerRating(emailId, itemId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to get te cutomer ratings
        public DataTable GetCustomerRating(string emailId, int itemId)
        {
            return itemfeedbackObj.GetCustomerRatings(emailId, itemId);
        }

        //functio to delete th rating
        public void DeleteRating(int ratingId)
        {
            itemfeedbackObj.DeleteRating(ratingId);
        }

        //function to get the trans by date
        public DataTable GetTransByDate(DateTime startDate, DateTime endDate)
        {
            return cust_transaction_obj.GetTransactionsbyDate(startDate, endDate);
        }

        //function to get all products
        public DataTable GetAllProductsss()
        {
            return itemObj.GetData();
        }

        //function to get the product by id
        public DataTable GetProductById(int productId)
        {
            return itemObj.GetItemDetails(productId);
        }

        public DataTable GetAllCustomers()
        {
            return customer_obj.GetData();
        }

        #region Market Segmentation

        public DataTable GetTransactionsByGender(string gender, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByGender(gender, startDate, endDate);
        }

        public DataTable GetTransactionsByDOB(string startDOB, string endDOB, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByDOB(startDOB, endDOB, startDate, endDate);
        }

        public DataTable GetTransactionsByMartialStatus(string MartialStatus, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByMartialstatus(MartialStatus, startDate, endDate);
        }

        public DataTable GetTransactionsByEducation(string Education, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByEducation(Education, startDate, endDate);
        }

        public DataTable GetTransactionsByOccupation(string Occupation, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByOccupation(Occupation, startDate, endDate);
        }

        public DataTable GetTransactionsByIncome(string Income, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByIncome(Income, startDate, endDate);
        }

        public DataTable GetDistinctItemsByGender(string gender, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByGender(gender, startDate, endDate);
        }

        public DataTable GetDistinctItemsByDOB(string startDOB, string endDOB, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByDOB(startDOB, endDOB, startDate, endDate);
        }

        public DataTable GetDistinctItemsByMartialStatus(string MartialStatus, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByMartialStatus(MartialStatus, startDate, endDate);
        }

        public DataTable GetDistinctItemsByEducation(string Education, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByEducation(Education, startDate, endDate);
        }

        public DataTable GetDistinctItemsByOccupation(string Occupation, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByOccupation(Occupation, startDate, endDate);
        }

        public DataTable GetDistinctItemsByIncome(string Income, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByIncome(Income, startDate, endDate);
        }

        //get transactions by date
        public DataTable GetTransactionsByDate(string gender, string DOB, string martialStatus, string education, string occupation, string income, string city, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByDate(gender, DOB, martialStatus, occupation, education, income, city, startDate, endDate);
        }

        //get distinct items
        public DataTable GetDistinctItemsByDate(string gender, string DOB, string martialStatus, string education, string occupation, string income, string city, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByDate(gender, DOB, martialStatus, occupation, education, income, city, startDate, endDate);
        }

        //get distinct items by locality
        public DataTable GetDistinctItemsByLocality(string city, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetDistinctItemsByLocality(city, startDate, endDate);
        }

        //get transactions by locality
        public DataTable GetTransactionsByLocality(string city, DateTime startDate, DateTime endDate)
        {
            return dt2Obj.GetTransactionsByCity(city, startDate, endDate);
        }


        #endregion

        //function to get the other users
        public DataTable GetOtherCustomers(string emailId, string AOI)
        {
            return customer_obj.GetOtherCustomers(emailId, AOI);
        }

        public DataTable GetCustTransByDate(string emailId, DateTime sdate, DateTime eDate)
        {
            return cust_transaction_obj.GetCustomerTransByDate(emailId, sdate, eDate);
        }

        public DataTable SearchItems(string parameter)
        {
            return item_obj.SearchItems(parameter);
        }

        public DataTable GetCategoryDetails(int categoryID)
        {
            return category_obj.GetCategoryDetails(categoryID);
        }




        //function to fetch wordnet by type
        public DataTable GetWordnetByType(string type)
        {
            return keywordObj.GetWordnetByType(type);
        }

        //News Management
        //function to get all reviews
        public DataTable GetAllReviews()
        {
            return reviewObj.GetData();
        }

        //function to insert new review
        public void InsertReview(string memberId, int itemId, string review)
        {
            reviewObj.InsertReview(memberId, itemId, review);
        }

        //function to update review
        public void UpdateReview(string status, int reviewId)
        {
            reviewObj.UpdateStatus(status, reviewId);
        }

        //function to get max id
        public int GetMaxReviewId()
        {
            return (int)reviewObj.GetMaxReviewId();
        }

        //function to delete review
        public void DeleteReview(int reviewId)
        {
            reviewObj.DeleteReview(reviewId);
        }




    }

}
