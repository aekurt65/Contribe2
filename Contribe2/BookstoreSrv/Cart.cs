using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class Cart : ICart {
    dbBookStore db = dbBookStore.get();
    public Dictionary<string, int> dic = new Dictionary<string, int>();

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
        return GetBookList();
      }
    }

    public void AddItem(string BookID) {
      lock(dic) {
        if (dic.ContainsKey(BookID)) {
          dic[BookID] += 1;
        }
        else {
          if (null == db.GetBookByID(BookID)) {
            throw new Exception("Invalid Book ID");
          }
          dic.Add(BookID, 1);
        }
      }
    }

    public void RemoveItem(string BookID) {
      // We can't remove book that isn't in the cart...
      // However no use raising an exception, we just return
      lock (dic) {
        if (dic.ContainsKey(BookID)) {
          if (dic[BookID] == 1) {
            dic.Remove(BookID);
          }
          else {
            dic[BookID] -= 1;
          }
        }
      }
    }

    public void RemoveAllitems(string BookID) {
      // We can't remove books that aren't in the cart...
      // However no use raising an exception, we just return
      lock (dic) {
        if (dic.ContainsKey(BookID)) {
          dic.Remove(BookID);
        }
      }
    }

    public void Clear() {
      dic.Clear();
    }

    private IEnumerable<ICartItem> GetBookList() {
      List<ICartItem> lst = new List<ICartItem>();
      lock(dic) {
        foreach (string key in dic.Keys) {
          IBook book = db.GetBookByID(key);
          if (null == book) {
            throw new Exception("Book Found in cart does not exist in database");
          }
          lst.Add(new Item(book, dic[key]));
        }
      }
      return lst;
    }

    public int nBooksInCart(string BookID) {
      int nBooks = 0;
      dic.TryGetValue(BookID, out nBooks);
      return nBooks;
    }

  }
}
