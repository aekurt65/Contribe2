using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreClient {
  class CustomerOrderItem  : ICustomerOrderItem {
    public CustomerOrderItem(Book book) {
      this.book = book;
    }
    public IBook book { get; }
    public int nDelivered { get; set; }
    public int nRest { get; set; }
  }
}
