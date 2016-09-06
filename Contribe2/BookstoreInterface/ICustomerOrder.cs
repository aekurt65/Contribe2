using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contribe2.BookstoreInterface {
  public interface ICustomerOrder {
    List<ICustomerOrderItem> orderitems { get; }
  }
}
