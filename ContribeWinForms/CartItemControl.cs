using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;

namespace BookstoreWinforms {
  public partial class CartItemControl : UserControl {
    public CartItemControl() {
      InitializeComponent();
    }

    private ICartItem _item;
    public ICartItem item {
      set {
        txtTitle.Text = value.book.title;
        txtAuthor.Text = value.book.author;
        txtPrice.Text = value.book.price.ToString("#,0.00");
        txtInStock.Text = value.book.inStock.ToString();
        txtInCart.Text = value.nItems.ToString();
        _item = value;
      }
      get {
        return _item;
      }
    }

    public event EventHandler RemoveFromCart;
    private void btnRemoveFromCart_Click(object sender, EventArgs e) {
      if (this.RemoveFromCart != null)
        this.RemoveFromCart(this, e);
    }
  }
}
