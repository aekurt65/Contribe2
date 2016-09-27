using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BookstoreInterface;

namespace BookstoreClient {
  class Book : IBook {
    public string bookid { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public decimal price { get; set; }
    public int inStock { get; set; }
    public Book(double price) {
      this.price = (decimal)price;
    }
  }
}
