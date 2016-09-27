using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BookstoreInterface;

namespace BookstoreServer {
  public class Book : IBook {
    public string bookid { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public decimal price { get; set; }
    public int inStock { get { return _inStock; } set { _inStock = value; } }
    private int _inStock;

    public Book() {
      // We might have used int as ID, i was thinking ISBN....
      this.bookid = Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    public Book (string title, string author, decimal price, int inStock) : this() {
      this.title = title;
      this.author = author;
      this.price = price;
      this._inStock = inStock;
    }

    public int RetrieveItems(int nWanted) {
      if (nWanted < 0) {
        throw new ArgumentOutOfRangeException();
      }

      int nReturned = 0;
      lock (this) {
        if (inStock > nWanted) {
          nReturned = nWanted;
          _inStock -= nWanted;
        }
        else {
          nReturned = inStock;
          _inStock = 0;
        }
      }
      return nReturned;
    }

    public void AddItems(int nAdded) {
      if(nAdded < 0) {
        throw new ArgumentOutOfRangeException();
      }
      lock (this) {
        _inStock += nAdded;
      }
    }

    //public void GetObjectData(SerializationInfo info, StreamingContext context) {
    //  info.AddValue("bookid", this.bookid);
    //  info.AddValue("title", this.title);
    //  info.AddValue("author", this.author);
    //  info.AddValue("price", this.price);
    //  info.AddValue("inStock", this.inStock);
    //}
  }
}

