using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Threading.Tasks;
using Contribe2.BookstoreInterface;

namespace Contribe2 {
  public partial class Bookstore : System.Web.UI.Page {
    static IBookstoreService srvc = Factory.getBookstoreServer();

    protected void Page_Load(object sender, EventArgs e) {

    }

    [WebMethod]
    public static string CallMe() {
      return "You called me on " + DateTime.Now.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strSearch"></param>
    /// <returns></returns>
    [WebMethod]
    public static string SearchBooks(string strSearch) {
      try {
        Task<IEnumerable<IBook>> task = srvc.GetBooksAsync(strSearch);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    [WebMethod]
    public static string AddBook(string UserID, string BookID) {
      try {
        Task<ICart> task = srvc.AddBookAsync(UserID, BookID);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    [WebMethod]
    public static string RemoveBook(string UserID, string BookID) {
      try {
        Task<ICart> task = srvc.RemoveBookAsync(UserID, BookID);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    [WebMethod]
    public static string PlaceOrderAllBooksInCart(string UserID) {
      try {
        Task<ICustomerInfo> task = srvc.PlaceOrderAllBooksInCartAsync(UserID);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    [WebMethod]
    public static string ErrorTest(string UserID) {
      try {
        Task<ICustomerInfo> task = srvc.ErrorTestAsync(UserID);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    [WebMethod]
    public static string GetUserInfo(string UserID) {
      try {
        Task<ICustomerInfo> task = srvc.GetCustomerInfo(UserID);
        task.Wait();
        return GetOKRetStr(task.Result);
      }
      catch (Exception ex) {
        return HandleException(ex);
      }
    }

    private class RetObj {
      public string error = null;
      public string strValue = "";
    }

    private static string GetOKRetStr(object objValue) {
      RetObj obj = new RetObj();
      obj.strValue = Newtonsoft.Json.JsonConvert.SerializeObject(objValue);
      string strRet = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
      return strRet;
    }

    static private string HandleException(Exception ex) {
      string strRet;
      while (ex is AggregateException && ex.InnerException != null) {
        ex = ex.InnerException;
      }
      RetObj obj = new RetObj();
      try {
        obj.error = ex.Message;
        strRet = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
      }
      catch (Exception) {
        obj.error = "Server error";
        strRet = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
      }
      return strRet;
    }
  }
}
