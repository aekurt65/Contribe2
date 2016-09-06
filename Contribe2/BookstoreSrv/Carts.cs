using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contribe2.BookstoreInterface;

namespace Contribe2.BookstoreSrv {
  public class Carts {
    private Carts() { }
    private static Carts _me = new Carts();
    public static Carts get() { return _me; }

    Dictionary<string, Cart> dicUsercarts = new Dictionary<string, Cart>();

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

    public Cart AddBookInCart(string UserID, string BookID) {
      Cart cart = GetCartForUser(UserID);
      cart.AddItem(BookID);
      return cart;
    }

    public Cart RemoveBookFromCart(string UserID, string BookID) {
      Cart cart = GetCartForUser(UserID);
      cart.RemoveItem(BookID);
      return cart;
    }

  }
}
