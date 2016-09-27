using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreInterface;

namespace BookstoreClient {
  class Cart : ICart {
    public Cart(CartItem[] cartItems) {
      this.cartItems = cartItems;
    }
    public IEnumerable<ICartItem> cartItems { get; }
  }
}
