using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class CustomerInfo : ICustomerInfo{
    public string userid { get; }
    public ICart cart { get; }
    public ICustomerOrder customerOrder { get; }
    public CustomerInfo(string userid, ICart cart, ICustomerOrder customerOrder) {
      this.userid = userid;
      this.cart = cart;
      this.customerOrder = customerOrder;
    }
  }
}
