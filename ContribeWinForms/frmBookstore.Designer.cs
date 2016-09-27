namespace BookstoreWinforms {
  partial class frmBookstore {
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.lblSearch = new System.Windows.Forms.Label();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.pnlCartItems = new System.Windows.Forms.FlowLayoutPanel();
      this.lblCartItemsPlaceholder = new System.Windows.Forms.Label();
      this.lblUrl = new System.Windows.Forms.Label();
      this.txtUrl = new System.Windows.Forms.TextBox();
      this.btnSetUrl = new System.Windows.Forms.Button();
      this.pnlOrderitems = new System.Windows.Forms.FlowLayoutPanel();
      this.lblOrderItemsPlaceholder = new System.Windows.Forms.Label();
      this.pnlContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlUrl = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlTest = new System.Windows.Forms.FlowLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.btnInformationTest = new System.Windows.Forms.Button();
      this.btnLongTimeTest = new System.Windows.Forms.Button();
      this.btnExceptionTest = new System.Windows.Forms.Button();
      this.pnlSearch = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlDoSearch = new System.Windows.Forms.FlowLayoutPanel();
      this.lblSearchResultHeader = new System.Windows.Forms.Label();
      this.pnlSearchResultItems = new System.Windows.Forms.FlowLayoutPanel();
      this.lblSearchResultIemsPlaceholder = new System.Windows.Forms.Label();
      this.pnlCart = new System.Windows.Forms.FlowLayoutPanel();
      this.lblCartHeader = new System.Windows.Forms.Label();
      this.pnlCartSummary = new System.Windows.Forms.Panel();
      this.btnPlaceOrderListedItems = new System.Windows.Forms.Button();
      this.lblSumPriceCartItems = new System.Windows.Forms.Label();
      this.txtSumPriceCartItems = new System.Windows.Forms.TextBox();
      this.btnPlaceOrder = new System.Windows.Forms.Button();
      this.pnlOrders = new System.Windows.Forms.FlowLayoutPanel();
      this.lblOrdersHeader = new System.Windows.Forms.Label();
      this.pnlOrderSummary = new System.Windows.Forms.Panel();
      this.lblSumPriceOrderedItems = new System.Windows.Forms.Label();
      this.txtSumPriceOrderedItems = new System.Windows.Forms.TextBox();
      this.ctrlLogin = new BookstoreWinforms.LoginControl();
      this.pnlCartItems.SuspendLayout();
      this.pnlOrderitems.SuspendLayout();
      this.pnlContainer.SuspendLayout();
      this.pnlUrl.SuspendLayout();
      this.pnlTest.SuspendLayout();
      this.pnlSearch.SuspendLayout();
      this.pnlDoSearch.SuspendLayout();
      this.pnlSearchResultItems.SuspendLayout();
      this.pnlCart.SuspendLayout();
      this.pnlCartSummary.SuspendLayout();
      this.pnlOrders.SuspendLayout();
      this.pnlOrderSummary.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblSearch
      // 
      this.lblSearch.AutoSize = true;
      this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSearch.Location = new System.Drawing.Point(3, 7);
      this.lblSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new System.Drawing.Size(116, 13);
      this.lblSearch.TabIndex = 0;
      this.lblSearch.Text = "Sök titel/författare:";
      // 
      // txtSearch
      // 
      this.txtSearch.Location = new System.Drawing.Point(125, 3);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(181, 20);
      this.txtSearch.TabIndex = 1;
      this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(312, 3);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(60, 20);
      this.btnSearch.TabIndex = 2;
      this.btnSearch.Text = "Sök";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // pnlCartItems
      // 
      this.pnlCartItems.AutoSize = true;
      this.pnlCartItems.Controls.Add(this.lblCartItemsPlaceholder);
      this.pnlCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlCartItems.Location = new System.Drawing.Point(3, 23);
      this.pnlCartItems.Name = "pnlCartItems";
      this.pnlCartItems.Size = new System.Drawing.Size(77, 13);
      this.pnlCartItems.TabIndex = 1;
      this.pnlCartItems.WrapContents = false;
      // 
      // lblCartItemsPlaceholder
      // 
      this.lblCartItemsPlaceholder.AutoSize = true;
      this.lblCartItemsPlaceholder.Location = new System.Drawing.Point(3, 0);
      this.lblCartItemsPlaceholder.Name = "lblCartItemsPlaceholder";
      this.lblCartItemsPlaceholder.Size = new System.Drawing.Size(71, 13);
      this.lblCartItemsPlaceholder.TabIndex = 1;
      this.lblCartItemsPlaceholder.Text = "[pnlCartItems]";
      // 
      // lblUrl
      // 
      this.lblUrl.AutoSize = true;
      this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUrl.Location = new System.Drawing.Point(3, 7);
      this.lblUrl.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
      this.lblUrl.Name = "lblUrl";
      this.lblUrl.Size = new System.Drawing.Size(69, 13);
      this.lblUrl.TabIndex = 0;
      this.lblUrl.Text = "Ange URL:";
      // 
      // txtUrl
      // 
      this.txtUrl.Location = new System.Drawing.Point(78, 3);
      this.txtUrl.Name = "txtUrl";
      this.txtUrl.Size = new System.Drawing.Size(259, 20);
      this.txtUrl.TabIndex = 1;
      this.txtUrl.Text = "http://localhost:50615";
      this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
      // 
      // btnSetUrl
      // 
      this.btnSetUrl.Location = new System.Drawing.Point(343, 3);
      this.btnSetUrl.Name = "btnSetUrl";
      this.btnSetUrl.Size = new System.Drawing.Size(60, 20);
      this.btnSetUrl.TabIndex = 2;
      this.btnSetUrl.Text = "Ändra";
      this.btnSetUrl.UseVisualStyleBackColor = true;
      this.btnSetUrl.Click += new System.EventHandler(this.btnSetUrl_Click);
      // 
      // pnlOrderitems
      // 
      this.pnlOrderitems.AutoSize = true;
      this.pnlOrderitems.Controls.Add(this.lblOrderItemsPlaceholder);
      this.pnlOrderitems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlOrderitems.Location = new System.Drawing.Point(3, 20);
      this.pnlOrderitems.Name = "pnlOrderitems";
      this.pnlOrderitems.Size = new System.Drawing.Size(89, 13);
      this.pnlOrderitems.TabIndex = 1;
      this.pnlOrderitems.WrapContents = false;
      // 
      // lblOrderItemsPlaceholder
      // 
      this.lblOrderItemsPlaceholder.Location = new System.Drawing.Point(3, 0);
      this.lblOrderItemsPlaceholder.Name = "lblOrderItemsPlaceholder";
      this.lblOrderItemsPlaceholder.Size = new System.Drawing.Size(83, 13);
      this.lblOrderItemsPlaceholder.TabIndex = 1;
      this.lblOrderItemsPlaceholder.Text = "[pnlOrderitems]";
      // 
      // pnlContainer
      // 
      this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlContainer.AutoScroll = true;
      this.pnlContainer.Controls.Add(this.pnlUrl);
      this.pnlContainer.Controls.Add(this.pnlTest);
      this.pnlContainer.Controls.Add(this.ctrlLogin);
      this.pnlContainer.Controls.Add(this.pnlSearch);
      this.pnlContainer.Controls.Add(this.pnlCart);
      this.pnlContainer.Controls.Add(this.pnlOrders);
      this.pnlContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlContainer.Location = new System.Drawing.Point(1, 3);
      this.pnlContainer.Name = "pnlContainer";
      this.pnlContainer.Size = new System.Drawing.Size(467, 471);
      this.pnlContainer.TabIndex = 4;
      this.pnlContainer.WrapContents = false;
      // 
      // pnlUrl
      // 
      this.pnlUrl.AutoSize = true;
      this.pnlUrl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlUrl.Controls.Add(this.btnSetUrl);
      this.pnlUrl.Controls.Add(this.txtUrl);
      this.pnlUrl.Controls.Add(this.lblUrl);
      this.pnlUrl.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.pnlUrl.Location = new System.Drawing.Point(3, 3);
      this.pnlUrl.Name = "pnlUrl";
      this.pnlUrl.Size = new System.Drawing.Size(406, 27);
      this.pnlUrl.TabIndex = 0;
      // 
      // pnlTest
      // 
      this.pnlTest.AutoSize = true;
      this.pnlTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlTest.Controls.Add(this.label1);
      this.pnlTest.Controls.Add(this.btnInformationTest);
      this.pnlTest.Controls.Add(this.btnLongTimeTest);
      this.pnlTest.Controls.Add(this.btnExceptionTest);
      this.pnlTest.Location = new System.Drawing.Point(3, 36);
      this.pnlTest.Name = "pnlTest";
      this.pnlTest.Size = new System.Drawing.Size(353, 27);
      this.pnlTest.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 7);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Testfunktioner";
      // 
      // btnInformationTest
      // 
      this.btnInformationTest.Location = new System.Drawing.Point(98, 3);
      this.btnInformationTest.Name = "btnInformationTest";
      this.btnInformationTest.Size = new System.Drawing.Size(80, 21);
      this.btnInformationTest.TabIndex = 1;
      this.btnInformationTest.Text = "Information";
      this.btnInformationTest.UseVisualStyleBackColor = true;
      this.btnInformationTest.Click += new System.EventHandler(this.btnInformationTest_Click);
      // 
      // btnLongTimeTest
      // 
      this.btnLongTimeTest.Location = new System.Drawing.Point(184, 3);
      this.btnLongTimeTest.Name = "btnLongTimeTest";
      this.btnLongTimeTest.Size = new System.Drawing.Size(80, 21);
      this.btnLongTimeTest.TabIndex = 2;
      this.btnLongTimeTest.Text = "Långt anrop";
      this.btnLongTimeTest.UseVisualStyleBackColor = true;
      this.btnLongTimeTest.Click += new System.EventHandler(this.btnLongTimeTest_Click);
      // 
      // btnExceptionTest
      // 
      this.btnExceptionTest.Location = new System.Drawing.Point(270, 3);
      this.btnExceptionTest.Name = "btnExceptionTest";
      this.btnExceptionTest.Size = new System.Drawing.Size(80, 21);
      this.btnExceptionTest.TabIndex = 3;
      this.btnExceptionTest.Text = "Programfel";
      this.btnExceptionTest.UseVisualStyleBackColor = true;
      this.btnExceptionTest.Click += new System.EventHandler(this.btnMakeException_Click);
      // 
      // pnlSearch
      // 
      this.pnlSearch.AutoSize = true;
      this.pnlSearch.BackColor = System.Drawing.Color.LightYellow;
      this.pnlSearch.Controls.Add(this.pnlDoSearch);
      this.pnlSearch.Controls.Add(this.lblSearchResultHeader);
      this.pnlSearch.Controls.Add(this.pnlSearchResultItems);
      this.pnlSearch.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlSearch.Location = new System.Drawing.Point(3, 111);
      this.pnlSearch.Name = "pnlSearch";
      this.pnlSearch.Size = new System.Drawing.Size(381, 69);
      this.pnlSearch.TabIndex = 3;
      this.pnlSearch.WrapContents = false;
      // 
      // pnlDoSearch
      // 
      this.pnlDoSearch.AutoSize = true;
      this.pnlDoSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.pnlDoSearch.Controls.Add(this.lblSearch);
      this.pnlDoSearch.Controls.Add(this.txtSearch);
      this.pnlDoSearch.Controls.Add(this.btnSearch);
      this.pnlDoSearch.Location = new System.Drawing.Point(3, 3);
      this.pnlDoSearch.Name = "pnlDoSearch";
      this.pnlDoSearch.Size = new System.Drawing.Size(375, 27);
      this.pnlDoSearch.TabIndex = 0;
      this.pnlDoSearch.WrapContents = false;
      // 
      // lblSearchResultHeader
      // 
      this.lblSearchResultHeader.AutoSize = true;
      this.lblSearchResultHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSearchResultHeader.Location = new System.Drawing.Point(3, 33);
      this.lblSearchResultHeader.Name = "lblSearchResultHeader";
      this.lblSearchResultHeader.Size = new System.Drawing.Size(88, 17);
      this.lblSearchResultHeader.TabIndex = 1;
      this.lblSearchResultHeader.Text = "Sökresultat:";
      // 
      // pnlSearchResultItems
      // 
      this.pnlSearchResultItems.AutoSize = true;
      this.pnlSearchResultItems.Controls.Add(this.lblSearchResultIemsPlaceholder);
      this.pnlSearchResultItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlSearchResultItems.Location = new System.Drawing.Point(3, 53);
      this.pnlSearchResultItems.Name = "pnlSearchResultItems";
      this.pnlSearchResultItems.Size = new System.Drawing.Size(122, 13);
      this.pnlSearchResultItems.TabIndex = 2;
      this.pnlSearchResultItems.WrapContents = false;
      // 
      // lblSearchResultIemsPlaceholder
      // 
      this.lblSearchResultIemsPlaceholder.AutoSize = true;
      this.lblSearchResultIemsPlaceholder.Location = new System.Drawing.Point(3, 0);
      this.lblSearchResultIemsPlaceholder.Name = "lblSearchResultIemsPlaceholder";
      this.lblSearchResultIemsPlaceholder.Size = new System.Drawing.Size(116, 13);
      this.lblSearchResultIemsPlaceholder.TabIndex = 2;
      this.lblSearchResultIemsPlaceholder.Text = "[pnlSearchResultItems]";
      // 
      // pnlCart
      // 
      this.pnlCart.AutoSize = true;
      this.pnlCart.BackColor = System.Drawing.Color.PaleTurquoise;
      this.pnlCart.Controls.Add(this.lblCartHeader);
      this.pnlCart.Controls.Add(this.pnlCartItems);
      this.pnlCart.Controls.Add(this.pnlCartSummary);
      this.pnlCart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlCart.Location = new System.Drawing.Point(3, 186);
      this.pnlCart.Name = "pnlCart";
      this.pnlCart.Size = new System.Drawing.Size(406, 105);
      this.pnlCart.TabIndex = 4;
      this.pnlCart.WrapContents = false;
      // 
      // lblCartHeader
      // 
      this.lblCartHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCartHeader.Location = new System.Drawing.Point(3, 0);
      this.lblCartHeader.Name = "lblCartHeader";
      this.lblCartHeader.Size = new System.Drawing.Size(106, 20);
      this.lblCartHeader.TabIndex = 0;
      this.lblCartHeader.Text = "Kundvagn:";
      // 
      // pnlCartSummary
      // 
      this.pnlCartSummary.Controls.Add(this.btnPlaceOrderListedItems);
      this.pnlCartSummary.Controls.Add(this.lblSumPriceCartItems);
      this.pnlCartSummary.Controls.Add(this.txtSumPriceCartItems);
      this.pnlCartSummary.Controls.Add(this.btnPlaceOrder);
      this.pnlCartSummary.Location = new System.Drawing.Point(3, 42);
      this.pnlCartSummary.Name = "pnlCartSummary";
      this.pnlCartSummary.Size = new System.Drawing.Size(400, 60);
      this.pnlCartSummary.TabIndex = 2;
      // 
      // btnPlaceOrderListedItems
      // 
      this.btnPlaceOrderListedItems.Location = new System.Drawing.Point(75, 33);
      this.btnPlaceOrderListedItems.Name = "btnPlaceOrderListedItems";
      this.btnPlaceOrderListedItems.Size = new System.Drawing.Size(155, 24);
      this.btnPlaceOrderListedItems.TabIndex = 2;
      this.btnPlaceOrderListedItems.Text = "Beställ visade varor";
      this.btnPlaceOrderListedItems.UseVisualStyleBackColor = true;
      this.btnPlaceOrderListedItems.Click += new System.EventHandler(this.btnPlaceOrderListedItems_Click);
      // 
      // lblSumPriceCartItems
      // 
      this.lblSumPriceCartItems.AutoSize = true;
      this.lblSumPriceCartItems.Location = new System.Drawing.Point(133, 11);
      this.lblSumPriceCartItems.Name = "lblSumPriceCartItems";
      this.lblSumPriceCartItems.Size = new System.Drawing.Size(162, 13);
      this.lblSumPriceCartItems.TabIndex = 0;
      this.lblSumPriceCartItems.Text = "Summa pris för varor i kundvagn:";
      // 
      // txtSumPriceCartItems
      // 
      this.txtSumPriceCartItems.Location = new System.Drawing.Point(301, 8);
      this.txtSumPriceCartItems.Name = "txtSumPriceCartItems";
      this.txtSumPriceCartItems.ReadOnly = true;
      this.txtSumPriceCartItems.Size = new System.Drawing.Size(96, 20);
      this.txtSumPriceCartItems.TabIndex = 1;
      this.txtSumPriceCartItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnPlaceOrder
      // 
      this.btnPlaceOrder.Location = new System.Drawing.Point(242, 33);
      this.btnPlaceOrder.Name = "btnPlaceOrder";
      this.btnPlaceOrder.Size = new System.Drawing.Size(155, 24);
      this.btnPlaceOrder.TabIndex = 3;
      this.btnPlaceOrder.Text = "Beställ varor i kundvagn";
      this.btnPlaceOrder.UseVisualStyleBackColor = true;
      this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
      // 
      // pnlOrders
      // 
      this.pnlOrders.AutoSize = true;
      this.pnlOrders.BackColor = System.Drawing.Color.PaleGreen;
      this.pnlOrders.Controls.Add(this.lblOrdersHeader);
      this.pnlOrders.Controls.Add(this.pnlOrderitems);
      this.pnlOrders.Controls.Add(this.pnlOrderSummary);
      this.pnlOrders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlOrders.Location = new System.Drawing.Point(3, 297);
      this.pnlOrders.Name = "pnlOrders";
      this.pnlOrders.Size = new System.Drawing.Size(406, 80);
      this.pnlOrders.TabIndex = 5;
      this.pnlOrders.WrapContents = false;
      // 
      // lblOrdersHeader
      // 
      this.lblOrdersHeader.AutoSize = true;
      this.lblOrdersHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblOrdersHeader.Location = new System.Drawing.Point(3, 0);
      this.lblOrdersHeader.Name = "lblOrdersHeader";
      this.lblOrdersHeader.Size = new System.Drawing.Size(108, 17);
      this.lblOrdersHeader.TabIndex = 0;
      this.lblOrdersHeader.Text = "Beställda varor";
      // 
      // pnlOrderSummary
      // 
      this.pnlOrderSummary.Controls.Add(this.lblSumPriceOrderedItems);
      this.pnlOrderSummary.Controls.Add(this.txtSumPriceOrderedItems);
      this.pnlOrderSummary.Location = new System.Drawing.Point(3, 39);
      this.pnlOrderSummary.Name = "pnlOrderSummary";
      this.pnlOrderSummary.Size = new System.Drawing.Size(400, 38);
      this.pnlOrderSummary.TabIndex = 2;
      // 
      // lblSumPriceOrderedItems
      // 
      this.lblSumPriceOrderedItems.AutoSize = true;
      this.lblSumPriceOrderedItems.Location = new System.Drawing.Point(144, 11);
      this.lblSumPriceOrderedItems.Name = "lblSumPriceOrderedItems";
      this.lblSumPriceOrderedItems.Size = new System.Drawing.Size(151, 13);
      this.lblSumPriceOrderedItems.TabIndex = 0;
      this.lblSumPriceOrderedItems.Text = "Summa pris för beställda varor:";
      // 
      // txtSumPriceOrderedItems
      // 
      this.txtSumPriceOrderedItems.Location = new System.Drawing.Point(301, 8);
      this.txtSumPriceOrderedItems.Name = "txtSumPriceOrderedItems";
      this.txtSumPriceOrderedItems.ReadOnly = true;
      this.txtSumPriceOrderedItems.Size = new System.Drawing.Size(96, 20);
      this.txtSumPriceOrderedItems.TabIndex = 1;
      // 
      // ctrlLogin
      // 
      this.ctrlLogin.AutoSize = true;
      this.ctrlLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ctrlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
      this.ctrlLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ctrlLogin.Location = new System.Drawing.Point(3, 69);
      this.ctrlLogin.Name = "ctrlLogin";
      this.ctrlLogin.Size = new System.Drawing.Size(286, 36);
      this.ctrlLogin.TabIndex = 2;
      this.ctrlLogin.UserID = "";
      this.ctrlLogin.UserLogin += new System.EventHandler<BookstoreWinforms.LoginControl.LoginEventArgs>(this.ctrlLogin_UserLogin);
      this.ctrlLogin.UserLogout += new System.EventHandler(this.ctrlLogin_UserLogout);
      // 
      // frmBookstore
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(470, 475);
      this.Controls.Add(this.pnlContainer);
      this.Name = "frmBookstore";
      this.Text = "Kalles boklåda";
      this.pnlCartItems.ResumeLayout(false);
      this.pnlCartItems.PerformLayout();
      this.pnlOrderitems.ResumeLayout(false);
      this.pnlContainer.ResumeLayout(false);
      this.pnlContainer.PerformLayout();
      this.pnlUrl.ResumeLayout(false);
      this.pnlUrl.PerformLayout();
      this.pnlTest.ResumeLayout(false);
      this.pnlTest.PerformLayout();
      this.pnlSearch.ResumeLayout(false);
      this.pnlSearch.PerformLayout();
      this.pnlDoSearch.ResumeLayout(false);
      this.pnlDoSearch.PerformLayout();
      this.pnlSearchResultItems.ResumeLayout(false);
      this.pnlSearchResultItems.PerformLayout();
      this.pnlCart.ResumeLayout(false);
      this.pnlCart.PerformLayout();
      this.pnlCartSummary.ResumeLayout(false);
      this.pnlCartSummary.PerformLayout();
      this.pnlOrders.ResumeLayout(false);
      this.pnlOrders.PerformLayout();
      this.pnlOrderSummary.ResumeLayout(false);
      this.pnlOrderSummary.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.FlowLayoutPanel pnlCartItems;
    private System.Windows.Forms.Label lblUrl;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.Button btnSetUrl;
    private System.Windows.Forms.FlowLayoutPanel pnlOrderitems;
    private System.Windows.Forms.FlowLayoutPanel pnlContainer;
    private System.Windows.Forms.Panel pnlCartSummary;
    private System.Windows.Forms.TextBox txtSumPriceCartItems;
    private System.Windows.Forms.Button btnPlaceOrder;
    private System.Windows.Forms.Label lblSumPriceCartItems;
    private System.Windows.Forms.TextBox txtSumPriceOrderedItems;
    private System.Windows.Forms.Label lblCartItemsPlaceholder;
    private System.Windows.Forms.Label lblOrderItemsPlaceholder;
    private System.Windows.Forms.Label lblCartHeader;
    private System.Windows.Forms.Button btnExceptionTest;
    private System.Windows.Forms.FlowLayoutPanel pnlSearch;
    private System.Windows.Forms.Label lblSearchResultHeader;
    private System.Windows.Forms.Label lblSearchResultIemsPlaceholder;
    private System.Windows.Forms.FlowLayoutPanel pnlCart;
    private System.Windows.Forms.FlowLayoutPanel pnlOrders;
    private System.Windows.Forms.Label lblOrdersHeader;
    private System.Windows.Forms.Panel pnlOrderSummary;
    private System.Windows.Forms.Label lblSumPriceOrderedItems;
    private System.Windows.Forms.Button btnLongTimeTest;
    private System.Windows.Forms.FlowLayoutPanel pnlSearchResultItems;
    private System.Windows.Forms.Button btnInformationTest;
    private System.Windows.Forms.Label label1;
    private LoginControl ctrlLogin;
    private System.Windows.Forms.FlowLayoutPanel pnlUrl;
    private System.Windows.Forms.FlowLayoutPanel pnlDoSearch;
    private System.Windows.Forms.FlowLayoutPanel pnlTest;
    private System.Windows.Forms.Button btnPlaceOrderListedItems;
  }
}

