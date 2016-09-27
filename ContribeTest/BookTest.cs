using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreServer;

namespace BookstoreTest {
  [TestClass]
  public class BookTest {

    Book CreateTestBook() {
      string title = "ATitle";
      string author = "AnAuthor";
      decimal price = 10.00m;
      int inStock = 7;
      Book book = new Book(title, author, price, inStock);
      return book;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void RetrieveBooksCheckExceptionWhenNegativeNumber() {
      // arrange
      Book book = CreateTestBook();

      // act
      int nRetrieved = book.RetrieveItems(-5);

    }

    [TestMethod]
    public void RetrieveBooks() {
      // arrange
      Book book = CreateTestBook();

      // act
      int nRetrieved = book.RetrieveItems(5);
      int nLeftInStock = book.inStock;
      int nRetrievedExpected = 5;
      int nLeftInStockExpected = 2;

      // assert
      Assert.AreEqual(nRetrievedExpected, nRetrieved, "RetrieveBooks 1 failed: Number of retrieved books wrong when nWanted < nStock");
      Assert.AreEqual(nLeftInStockExpected, nLeftInStock, "RetrieveBooks 2 failed: Number of left books wrong when nWanted < nStock");

      // act
      nRetrieved = book.RetrieveItems(5);
      nLeftInStock = book.inStock;
      nRetrievedExpected = 2;
      nLeftInStockExpected = 0;

      // assert
      Assert.AreEqual(nRetrievedExpected, nRetrieved, "RetrieveBooks 3 failed: Number of retrieved books wrong when nWanted > nStock");
      Assert.AreEqual(nLeftInStockExpected, nLeftInStock, "RetrieveBooks 4 failed: Number of left books wrong when nWanted > nStock");
    }
  }
}
