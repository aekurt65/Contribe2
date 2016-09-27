using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreClient {
  class CustomerInfo : ICustomerInfo {
    public CustomerInfo(Cart cart, CustomerOrder customerOrder) {
      this.cart = cart;
      this.customerOrder = customerOrder;
    }

    public string userid { get; set; }
    public ICart cart { get; }
    public ICustomerOrder customerOrder { get; }
  }
}
