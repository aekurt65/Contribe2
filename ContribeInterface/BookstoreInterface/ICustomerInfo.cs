using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInterface {
  [System.ServiceModel.ServiceContract]
  public interface ICustomerInfo {
    string userid { get; }
    ICart cart { get; }
    ICustomerOrder customerOrder { get; }
  }
}
