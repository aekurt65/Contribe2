using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contribe2.BookstoreSrv;
using Contribe2.BookstoreInterface;

namespace ContribeTest {
  [TestClass]
  public class PlacedOrderTest {

    // Book1 ==> Order less books than are in stock
    // Book2 ==> Order more books than are in stock

    private Book CreateBook1(dbBookStore db) {
      string title = "ATitle";
      string author = "AnAuthor";
      decimal price = 27.20m;
      int nAdd = 7;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Book CreateBook2(dbBookStore db) {
      string title = "AnotherTitle";
      string author = "AnnoterAuthor";
      decimal price = 31.40m;
      int nAdd = 2;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Cart CreateAndFillCart(string UserID, Book book1, Book book2) {
      Carts carts = Carts.get();
      Cart cart = carts.GetCartForUser(UserID);
      cart.AddItem(book1.bookid);
      cart.AddItem(book2.bookid);
      cart.AddItem(book2.bookid);
      cart.AddItem(book2.bookid);
      return cart;
    }

    [TestMethod]
    public void AddCartToOrderTest() {
      // setup
      dbBookStore db = dbBookStore.get();
      string UserID = "User123";
      Book book1 = CreateBook1(db);
      Book book2 = CreateBook2(db);
      Cart cart = CreateAndFillCart(UserID, book1, book2);

      int nBook1DBBefore = book1.inStock;
      int nBook2DBBefore = book2.inStock;
      int nBook1CartBefore = cart.nBooksInCart(book1.bookid);
      int nBook2CartBefore = cart.nBooksInCart(book2.bookid);


      // test
      PlacedOrders orders = PlacedOrders.get();
      PlacedOrder order = orders.GetOrderForUser(UserID);
      ICustomerInfo uinfo = order.AddItemsFromCart(UserID, cart);


      // Expected values
      int nBook1DBExpected;
      int nBook1CartExpected;
      int nDeliveredBook1OrderExpected;
      int nRestBook1OrderExpected;
      if (nBook1DBBefore >= nBook1CartBefore) {
        nBook1DBExpected = nBook1DBBefore - nBook1CartBefore;
        nBook1CartExpected = 0;
        nDeliveredBook1OrderExpected = nBook1CartBefore;
        nRestBook1OrderExpected = 0;
      }
      else {
        nBook1DBExpected = 0;
        nBook1CartExpected = 0;
        nDeliveredBook1OrderExpected = nBook1DBBefore;
        nRestBook1OrderExpected = nBook1CartBefore - nBook1DBBefore;
      }

      int nBook2DBExpected;
      int nBook2CartExpected;
      int nDeliveredBook2OrderExpected;
      int nRestBook2OrderExpected;
      if (nBook2DBBefore >= nBook2CartBefore) {
        nBook2DBExpected = nBook1DBBefore - nBook2CartBefore;
        nBook2CartExpected = 0;
        nDeliveredBook2OrderExpected = nBook2CartBefore;
        nRestBook2OrderExpected = 0;
      }
      else {
        nBook2DBExpected = 0;
        nBook2CartExpected = 0;
        nDeliveredBook2OrderExpected = nBook2DBBefore;
        nRestBook2OrderExpected = nBook2CartBefore - nBook2DBBefore;
      }

      // validate
      int nBook1AfterDB = book1.inStock;
      int nBook2AfterDB = book2.inStock;
      int nBook1AfterCart = cart.nBooksInCart(book1.bookid);
      int nBook2AfterCart = cart.nBooksInCart(book2.bookid);
      int nDeliveredBook1AfterOrder = order.nDeliveredBooksinOrder(book1.bookid);
      int nDeliveredBook2AfterOrder = order.nDeliveredBooksinOrder(book2.bookid);
      int nRestBook1AfterOrder = order.nRestBooksinOrder(book1.bookid);
      int nRestBook2AfterOrder = order.nRestBooksinOrder(book2.bookid);


      // Book1 ==> Order less books than are in stock
      // Book2 ==> Order more books than are in stock
      Assert.AreEqual(nBook1DBExpected, nBook1AfterDB, "Number of books in db wrong when less books in cart than are in stock");
      Assert.AreEqual(nBook1CartExpected, nBook1AfterCart, "Number of books in cart wrong when less books in cart than are in stock");
      Assert.AreEqual(nDeliveredBook1OrderExpected, nDeliveredBook1AfterOrder, "Number of delivered books in order wrong when less books in cart than are in stock");
      Assert.AreEqual(nRestBook1OrderExpected, nRestBook1AfterOrder, "Number of rest books in order wrong when less books in cart than are in stock");
      Assert.AreEqual(nBook2DBExpected, nBook2AfterDB, "Number of books in db wrong when more books in cart than are in stock");
      Assert.AreEqual(nBook2CartExpected, nBook2AfterCart, "Number of books in cart wrong when more books in cart than are in stock");
      Assert.AreEqual(nDeliveredBook2OrderExpected, nDeliveredBook2AfterOrder, "Number of delivered books in order wrong when more books in cart than are in stock");
      Assert.AreEqual(nRestBook2OrderExpected, nRestBook2AfterOrder, "Number of rest books in order wrong when more books in cart than are in stock");
    }
  }
}
