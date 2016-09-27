using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreClient {
  class CustomerOrder : ICustomerOrder {
    public CustomerOrder(CustomerOrderItem[] orderItems) {
      this.orderItems = orderItems;
    }
    public IEnumerable<ICustomerOrderItem> orderItems { get; }
  }
} 
