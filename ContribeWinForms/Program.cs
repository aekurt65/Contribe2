using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookstoreWinforms {
  static class Program {
    public const string caption = "Kalles boklåda";
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Add the event handler for handling UI thread exceptions to the event.
      Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ExceptionHandler.HandleExceptions);
      // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.HandleExceptions);

      Application.Run(new frmBookstore());
    }
  }
}
