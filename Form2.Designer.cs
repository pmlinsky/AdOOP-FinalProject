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
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}