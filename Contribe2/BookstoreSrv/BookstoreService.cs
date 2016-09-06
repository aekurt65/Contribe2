using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  class BookstoreService : IBookstoreService {
    static BookstoreService _this = new BookstoreService();
    static public IBookstoreService get() {
      return _this;
    }
    srvBookStore worker = srvBookStore.get();

    public Task<IEnumerable<IBook>> GetBooksAsync(string name) {
      return Task<IEnumerable<IBook>>.Factory.StartNew(() => worker.SearchBooks(name));
    }
    public Task<ICart> AddBookAsync(string UserID, string BookID) {
      return Task<ICart>.Factory.StartNew(() => worker.AddBookToCart(UserID, BookID));
    }
    public Task<ICart> RemoveBookAsync(string UserID, string BookID) {
      return Task<ICart>.Factory.StartNew(() => worker.RemoveBookFromCart(UserID, BookID));
    }
    public Task<ICustomerInfo> PlaceOrderAllBooksInCartAsync(string UserID) {
      return Task<ICustomerInfo>.Factory.StartNew(() => worker.PlaceOrderAllbooksInCart(UserID));
    }
    public Task<ICustomerInfo> GetCustomerInfo(string UserID) {
      return Task<ICustomerInfo>.Factory.StartNew(() => worker.GetCustomerInfo(UserID));
    }
    public Task<ICustomerInfo> ErrorTestAsync(string UserID) {
      return Task<ICustomerInfo>.Factory.StartNew(() => worker.ErrorTest(UserID));
    }
  }
}
