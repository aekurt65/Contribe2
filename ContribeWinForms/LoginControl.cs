using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;

namespace BookstoreWinforms {
  public partial class LoginControl : UserControl {
    public LoginControl() {
      InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e) {
      Login(txtLogin.Text);
    }

    private void btnLogout_Click(object sender, EventArgs e) {
      Logout();
    }


    public class LoginEventArgs : EventArgs {
      public string userID { get; set; }
    }
    public event EventHandler<LoginEventArgs> UserLogin;
    private void Login(string userID, bool triggerEvent = true) {
      if (!string.IsNullOrWhiteSpace(userID)) {
        txtUserID.Text = userID.Trim();
        pnlLogin.Visible = false;
        pnlLogout.Visible = true;
        this.Size = pnlContainer.Size;
        if (triggerEvent && UserLogin != null) {
          UserLogin(this, new LoginEventArgs { userID = txtUserID.Text });
        }
      }
    }

    public event EventHandler UserLogout;
    private void Logout(bool triggerEvent = true) {
      txtUserID.Text = string.Empty;
      pnlLogin.Visible = true;
      pnlLogout.Visible = false;
      this.Size = pnlContainer.Size;
      if (triggerEvent && UserLogout != null) {
        UserLogout(this, new EventArgs());
      }
    }

    /// <summary>
    /// Get or set current user ID.
    /// No login or logout event are raised when setting user ID.
    /// </summary>
    public string UserID {
      get {
        return txtUserID == null || string.IsNullOrWhiteSpace(txtUserID.Text) ?
          string.Empty :
          txtUserID.Text.Trim();
      }
      set {
        if (string.IsNullOrWhiteSpace(value)) {
          Logout(false);
        }
        else {
          Login(value, false);
        }
      }
    }
  }
}
