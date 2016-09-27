using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInterface {
  public interface ICustomerOrder {
    IEnumerable<ICustomerOrderItem> orderItems { get; }
  }
}
