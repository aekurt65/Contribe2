using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace BookstoreInterface {
  public interface IBook {
    string bookid { get; }
    string title { get; }
    string author { get; }
    decimal price { get; }
    int inStock { get; }
  }
}
