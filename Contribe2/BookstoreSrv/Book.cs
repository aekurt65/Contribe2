using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class Book : IBook {
    public string bookid { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public decimal price { get; set; }
    public int inStock { get; set; }

    private string CreateBookKey() {
      return Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    public Book() {
      this.bookid = CreateBookKey();
    }

    public Book (string title, string author, decimal price, int inStock) : this() {
      this.title = title;
      this.author = author;
      this.price = price;
      this.inStock = inStock;
    }

    public int RetrieveItems(int nWanted) {
      if (nWanted < 0) {
        throw new ArgumentOutOfRangeException();
      }

      int nReturned = 0;
      lock (this) {
        if (inStock > nWanted) {
          nReturned = nWanted;
          inStock -= nWanted;
        }
        else {
          nReturned = inStock;
          inStock = 0;
        }
      }
      return nReturned;
    }

    public void AddItems(int nAdded) {
      if(nAdded < 0) {
        throw new ArgumentOutOfRangeException();
      }
      lock (this) {
        inStock += nAdded;
      }
    }

  }
}

