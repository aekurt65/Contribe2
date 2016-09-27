namespace BookstoreWinforms {
    partial class CartItemControl {
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
      this.label5 = new System.Windows.Forms.Label();
      this.txtInStock = new System.Windows.Forms.TextBox();
      this.btnRemoveFromCart = new System.Windows.Forms.Button();
      this.txtInCart = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.lblDivider = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Författare:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Titel:";
      // 
      // txtAuthor
      // 
      this.txtAuthor.Location = new System.Drawing.Point(58, 3);
      this.txtAuthor.Name = "txtAuthor";
      this.txtAuthor.ReadOnly = true;
      this.txtAuthor.Size = new System.Drawing.Size(128, 20);
      this.txtAuthor.TabIndex = 0;
      this.txtAuthor.TabStop = false;
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(60, 26);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new System.Drawing.Size(102, 20);
      this.txtTitle.TabIndex = 1;
      this.txtTitle.TabStop = false;
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(298, 26);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.ReadOnly = true;
      this.txtPrice.Size = new System.Drawing.Size(99, 20);
      this.txtPrice.TabIndex = 3;
      this.txtPrice.TabStop = false;
      this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(234, 29);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Pris/st:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(259, 6);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Antal i lager:";
      // 
      // txtInStock
      // 
      this.txtInStock.Location = new System.Drawing.Point(339, 3);
      this.txtInStock.Name = "txtInStock";
      this.txtInStock.ReadOnly = true;
      this.txtInStock.Size = new System.Drawing.Size(58, 20);
      this.txtInStock.TabIndex = 2;
      this.txtInStock.TabStop = false;
      this.txtInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnRemoveFromCart
      // 
      this.btnRemoveFromCart.Location = new System.Drawing.Point(330, 53);
      this.btnRemoveFromCart.Name = "btnRemoveFromCart";
      this.btnRemoveFromCart.Size = new System.Drawing.Size(67, 24);
      this.btnRemoveFromCart.TabIndex = 5;
      this.btnRemoveFromCart.Text = "Ta bort";
      this.btnRemoveFromCart.UseVisualStyleBackColor = true;
      this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
      // 
      // txtInCart
      // 
      this.txtInCart.Location = new System.Drawing.Point(262, 56);
      this.txtInCart.Name = "txtInCart";
      this.txtInCart.ReadOnly = true;
      this.txtInCart.Size = new System.Drawing.Size(62, 20);
      this.txtInCart.TabIndex = 4;
      this.txtInCart.TabStop = false;
      this.txtInCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(169, 59);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(90, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Antal i kundvagn:";
      // 
      // lblDivider
      // 
      this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblDivider.Location = new System.Drawing.Point(0, 78);
      this.lblDivider.Name = "lblDivider";
      this.lblDivider.Size = new System.Drawing.Size(400, 2);
      this.lblDivider.TabIndex = 11;
      this.lblDivider.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // CartItemControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDivider);
      this.Controls.Add(this.txtInCart);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnRemoveFromCart);
      this.Controls.Add(this.txtPrice);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtInStock);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.txtAuthor);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "CartItemControl";
      this.Size = new System.Drawing.Size(400, 80);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.Button btnRemoveFromCart;
    private System.Windows.Forms.TextBox txtInCart;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblDivider;
  }
}
