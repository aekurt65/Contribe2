using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookstoreWinforms {
  class ExceptionHandler {
    static public System.Windows.Forms.Form mainForm { get; set; }

    static public void HandleExceptions(object sender, ThreadExceptionEventArgs t) {
      HandleException(t.Exception);
    }

    static public void HandleExceptions(object sender, UnhandledExceptionEventArgs args) {
      HandleException((Exception)args.ExceptionObject);
    }

    static public void HandleException(Exception ex) {
      while (ex is AggregateException && ex.InnerException != null) {
        ex = ex.InnerException;
      }
      if (ex is Common.InfoException) {
        System.Windows.Forms.MessageBox.Show(mainForm, ex.Message, Program.caption);
      }
      else {
        string msgTemplate = "{0}\n\n{1}";
        string header = Txt.ProgramError;
        string msg = string.Format(msgTemplate, header, ex.ToString());
        InfoTextDialog.ShowDlg(mainForm, Program.caption, header, msg);
      }
    }
  }
}
