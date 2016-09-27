using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookstoreInterface;

namespace BookstoreServer {
  public class Carts : Common.Singleton<Carts> {
    private Dictionary<string, Cart> dicUsercarts = new Dictionary<string, Cart>();

    public Cart GetCartForUser(string UserID) {
      Cart cart;
      lock (dicUsercarts) {
        if (!dicUsercarts.TryGetValue(UserID, out cart)) {
          cart = new Cart();
          dicUsercarts.Add(UserID, cart);
        }
      }
      return cart;
    }
  }
}
