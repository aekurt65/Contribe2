using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;

namespace BookstoreWinforms {
    public partial class BookControl : UserControl {
        public BookControl() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private IBook _book;
        public IBook book {
            set {
                txtTitle.Text = value.title;
                txtAuthor.Text = value.author;
                txtPrice.Text = value.price.ToString("#,0.00");
                txtInStock.Text = value.inStock.ToString();
                _book = value;
            }
            get {
                return _book;
            }
        }

        public event EventHandler AddToCart;
        private void btnAddToCart_Click(object sender, EventArgs e) {
            if (this.AddToCart != null)
                this.AddToCart(this, e);
        }

    }
}
