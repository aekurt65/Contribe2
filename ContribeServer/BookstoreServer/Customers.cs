using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreServer {
  public class Customers : Common.Singleton<Customers> {
    Dictionary<string, Customer> dicCustomers = 
      new Dictionary<string, Customer>(StringComparer.CurrentCultureIgnoreCase);
    public Customer GetCustomerByID(string userID) {
      if(string.IsNullOrWhiteSpace(userID)) {
        throw new Common.InfoException(Txt.InvalidUserID);
      }

      userID = userID.Trim();
      Customer customer;
      lock (dicCustomers) {
        if (!dicCustomers.TryGetValue(userID, out customer)) {
          customer = new Customer(userID);
          dicCustomers.Add(userID, customer);
        }
      }
      return customer;
    }
  }
}
