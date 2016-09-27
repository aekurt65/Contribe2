using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreServer;

namespace BookstoreTest {
  [TestClass]
  public class BooksTest {
    private Book CreateBook1(Books db) {
      string title = "AAAAA";
      string author = "bbbbb";
      decimal price = 27.20m;
      int nAdd = 1;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Book CreateBook1_OtherPrice(Books db) {
      string title = "AAAAA";
      string author = "bbbbb";
      decimal price = 27.21m;
      int nAdd = 1;
      return db.AddBooks(title, author, price, nAdd);
    }

    private Book CreateBook2(Books db) {
      string title = "AAAAA zxzz";
      string author = "cccc dddd";
      decimal price = 31.40m;
      int nAdd = 1;
      return db.AddBooks(title, author, price, nAdd);
    }

    [TestMethod]
    public void AddBooks() {
      //setup
      Books db = Books.Instance;
      db.Clear();

      //test
      string bookId1 = CreateBook1(db).bookid;
      string bookId1_Same = CreateBook1(db).bookid;
      string bookId1_Other = CreateBook1_OtherPrice(db).bookid;
      string bookId2 = CreateBook2(db).bookid;

      // validate
      Assert.AreEqual(bookId1, bookId1_Same, "AddBooks 1 failed: When same book added again should have same ID");
      Assert.AreNotEqual(bookId1, bookId1_Other, "AddBooks 2 failed: When book added with different price should get differnt ID");
      Assert.AreNotEqual(bookId1, bookId2, "AddBooks 3 failed: Different added books did get same ID");
      Assert.AreNotEqual(bookId1_Other, bookId2, "AddBooks 4 failed:Different added books did get same ID");

      int n1 = db.GetBookByID(bookId1).inStock;
      int n1_Other = db.GetBookByID(bookId1_Other).inStock;
      int n2 = db.GetBookByID(bookId2).inStock;

      Assert.AreEqual(2, n1, "AddBooks 5 failed: Wrong number of books in stock after AddBooks");
      Assert.AreEqual(1, n1_Other, "AddBooks 6 failed: Wrong number of books in stock after AddBooks");
      Assert.AreEqual(1, n2, "AddBooks 7 failed: Wrong number of books in stock after AddBooks");
    }

    [TestMethod]
    public void SearchBooks() {
      //setup
      Books db = Books.Instance;
      db.Clear();
      CreateBook1(db); // AAAAA bbbbb
      CreateBook1(db);
      CreateBook1_OtherPrice(db); // AAAAA bbbbb
      CreateBook2(db); // AAAA cccc dddd zzzz

      //test
      int nBooks_a = db.searchBooks("a").Count; // 3
      int nBooks_b = db.searchBooks("b").Count; // 2
      int nBooks_c = db.searchBooks("c").Count; // 1
      int nBooks_cz = db.searchBooks("c z").Count; // 1
      int nBooks_cb = db.searchBooks("c b").Count; // 0
      int nBooks_zz = db.searchBooks("zz").Count; // 0

      //expected values
      int nExpected_a = 3;
      int nExpected_b = 2;
      int nExpected_c = 1;
      int nExpected_cz = 1;
      int nExpected_cb = 0;
      int nExpected_zz = 0;

      //validate
      Assert.AreEqual(nExpected_a, nBooks_a, "SearchBooks 1 failed");
      Assert.AreEqual(nExpected_b, nBooks_b, "SearchBooks 2 failed");
      Assert.AreEqual(nExpected_c, nBooks_c, "SearchBooks 3 failed");
      Assert.AreEqual(nExpected_cz, nBooks_cz, "SearchBooks 4 failed");
      Assert.AreEqual(nExpected_cb, nBooks_cb, "SearchBooks 5 failed");
      Assert.AreEqual(nExpected_zz, nBooks_zz, "SearchBooks 6 failed");
    }
  }
}
