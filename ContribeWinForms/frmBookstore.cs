using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;
using System.Threading.Tasks;

using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

using BookstoreClient;

namespace BookstoreWinforms {
  public partial class frmBookstore : Form {
    BookstoreService srvcBetter = BookstoreService.get();

    public frmBookstore() {
      InitializeComponent();
      ExceptionHandler.mainForm = this;
      ClearCustomerInfo();
      srvcBetter.SetUrl(txtUrl.Text);
    }

    // =====================================================
    #region Hantering inloggning
    // =====================================================

    protected async void ctrlLogin_UserLogin(object sender, LoginControl.LoginEventArgs e) {
      if (!string.IsNullOrWhiteSpace(e.userID)) {
        ICustomerInfo customerInfo = await srvcBetter.GetCustomerInfoAsync(e.userID);
        ShowCustomerInfo(customerInfo);
      }
    }

    private void ctrlLogin_UserLogout(object sender, EventArgs e) {
      ClearCustomerInfo();
    }

    bool TryGetUserID(bool showLogin, out string userID) {
      userID = ctrlLogin.UserID;
      if (string.IsNullOrWhiteSpace(userID)) {
        userID = Microsoft.VisualBasic.Interaction.InputBox(
            "Du är inte inloggad. Ange ditt namn för att logga in:",
            "Inloggning");
        ctrlLogin.UserID = userID;
      }
      return !string.IsNullOrWhiteSpace(userID);
    }

    string GetCurrentUserID() {
      return ctrlLogin.UserID;
    }
    #endregion

    // =====================================================
    #region Testfunktioner
    // =====================================================

    private async void btnMakeException_Click(object sender, EventArgs e) {
      object obj = await srvcBetter.ExceptionTestAsync();
      MessageBox.Show("Hit skall vi aldrig komma", Program.caption);
    }

    private async void btnInformationTest_Click(object sender, EventArgs e) {
      object obj = await srvcBetter.InformationTestAsync();
      MessageBox.Show("Hit skall vi aldrig komma", Program.caption);
    }

    private async void btnLongTimeTest_Click(object sender, EventArgs e) {
      string msg = await srvcBetter.LongRunningTestAsync(3000);
      MessageBox.Show(msg, Program.caption);
    }

    #endregion

    // =====================================================
    #region Eventhanterare
    // =====================================================

    private void txtUrl_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        btnSetUrl.PerformClick();
      }
    }

    private void btnSetUrl_Click(object sender, EventArgs e) {
      srvcBetter.SetUrl(txtUrl.Text);
    }


    private void txtSearch_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        btnSearch.PerformClick();
      }
    }

    private async void btnSearch_Click(object sender, EventArgs e) {
      string searchString = txtSearch.Text.Trim();
      IEnumerable<IBook> books = await srvcBetter.GetBooksAsync(searchString);
      ShowSearchResult(books, searchString);
    }

    protected async void BookControl_AddToCart(object sender, EventArgs e) {
      if (sender is BookControl) {
        BookControl ctrl = (BookControl)sender;
        string userID;
        if (TryGetUserID(true, out userID)) {
          ICart cart = await srvcBetter.AddBookAsync(userID, ctrl.book.bookid);
          if (userID.Equals(GetCurrentUserID(), StringComparison.InvariantCultureIgnoreCase)) {
            ShowCart(cart);
          }
        }
      }
    }

    protected async void CartControl_RemoveFromCart(object sender, EventArgs e) {
      if (sender is CartItemControl) {
        CartItemControl ctrl = (CartItemControl)sender;
        int savedRelativeYPos = GetRelativeYPos(pnlCartItems, ctrl);
        string userID;
        if (TryGetUserID(true, out userID)) {
          ICart cart = await srvcBetter.RemoveBookAsync(userID, ctrl.item.book.bookid);
          if (userID.Equals(GetCurrentUserID(), StringComparison.InvariantCultureIgnoreCase)) {
            ShowCart(cart);
            SetCtrlPosVisible(pnlCartItems, savedRelativeYPos);
          }
        }
      }
    }

    private int GetRelativeYPos(Control parent, Control child) {
      int y = 0;
      Control ctrl = child;
      while (ctrl != parent && ctrl.Parent != null) {
        y += ctrl.Location.Y;
        ctrl = ctrl.Parent;
      }
      return y;
    }

    private void SetCtrlPosVisible(Control parent, int YOffset) {
      Control child = parent.GetChildAtPoint(new Point(parent.Width / 2, YOffset));
      if (child != null) {
        this.ScrollControlIntoView(child);
      }
      else {
        this.ScrollControlIntoView(parent);
      }
    }

    private async void btnPlaceOrder_Click(object sender, EventArgs e) {
      string userID;
      if (TryGetUserID(true, out userID)) {
        ICustomerInfo customerInfo = await srvcBetter.PlaceOrderAllBooksInCartAsync(userID);
        ShowCustomerInfo(customerInfo);
      }
    }

    private async void btnPlaceOrderListedItems_Click(object sender, EventArgs e) {
      string userID;
      if (TryGetUserID(true, out userID)) {
        Dictionary<string, int> dicItemsToOrder = new Dictionary<string, int>();
        List<string> lstItemsToOrder = new List<string>();
        decimal sumPrice = 0.0m;
        foreach (CartItemControl ctrl in pnlCartItems.Controls) {
          ICartItem item = ctrl.item;
          string bookID = item.book.bookid;
          int nWanted = item.nItems;
          if (dicItemsToOrder.ContainsKey(bookID)) {
            dicItemsToOrder[bookID] += nWanted;
          }
          else {
            dicItemsToOrder[bookID] = nWanted;
          }
          for (int i = 0; i < nWanted; i++) {
            lstItemsToOrder.Add(bookID);
          }
          sumPrice += item.book.price * nWanted;
        }

        DialogResult dlgResult = MessageBox.Show(
           string.Format("Vill du beställa varor för {0}?", sumPrice.ToString("#,0.00")),
           Program.caption,
           MessageBoxButtons.YesNo
           );
        if (dlgResult == DialogResult.Yes) {
          string jsonDicItemsToOrder = srvcBetter.SerializeDictionary(dicItemsToOrder);
          ICustomerInfo customerInfo = await srvcBetter.PlaceOrderAsync(userID, jsonDicItemsToOrder);
          ShowCustomerInfo(customerInfo);
        }
      }
    }

    #endregion

    // =====================================================
    #region Uppdatera bilden
    // =====================================================

    void ClearCustomerInfo() {
      ShowSearchResult(null);
      ShowCart(null);
      ShowOrder(null);
    }

    void ShowCustomerInfo(ICustomerInfo customerInfo) {
      if (GetCurrentUserID().Equals(customerInfo.userid, StringComparison.InvariantCultureIgnoreCase)) {
        ShowCart(customerInfo == null ? null : customerInfo.cart);
        ShowOrder(customerInfo == null ? null : customerInfo.customerOrder);
      }
    }

    void ShowSearchResult(IEnumerable<IBook> lstBooks, string searchString = null) {
      lstBooks = lstBooks ?? new List<IBook>();
      try {
        SuspendDrawing(this);
        pnlSearchResultItems.Controls.Clear();
        foreach (IBook book in lstBooks) {
          BookControl ctrl = new BookControl();
          ctrl.book = book;
          ctrl.AddToCart += new EventHandler(BookControl_AddToCart);
          pnlSearchResultItems.Controls.Add(ctrl);
        }
      }
      finally {
        ResumeDrawing(this);
      }
    }

    void ShowCart(ICart cart) {
      IEnumerable<ICartItem> cartItems =
        cart == null ?
        new List<ICartItem>() :
        cart.cartItems;

      decimal sumPrice = 0.0m;
      try {
        SuspendDrawing(this);
        pnlCartItems.Controls.Clear();
        bool foundCartItems = false;
        foreach (ICartItem cartItem in cartItems) {
          CartItemControl ctrl = new CartItemControl();
          ctrl.item = cartItem;
          ctrl.RemoveFromCart += new EventHandler(CartControl_RemoveFromCart);
          pnlCartItems.Controls.Add(ctrl);
          sumPrice += cartItem.book.price * cartItem.nItems;
          foundCartItems = true;
        }
        txtSumPriceCartItems.Text = sumPrice.ToString("#,0.00");
        pnlCartSummary.Visible = foundCartItems;
      }
      finally {
        ResumeDrawing(this);
      }
    }

    void ShowOrder(ICustomerOrder customerOrder) {
      IEnumerable<ICustomerOrderItem> items =
        customerOrder == null ?
        items = new List<ICustomerOrderItem>() :
        customerOrder.orderItems;

      decimal sumPrice = 0.0m;
      try {
        SuspendDrawing(this);
        pnlOrderitems.Controls.Clear();
        bool foundOrderitems = false;
        foreach (ICustomerOrderItem item in items) {
          OrderItemControl ctrl = new OrderItemControl();
          ctrl.item = item;
          pnlOrderitems.Controls.Add(ctrl);
          sumPrice += item.book.price * (item.nDelivered + item.nRest);
          foundOrderitems = true;
        }
        txtSumPriceOrderedItems.Text = sumPrice.ToString("#,0.00");
        pnlOrderSummary.Visible = foundOrderitems;
      }
      finally {
        ResumeDrawing(this);
      }
    }

    // Inte rita om medan uppdatering pågår
    // http://stackoverflow.com/questions/487661/how-do-i-suspend-painting-for-a-control-and-its-children
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(Control ctrl) {
      SendMessage(ctrl.Handle, WM_SETREDRAW, false, 0);
    }

    public static void ResumeDrawing(Control ctrl) {
      SendMessage(ctrl.Handle, WM_SETREDRAW, true, 0);
      ctrl.Refresh();
    }

    // Se till att focus är ungär på samma ställe
    // TBD

    #endregion
  }
}
