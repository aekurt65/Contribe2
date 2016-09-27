using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreClient {
  class CartItem : ICartItem {
    public CartItem(Book book) {
      this.book = book;
    }
    public IBook book { get; }
    public int nItems { get; set; }
  }
}
