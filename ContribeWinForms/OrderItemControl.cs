using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;

namespace BookstoreWinforms {
  public partial class OrderItemControl : UserControl {
    public OrderItemControl() {
      InitializeComponent();
    }

    private ICustomerOrderItem _item;
    public ICustomerOrderItem item {
      set {
        txtTitle.Text = value.book.title;
        txtAuthor.Text = value.book.author;
        txtPrice.Text = value.book.price.ToString("#,0.00");
        txtNDelivered.Text = value.nDelivered.ToString();
        txtNRest.Text = value.nRest.ToString();
        pnlRest.Visible = value.nRest > 0;
        _item = value;
      }
      get {
        return _item;
      }
    }
  }
}
