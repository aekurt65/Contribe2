using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BookstoreInterface;

namespace BookstoreServer {
  public class Cart : ICart {
    Books dbBooks = Books.Instance;
    private Dictionary<string, int> dicCartItems = new Dictionary<string, int>();

    public struct Item : ICartItem {
      public IBook book { get; }
      public int nItems { get; }
      public Item(IBook book, int nItems) {
        this.book = book;
        this.nItems = nItems;
      }
    }

    public IEnumerable<ICartItem> cartItems {
      get {
        List<ICartItem> lst = new List<ICartItem>();
        lock (dicCartItems) {
          foreach (string bookID in dicCartItems.Keys) {
            IBook book = dbBooks.GetBookByID(bookID);
            if (null == book) {
              throw new Exception(string.Format("Book in cart with id {0} does not exist in database", bookID));
            }
            lst.Add(new Item(book, dicCartItems[bookID]));
          }
        }
        return lst;
      }
    }

    public void AddItem(string BookID) {
      lock (dicCartItems) {
        if (dicCartItems.ContainsKey(BookID)) {
          dicCartItems[BookID] += 1;
        }
        else {
          if (null == dbBooks.GetBookByID(BookID)) {
            throw new Exception("Invalid Book ID");
          }
          dicCartItems.Add(BookID, 1);
        }
      }
    }

    public void RemoveItem(string BookID, int nItemsToRemove = 1) {
      // We can't remove more books than are in the cart...
      // However no use raising an exception, just return
      lock (dicCartItems) {
        if (dicCartItems.ContainsKey(BookID)) {
          if (dicCartItems[BookID] <= nItemsToRemove) {
            dicCartItems.Remove(BookID);
          }
          else {
            dicCartItems[BookID] -= nItemsToRemove;
          }
        }
      }
    }

    public void RemoveAllitems(string BookID) {
      // We can't remove books that aren't in the cart...
      // However no use raising an exception, we just return
      lock (dicCartItems) {
        if (dicCartItems.ContainsKey(BookID)) {
          dicCartItems.Remove(BookID);
        }
      }
    }

    public void Clear() {
      lock (dicCartItems) {
        dicCartItems.Clear();
      }
    }


    /// <summary>
    /// Gets the number of books in the cart for given bookID
    /// </summary>
    /// <param name="bookID"></param>
    /// <returns></returns>
    public int nBooksInCart(string bookID) {
      int nBooks;
      dicCartItems.TryGetValue(bookID, out nBooks);
      return nBooks;
    }
  }
}
