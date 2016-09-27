namespace BookstoreWinforms {
  partial class LoginControl {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.txtLogin = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.lblLogin = new System.Windows.Forms.Label();
      this.btnLogout = new System.Windows.Forms.Button();
      this.txtUserID = new System.Windows.Forms.TextBox();
      this.lblUserID = new System.Windows.Forms.Label();
      this.pnlLogin = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlLogout = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlLogin.SuspendLayout();
      this.pnlLogout.SuspendLayout();
      this.pnlContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtLogin
      // 
      this.txtLogin.Location = new System.Drawing.Point(114, 3);
      this.txtLogin.Name = "txtLogin";
      this.txtLogin.Size = new System.Drawing.Size(96, 20);
      this.txtLogin.TabIndex = 0;
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(216, 3);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(58, 21);
      this.btnLogin.TabIndex = 1;
      this.btnLogin.Text = "Logga in";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // lblLogin
      // 
      this.lblLogin.AutoSize = true;
      this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLogin.Location = new System.Drawing.Point(3, 0);
      this.lblLogin.Name = "lblLogin";
      this.lblLogin.Padding = new System.Windows.Forms.Padding(0, 4, 3, 4);
      this.lblLogin.Size = new System.Drawing.Size(105, 21);
      this.lblLogin.TabIndex = 2;
      this.lblLogin.Text = "Ange inloggning:";
      // 
      // btnLogout
      // 
      this.btnLogout.Location = new System.Drawing.Point(220, 3);
      this.btnLogout.Name = "btnLogout";
      this.btnLogout.Size = new System.Drawing.Size(58, 21);
      this.btnLogout.TabIndex = 4;
      this.btnLogout.Text = "Logga ut";
      this.btnLogout.UseVisualStyleBackColor = true;
      this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
      // 
      // txtUserID
      // 
      this.txtUserID.Location = new System.Drawing.Point(136, 3);
      this.txtUserID.Name = "txtUserID";
      this.txtUserID.ReadOnly = true;
      this.txtUserID.Size = new System.Drawing.Size(78, 20);
      this.txtUserID.TabIndex = 3;
      this.txtUserID.TabStop = false;
      // 
      // lblUserID
      // 
      this.lblUserID.AutoSize = true;
      this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUserID.Location = new System.Drawing.Point(3, 0);
      this.lblUserID.Name = "lblUserID";
      this.lblUserID.Padding = new System.Windows.Forms.Padding(0, 4, 3, 4);
      this.lblUserID.Size = new System.Drawing.Size(127, 21);
      this.lblUserID.TabIndex = 5;
      this.lblUserID.Text = "Du är inloggad som: ";
      // 
      // pnlLogin
      // 
      this.pnlLogin.AutoSize = true;
      this.pnlLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlLogin.Controls.Add(this.lblLogin);
      this.pnlLogin.Controls.Add(this.txtLogin);
      this.pnlLogin.Controls.Add(this.btnLogin);
      this.pnlLogin.Location = new System.Drawing.Point(3, 3);
      this.pnlLogin.Name = "pnlLogin";
      this.pnlLogin.Size = new System.Drawing.Size(277, 27);
      this.pnlLogin.TabIndex = 6;
      // 
      // pnlLogout
      // 
      this.pnlLogout.AutoSize = true;
      this.pnlLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlLogout.Controls.Add(this.lblUserID);
      this.pnlLogout.Controls.Add(this.txtUserID);
      this.pnlLogout.Controls.Add(this.btnLogout);
      this.pnlLogout.Location = new System.Drawing.Point(3, 36);
      this.pnlLogout.Name = "pnlLogout";
      this.pnlLogout.Size = new System.Drawing.Size(281, 27);
      this.pnlLogout.TabIndex = 7;
      // 
      // pnlContainer
      // 
      this.pnlContainer.AutoSize = true;
      this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlContainer.Controls.Add(this.pnlLogin);
      this.pnlContainer.Controls.Add(this.pnlLogout);
      this.pnlContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlContainer.Location = new System.Drawing.Point(0, 0);
      this.pnlContainer.Name = "pnlContainer";
      this.pnlContainer.Size = new System.Drawing.Size(287, 66);
      this.pnlContainer.TabIndex = 8;
      // 
      // LoginControl
      // 
      this.Controls.Add(this.pnlContainer);
      this.Name = "LoginControl";
      this.Size = new System.Drawing.Size(290, 67);
      this.pnlLogin.ResumeLayout(false);
      this.pnlLogin.PerformLayout();
      this.pnlLogout.ResumeLayout(false);
      this.pnlLogout.PerformLayout();
      this.pnlContainer.ResumeLayout(false);
      this.pnlContainer.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }


    #endregion

    private System.Windows.Forms.TextBox txtLogin;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.TextBox txtUserID;
    private System.Windows.Forms.Label lblUserID;
    private System.Windows.Forms.FlowLayoutPanel pnlLogin;
    private System.Windows.Forms.FlowLayoutPanel pnlLogout;
    private System.Windows.Forms.FlowLayoutPanel pnlContainer;
    private System.Windows.Forms.Label lblLogin;

  }
}
