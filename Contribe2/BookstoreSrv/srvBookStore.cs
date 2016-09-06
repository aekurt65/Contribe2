using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  class srvBookStore {
    private srvBookStore() { }
    private static srvBookStore _me = new srvBookStore();
    public static srvBookStore get() { return _me; }

    dbBookStore db = dbBookStore.get();
    Carts carts = Carts.get();
    PlacedOrders orders = PlacedOrders.get();

    public List<IBook> SearchBooks(string strSearch) {
      string[] arSearchStrings = Utils.SplitWhiteChar(strSearch);
      List<string> lstSearchStrings = new List<string>(arSearchStrings);
      return db.searchBooks(lstSearchStrings);
    }

    public ICart AddBookToCart(string UserID, string BookID) {
      Cart cart = carts.AddBookInCart(UserID, BookID);
      return cart;
    }

    public ICart RemoveBookFromCart(string UserID, string BookID) {
      Cart cart = carts.RemoveBookFromCart(UserID, BookID);
      return cart;
    }

    public ICustomerInfo PlaceOrderAllbooksInCart(string UserID) {
      Cart cart = carts.GetCartForUser(UserID);
      PlacedOrder order = orders.GetOrderForUser(UserID);
      return order.AddItemsFromCart(UserID, cart);
    }

    public ICustomerInfo GetCustomerInfo(string UserID) {
      return new CustomerInfo(
        UserID,
        carts.GetCartForUser(UserID),
        orders.GetOrderForUser(UserID)
      );
    }

    int nError = 0;
    public ICustomerInfo ErrorTest(string UserID) {
      nError += 1;
      if(nError % 2 == 0) {
        throw new Exception("Ett oväntat fel av typen TEST inträffade");
      } else {
        throw new Exception("Ett mycket allvarligt fel av typen TEST inträffade");
      }
    }
  }
}
