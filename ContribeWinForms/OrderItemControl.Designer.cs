namespace BookstoreWinforms {
    partial class OrderItemControl {
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtAuthor = new System.Windows.Forms.TextBox();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.txtPrice = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtNDelivered = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtNRest = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.pnlRest = new System.Windows.Forms.Panel();
      this.lblDivider = new System.Windows.Forms.Label();
      this.pnlRest.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Författare:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Titel:";
      // 
      // txtAuthor
      // 
      this.txtAuthor.Location = new System.Drawing.Point(70, 3);
      this.txtAuthor.Name = "txtAuthor";
      this.txtAuthor.ReadOnly = true;
      this.txtAuthor.Size = new System.Drawing.Size(128, 20);
      this.txtAuthor.TabIndex = 0;
      this.txtAuthor.TabStop = false;
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(70, 26);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new System.Drawing.Size(128, 20);
      this.txtTitle.TabIndex = 1;
      this.txtTitle.TabStop = false;
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(70, 52);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.ReadOnly = true;
      this.txtPrice.Size = new System.Drawing.Size(58, 20);
      this.txtPrice.TabIndex = 2;
      this.txtPrice.TabStop = false;
      this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 52);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Pris/st:";
      // 
      // txtNDelivered
      // 
      this.txtNDelivered.Location = new System.Drawing.Point(318, 5);
      this.txtNDelivered.Name = "txtNDelivered";
      this.txtNDelivered.ReadOnly = true;
      this.txtNDelivered.Size = new System.Drawing.Size(58, 20);
      this.txtNDelivered.TabIndex = 3;
      this.txtNDelivered.TabStop = false;
      this.txtNDelivered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(229, 8);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Levererade:";
      // 
      // txtNRest
      // 
      this.txtNRest.BackColor = System.Drawing.Color.LightPink;
      this.txtNRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtNRest.Location = new System.Drawing.Point(92, 6);
      this.txtNRest.Name = "txtNRest";
      this.txtNRest.ReadOnly = true;
      this.txtNRest.Size = new System.Drawing.Size(58, 20);
      this.txtNRest.TabIndex = 4;
      this.txtNRest.TabStop = false;
      this.txtNRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(3, 9);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(87, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Restnoterade:";
      // 
      // pnlRest
      // 
      this.pnlRest.BackColor = System.Drawing.Color.Red;
      this.pnlRest.Controls.Add(this.label5);
      this.pnlRest.Controls.Add(this.txtNRest);
      this.pnlRest.Location = new System.Drawing.Point(226, 38);
      this.pnlRest.Name = "pnlRest";
      this.pnlRest.Size = new System.Drawing.Size(157, 34);
      this.pnlRest.TabIndex = 13;
      // 
      // lblDivider
      // 
      this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblDivider.Location = new System.Drawing.Point(0, 78);
      this.lblDivider.Name = "lblDivider";
      this.lblDivider.Size = new System.Drawing.Size(400, 2);
      this.lblDivider.TabIndex = 14;
      this.lblDivider.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // OrderItemControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDivider);
      this.Controls.Add(this.pnlRest);
      this.Controls.Add(this.txtNDelivered);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtPrice);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.txtAuthor);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "OrderItemControl";
      this.Size = new System.Drawing.Size(400, 80);
      this.pnlRest.ResumeLayout(false);
      this.pnlRest.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtNDelivered;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtNRest;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Panel pnlRest;
    private System.Windows.Forms.Label lblDivider;
  }
}
