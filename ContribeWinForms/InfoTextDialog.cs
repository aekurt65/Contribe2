using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookstoreInterface;
using System.Threading.Tasks;

using Microsoft.VisualBasic;

namespace BookstoreWinforms {
  public partial class InfoTextDialog : Form {

    private InfoTextDialog() {
      InitializeComponent();
    }

    private InfoTextDialog(Form owner, string title, string head, string infoText) : this() {
      Text = title;
      lblHeader.Text = head;
      txtInfo.Text = infoText;
      this.ShowDialog(owner);
    }

    public static void ShowDlg(Form owner, string title, string head, string infoText) {
      new InfoTextDialog(owner,title, head, infoText);
    }

    private void btnClose_Click(object sender, EventArgs e) {
      this.Dispose();
    }
  }
}
