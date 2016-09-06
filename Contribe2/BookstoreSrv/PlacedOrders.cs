using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class PlacedOrders {
    private PlacedOrders() { }
    static PlacedOrders _me = new PlacedOrders();
    static public PlacedOrders get() { return _me; }

    Dictionary<string, PlacedOrder> dic = new Dictionary<string, PlacedOrder>();

    public PlacedOrder GetOrderForUser(string UserID) {
      PlacedOrder order;
      lock(dic) {
        if (!dic.TryGetValue(UserID, out order)) {
          order = new PlacedOrder();
          dic.Add(UserID, order);
        }
      }
      return order;
    }
  }
}

