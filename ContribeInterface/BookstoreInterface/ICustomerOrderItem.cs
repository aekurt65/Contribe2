using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInterface {
  public interface ICustomerOrderItem {
    IBook book { get; }
    int nDelivered { get; }
    int nRest { get; }
  }
}
