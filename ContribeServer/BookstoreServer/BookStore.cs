using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookstoreInterface;

namespace BookstoreServer {

  /// <summary>
  /// Switch class for Bookstore server.
  /// All calls to the Bookstore server are supposed to go through this class.
  /// </summary>
  public class Bookstore : Common.Singleton<Bookstore> {
    Books books = Books.Instance;
    Customers customers = Customers.Instance;

    public IEnumerable<IBook> GetBooks(string strSearch) {
      return books.searchBooks(strSearch);
    }

    public ICart AddBookToCart(string UserID, string BookID) {
      Customer customer = customers.GetCustomerByID(UserID);
      return customer.AddBookToCart(BookID);
    }

    public ICart RemoveBookFromCart(string UserID, string BookID) {
      Customer customer = customers.GetCustomerByID(UserID);
      return customer.RemoveBookFromCart(BookID);
    }

    public ICustomerInfo PlaceOrderAllbooksInCart(string UserID) {
      Customer customer = customers.GetCustomerByID(UserID);
      return customer.AddItemsFromCart();
    }

    public ICustomerInfo PlaceOrder(string UserID, string jsonDicBooksToOrder) {
      Dictionary<string, int> dicBooksToOrder;
      try {
        dicBooksToOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonDicBooksToOrder);
      } catch(Exception ex) {
        throw new Exception("Error deserializing parameter jsonDicBooksToOrder", ex);
      }
      Customer customer = customers.GetCustomerByID(UserID);
      return customer.OrderBooks(dicBooksToOrder);
    }

    public ICustomerInfo GetCustomerInfo(string UserID) {
      return customers.GetCustomerByID(UserID);
    }

    public object ExceptionTest() {
      throw new Exception(Txt.ExceptionTest);
    }

    public object InformationTest() {
      throw new Common.InfoException(Txt.InformationTest);
    }

    public string LongRunningTest(int milliSeconds) {
      string strStartTime = DateTime.Now.ToString("HH:mm:ss");
      System.Threading.Thread.Sleep(milliSeconds);
      string strEndTime = DateTime.Now.ToString("HH:mm:ss");
      return string.Format(Txt.LongRunningResponse, strStartTime, strEndTime);
    }
  }
}
