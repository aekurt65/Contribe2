using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreServer;
using BookstoreInterface;

namespace BookstoreTest {

  [TestClass]
  public class PlacedOrderTest {

    // Book1 ==> Order less books than are in stock
    // Book2 ==> Order more books than are in stock

    private Book CreateBook1(Books db) {
      string title = "ATitle";
      string author = "AnAuthor";
      decimal price = 27.20m;
      int nAdd = 7;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Book CreateBook2(Books db) {
      string title = "AnotherTitle";
      string author = "AnnoterAuthor";
      decimal price = 31.40m;
      int nAdd = 2;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Cart FillCart(Customer customer, Book book1, Book book2) {
      customer.AddBookToCart(book1.bookid);
      customer.AddBookToCart(book2.bookid);
      customer.AddBookToCart(book2.bookid);
      customer.AddBookToCart(book2.bookid);
      return customer.GetCart();
    }

    [TestMethod]
    public void CartToOrder() {
      // setup
      Books db = Books.Instance;
      Customer customer = Customers.Instance.GetCustomerByID("User123");
      db.Clear();
      Book book1 = CreateBook1(db);
      Book book2 = CreateBook2(db);
      Cart cart = FillCart(customer, book1, book2);

      int nBook1DBBefore = book1.inStock;
      int nBook2DBBefore = book2.inStock;
      int nBook1CartBefore = cart.nBooksInCart(book1.bookid);
      int nBook2CartBefore = cart.nBooksInCart(book2.bookid);

      // test
      
      customer.AddItemsFromCart();

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
      int nDeliveredBook1AfterOrder = customer.nDeliveredBooks(book1.bookid);
      int nDeliveredBook2AfterOrder = customer.nDeliveredBooks(book2.bookid);
      int nRestBook1AfterOrder = customer.nRestBooks(book1.bookid);
      int nRestBook2AfterOrder = customer.nRestBooks(book2.bookid);


      // Book1 ==> Order less books than are in stock
      // Book2 ==> Order more books than are in stock
      Assert.AreEqual(nBook1DBExpected, nBook1AfterDB, "CartToOrder 1 failed: Number of books in db wrong when less books in cart than are in stock");
      Assert.AreEqual(nBook1CartExpected, nBook1AfterCart, "CartToOrder 2 failed: Number of books in cart wrong when less books in cart than are in stock");
      Assert.AreEqual(nDeliveredBook1OrderExpected, nDeliveredBook1AfterOrder, "CartToOrder 3 failed: Number of delivered books in order wrong when less books in cart than are in stock");
      Assert.AreEqual(nRestBook1OrderExpected, nRestBook1AfterOrder, "CartToOrder 4 failed: Number of rest books in order wrong when less books in cart than are in stock");
      Assert.AreEqual(nBook2DBExpected, nBook2AfterDB, "CartToOrder 5 failed: Number of books in db wrong when more books in cart than are in stock");
      Assert.AreEqual(nBook2CartExpected, nBook2AfterCart, "CartToOrder 6 failed: Number of books in cart wrong when more books in cart than are in stock");
      Assert.AreEqual(nDeliveredBook2OrderExpected, nDeliveredBook2AfterOrder, "CartToOrder 7 failed: Number of delivered books in order wrong when more books in cart than are in stock");
      Assert.AreEqual(nRestBook2OrderExpected, nRestBook2AfterOrder, "CartToOrder 8 failed: Number of rest books in order wrong when more books in cart than are in stock");
    }
  }
}
