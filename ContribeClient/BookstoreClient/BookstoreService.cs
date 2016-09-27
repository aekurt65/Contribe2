using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookstoreInterface;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace BookstoreClient {
  public class BookstoreService : CommonClient.JsonClient, IBookstoreService {
    static BookstoreService _this = new BookstoreService();
    static public BookstoreService get() { return _this; }
    private BookstoreService() { }

    // Vi måste berätta för basklassen namnet på servicen
    override protected string pageName { get { return "BookstoreService.asmx"; } }

    // Namnet på alla metoderna
    private enum M {
      AddBookAsync,
      RemoveBookAsync,
      GetCustomerInfoAsync,
      PlaceOrderAllBooksInCartAsync,
      PlaceOrderAsync,
      GetBooksAsync,
      LongRunningTestAsync,
      ExceptionTestAsync,
      InformationTestAsync,
    }

    #region Interface implementation

    public Task<ICart> AddBookAsync(string UserID, string BookID) {
      return CallServerAsync<ICart, Cart>(M.AddBookAsync, UserID, BookID);
    }

    public Task<object> ExceptionTestAsync() {
      return CallServerAsync<object, object>(M.ExceptionTestAsync);
    }

    public Task<IEnumerable<IBook>> GetBooksAsync(string searchString) {
      return CallServerAsync<IEnumerable<IBook>, List<Book>>(M.GetBooksAsync, searchString);
    }

    public Task<ICustomerInfo> GetCustomerInfoAsync(string UserID) {
      return CallServerAsync<ICustomerInfo, CustomerInfo>(M.GetCustomerInfoAsync, UserID);
    }

    public Task<object> InformationTestAsync() {
      return CallServerAsync<object, object>(M.InformationTestAsync);
    }

    public Task<ICustomerInfo> PlaceOrderAsync(string UserID, string jsonDicBooksToOrder) {
      return CallServerAsync<ICustomerInfo, CustomerInfo>(M.PlaceOrderAsync, UserID, jsonDicBooksToOrder);
    }

    public Task<ICustomerInfo> PlaceOrderAllBooksInCartAsync(string UserID) {
      return CallServerAsync<ICustomerInfo, CustomerInfo>(M.PlaceOrderAllBooksInCartAsync, UserID);
    }

    public Task<ICart> RemoveBookAsync(string UserID, string BookID) {
      return CallServerAsync<ICart, Cart>(M.RemoveBookAsync, UserID, BookID);
    }

    public Task<string> LongRunningTestAsync(int milliSeconds) {
      return CallServerAsync<string, string>(M.LongRunningTestAsync, milliSeconds);
    }

    public string LongRunningTest(int milliSeconds) {
      throw new NotImplementedException();
    }

    #endregion
  }
}
