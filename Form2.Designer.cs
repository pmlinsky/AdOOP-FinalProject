namespace FinalProject
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InventoryButton = new System.Windows.Forms.Button();
            this.PurchaseButton = new System.Windows.Forms.Button();
            this.BalanceButton = new System.Windows.Forms.Button();
            this.ViewPurchasesButton = new System.Windows.Forms.Button();
            this.InventoryList = new System.Windows.Forms.ListBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.PaymentText = new System.Windows.Forms.MaskedTextBox();
            this.PaymentButton = new System.Windows.Forms.Button();
            this.SelectItemLabel = new System.Windows.Forms.Label();
            this.SelectItemQty = new System.Windows.Forms.NumericUpDown();
            this.CartButton = new System.Windows.Forms.Button();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.CheckoutList = new System.Windows.Forms.ListBox();
            this.PlaceOrderButton = new System.Windows.Forms.Button();
            this.OrderPlacedLabel = new System.Windows.Forms.Label();
            this.SearchByDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.ViewAllPurchasesButton = new System.Windows.Forms.Button();
            this.PurchasesList = new System.Windows.Forms.ListBox();
            this.ViewByPriceButton = new System.Windows.Forms.Button();
            this.ViewByDateButton = new System.Windows.Forms.Button();
            this.SubmitSearchButton = new System.Windows.Forms.Button();
            this.PriceFromBox = new System.Windows.Forms.TextBox();
            this.PriceToBox = new System.Windows.Forms.TextBox();
            this.InvalidPriceBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SelectItemQty)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryButton
            // 
            this.InventoryButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.Location = new System.Drawing.Point(55, 40);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(135, 84);
            this.InventoryButton.TabIndex = 0;
            this.InventoryButton.Text = "Check Inventory";
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // PurchaseButton
            // 
            this.PurchaseButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchaseButton.Location = new System.Drawing.Point(55, 130);
            this.PurchaseButton.Name = "PurchaseButton";
            this.PurchaseButton.Size = new System.Drawing.Size(136, 82);
            this.PurchaseButton.TabIndex = 1;
            this.PurchaseButton.Text = "Make a Purchase";
            this.PurchaseButton.UseVisualStyleBackColor = true;
            this.PurchaseButton.Click += new System.EventHandler(this.PurchaseButton_Click);
            // 
            // BalanceButton
            // 
            this.BalanceButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BalanceButton.Location = new System.Drawing.Point(56, 218);
            this.BalanceButton.Name = "BalanceButton";
            this.BalanceButton.Size = new System.Drawing.Size(135, 84);
            this.BalanceButton.TabIndex = 2;
            this.BalanceButton.Text = "Manage Account Balance";
            this.BalanceButton.UseVisualStyleBackColor = true;
            this.BalanceButton.Click += new System.EventHandler(this.BalanceButton_Click);
            // 
            // ViewPurchasesButton
            // 
            this.ViewPurchasesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ViewPurchasesButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewPurchasesButton.Location = new System.Drawing.Point(56, 308);
            this.ViewPurchasesButton.Name = "ViewPurchasesButton";
            this.ViewPurchasesButton.Size = new System.Drawing.Size(135, 82);
            this.ViewPurchasesButton.TabIndex = 3;
            this.ViewPurchasesButton.Text = "View Purchases";
            this.ViewPurchasesButton.UseVisualStyleBackColor = true;
            this.ViewPurchasesButton.Click += new System.EventHandler(this.ViewPurchasesButton_Click);
            // 
            // InventoryList
            // 
            this.InventoryList.FormattingEnabled = true;
            this.InventoryList.Location = new System.Drawing.Point(280, 40);
            this.InventoryList.Name = "InventoryList";
            this.InventoryList.Size = new System.Drawing.Size(254, 147);
            this.InventoryList.TabIndex = 4;
            this.InventoryList.Visible = false;
            this.InventoryList.SelectedValueChanged += new System.EventHandler(this.InventoryList_SelectedValueChanged);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.ForeColor = System.Drawing.Color.Crimson;
            this.LogoutButton.Location = new System.Drawing.Point(687, 12);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(101, 33);
            this.LogoutButton.TabIndex = 5;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BalanceLabel.Location = new System.Drawing.Point(285, 196);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(0, 16);
            this.BalanceLabel.TabIndex = 6;
            this.BalanceLabel.Visible = false;
            // 
            // PaymentText
            // 
            this.PaymentText.Location = new System.Drawing.Point(313, 253);
            this.PaymentText.Name = "PaymentText";
            this.PaymentText.Size = new System.Drawing.Size(72, 20);
            this.PaymentText.TabIndex = 7;
            this.PaymentText.Visible = false;
            // 
            // PaymentButton
            // 
            this.PaymentButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentButton.Location = new System.Drawing.Point(313, 293);
            this.PaymentButton.Name = "PaymentButton";
            this.PaymentButton.Size = new System.Drawing.Size(71, 40);
            this.PaymentButton.TabIndex = 8;
            this.PaymentButton.Text = "Process Payment";
            this.PaymentButton.UseVisualStyleBackColor = true;
            this.PaymentButton.Visible = false;
            this.PaymentButton.Click += new System.EventHandler(this.PaymentButton_Click);
            // 
            // SelectItemLabel
            // 
            this.SelectItemLabel.AutoSize = true;
            this.SelectItemLabel.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectItemLabel.Location = new System.Drawing.Point(306, 20);
            this.SelectItemLabel.Name = "SelectItemLabel";
            this.SelectItemLabel.Size = new System.Drawing.Size(173, 16);
            this.SelectItemLabel.TabIndex = 9;
            this.SelectItemLabel.Text = "Select an Item to add to Cart:";
            this.SelectItemLabel.Visible = false;
            // 
            // SelectItemQty
            // 
            this.SelectItemQty.Location = new System.Drawing.Point(557, 89);
            this.SelectItemQty.Name = "SelectItemQty";
            this.SelectItemQty.Size = new System.Drawing.Size(63, 20);
            this.SelectItemQty.TabIndex = 10;
            this.SelectItemQty.Visible = false;
            // 
            // CartButton
            // 
            this.CartButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartButton.Location = new System.Drawing.Point(548, 115);
            this.CartButton.Name = "CartButton";
            this.CartButton.Size = new System.Drawing.Size(72, 40);
            this.CartButton.TabIndex = 11;
            this.CartButton.Text = "Add to Cart";
            this.CartButton.UseVisualStyleBackColor = true;
            this.CartButton.Visible = false;
            this.CartButton.Click += new System.EventHandler(this.CartButton_Click);
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckoutButton.Location = new System.Drawing.Point(548, 158);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(72, 29);
            this.CheckoutButton.TabIndex = 12;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Visible = false;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // CheckoutList
            // 
            this.CheckoutList.FormattingEnabled = true;
            this.CheckoutList.Location = new System.Drawing.Point(257, 39);
            this.CheckoutList.Name = "CheckoutList";
            this.CheckoutList.Size = new System.Drawing.Size(259, 147);
            this.CheckoutList.TabIndex = 13;
            this.CheckoutList.Visible = false;
            // 
            // PlaceOrderButton
            // 
            this.PlaceOrderButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceOrderButton.Location = new System.Drawing.Point(337, 192);
            this.PlaceOrderButton.Name = "PlaceOrderButton";
            this.PlaceOrderButton.Size = new System.Drawing.Size(142, 29);
            this.PlaceOrderButton.TabIndex = 14;
            this.PlaceOrderButton.Text = "PLACE ORDER";
            this.PlaceOrderButton.UseVisualStyleBackColor = true;
            this.PlaceOrderButton.Visible = false;
            this.PlaceOrderButton.Click += new System.EventHandler(this.PlaceOrderButton_Click);
            // 
            // OrderPlacedLabel
            // 
            this.OrderPlacedLabel.AutoSize = true;
            this.OrderPlacedLabel.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderPlacedLabel.Location = new System.Drawing.Point(291, 198);
            this.OrderPlacedLabel.Name = "OrderPlacedLabel";
            this.OrderPlacedLabel.Size = new System.Drawing.Size(233, 16);
            this.OrderPlacedLabel.TabIndex = 15;
            this.OrderPlacedLabel.Text = "Thank You! Your order has been placed.";
            this.OrderPlacedLabel.Visible = false;
            // 
            // SearchByDateCalendar
            // 
            this.SearchByDateCalendar.Location = new System.Drawing.Point(318, 79);
            this.SearchByDateCalendar.MaxDate = new System.DateTime(2020, 5, 19, 0, 0, 0, 0);
            this.SearchByDateCalendar.MaxSelectionCount = 36500;
            this.SearchByDateCalendar.Name = "SearchByDateCalendar";
            this.SearchByDateCalendar.TabIndex = 16;
            this.SearchByDateCalendar.Visible = false;
            // 
            // ViewAllPurchasesButton
            // 
            this.ViewAllPurchasesButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAllPurchasesButton.Location = new System.Drawing.Point(233, 89);
            this.ViewAllPurchasesButton.Name = "ViewAllPurchasesButton";
            this.ViewAllPurchasesButton.Size = new System.Drawing.Size(120, 86);
            this.ViewAllPurchasesButton.TabIndex = 17;
            this.ViewAllPurchasesButton.Text = "View All Purchases";
            this.ViewAllPurchasesButton.UseVisualStyleBackColor = true;
            this.ViewAllPurchasesButton.Visible = false;
            this.ViewAllPurchasesButton.Click += new System.EventHandler(this.ViewAllPurchasesButton_Click);
            // 
            // PurchasesList
            // 
            this.PurchasesList.FormattingEnabled = true;
            this.PurchasesList.Location = new System.Drawing.Point(309, 61);
            this.PurchasesList.Name = "PurchasesList";
            this.PurchasesList.Size = new System.Drawing.Size(331, 160);
            this.PurchasesList.TabIndex = 19;
            this.PurchasesList.Visible = false;
            // 
            // ViewByPriceButton
            // 
            this.ViewByPriceButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewByPriceButton.Location = new System.Drawing.Point(485, 89);
            this.ViewByPriceButton.Name = "ViewByPriceButton";
            this.ViewByPriceButton.Size = new System.Drawing.Size(120, 86);
            this.ViewByPriceButton.TabIndex = 20;
            this.ViewByPriceButton.Text = "View Purchases in a Price Range";
            this.ViewByPriceButton.UseVisualStyleBackColor = true;
            this.ViewByPriceButton.Visible = false;
            this.ViewByPriceButton.Click += new System.EventHandler(this.ViewByPriceButton_Click);
            // 
            // ViewByDateButton
            // 
            this.ViewByDateButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewByDateButton.Location = new System.Drawing.Point(359, 89);
            this.ViewByDateButton.Name = "ViewByDateButton";
            this.ViewByDateButton.Size = new System.Drawing.Size(120, 86);
            this.ViewByDateButton.TabIndex = 21;
            this.ViewByDateButton.Text = "View Purchases in a Date Range";
            this.ViewByDateButton.UseVisualStyleBackColor = true;
            this.ViewByDateButton.Visible = false;
            this.ViewByDateButton.Click += new System.EventHandler(this.ViewByDateButton_Click);
            // 
            // SubmitSearchButton
            // 
            this.SubmitSearchButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitSearchButton.Location = new System.Drawing.Point(390, 253);
            this.SubmitSearchButton.Name = "SubmitSearchButton";
            this.SubmitSearchButton.Size = new System.Drawing.Size(71, 40);
            this.SubmitSearchButton.TabIndex = 22;
            this.SubmitSearchButton.Text = "SEARCH";
            this.SubmitSearchButton.UseVisualStyleBackColor = true;
            this.SubmitSearchButton.Visible = false;
            this.SubmitSearchButton.Click += new System.EventHandler(this.SubmitSearchButton_Click);
            // 
            // PriceFromBox
            // 
            this.PriceFromBox.Location = new System.Drawing.Point(343, 139);
            this.PriceFromBox.Name = "PriceFromBox";
            this.PriceFromBox.Size = new System.Drawing.Size(163, 20);
            this.PriceFromBox.TabIndex = 23;
            this.PriceFromBox.Text = "Enter Lowest Price Here";
            this.PriceFromBox.Visible = false;
            // 
            // PriceToBox
            // 
            this.PriceToBox.Location = new System.Drawing.Point(343, 175);
            this.PriceToBox.Name = "PriceToBox";
            this.PriceToBox.Size = new System.Drawing.Size(163, 20);
            this.PriceToBox.TabIndex = 24;
            this.PriceToBox.Text = "Enter Highest Price Here";
            this.PriceToBox.Visible = false;
            // 
            // InvalidPriceBox
            // 
            this.InvalidPriceBox.AutoSize = true;
            this.InvalidPriceBox.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidPriceBox.Location = new System.Drawing.Point(393, 240);
            this.InvalidPriceBox.Name = "InvalidPriceBox";
            this.InvalidPriceBox.Size = new System.Drawing.Size(0, 16);
            this.InvalidPriceBox.TabIndex = 25;
            this.InvalidPriceBox.Visible = false;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InvalidPriceBox);
            this.Controls.Add(this.PriceToBox);
            this.Controls.Add(this.PriceFromBox);
            this.Controls.Add(this.SubmitSearchButton);
            this.Controls.Add(this.ViewByDateButton);
            this.Controls.Add(this.ViewByPriceButton);
            this.Controls.Add(this.PurchasesList);
            this.Controls.Add(this.ViewAllPurchasesButton);
            this.Controls.Add(this.SearchByDateCalendar);
            this.Controls.Add(this.OrderPlacedLabel);
            this.Controls.Add(this.PlaceOrderButton);
            this.Controls.Add(this.CheckoutList);
            this.Controls.Add(this.CheckoutButton);
            this.Controls.Add(this.CartButton);
            this.Controls.Add(this.SelectItemQty);
            this.Controls.Add(this.SelectItemLabel);
            this.Controls.Add(this.PaymentButton);
            this.Controls.Add(this.PaymentText);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.InventoryList);
            this.Controls.Add(this.ViewPurchasesButton);
            this.Controls.Add(this.BalanceButton);
            this.Controls.Add(this.PurchaseButton);
            this.Controls.Add(this.InventoryButton);
            this.Name = "CustomerForm";
            this.Text = "Customer Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.SelectItemQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.Button PurchaseButton;
        private System.Windows.Forms.Button BalanceButton;
        private System.Windows.Forms.Button ViewPurchasesButton;
        private System.Windows.Forms.ListBox InventoryList;
        private System.Windows.Forms.Button LogoutButton;
        public System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.MaskedTextBox PaymentText;
        private System.Windows.Forms.Button PaymentButton;
        private System.Windows.Forms.Label SelectItemLabel;
        private System.Windows.Forms.NumericUpDown SelectItemQty;
        private System.Windows.Forms.Button CartButton;
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.ListBox CheckoutList;
        private System.Windows.Forms.Button PlaceOrderButton;
        private System.Windows.Forms.Label OrderPlacedLabel;
        private System.Windows.Forms.MonthCalendar SearchByDateCalendar;
        private System.Windows.Forms.Button ViewAllPurchasesButton;
        private System.Windows.Forms.ListBox PurchasesList;
        private System.Windows.Forms.Button ViewByPriceButton;
        private System.Windows.Forms.Button ViewByDateButton;
        private System.Windows.Forms.Button SubmitSearchButton;
        private System.Windows.Forms.TextBox PriceFromBox;
        private System.Windows.Forms.TextBox PriceToBox;
        private System.Windows.Forms.Label InvalidPriceBox;
    }
}