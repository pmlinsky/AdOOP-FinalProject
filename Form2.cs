using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace FinalProject
{
    public partial class CustomerForm : Form
    {
        List<int> qtyInStock = new List<int>();
        List<string> items = new List<string>();

        LoginForm lf;
        SalesTrackerDBDataContext db;
        public CustomerForm(LoginForm lf, SalesTrackerDBDataContext db)
        {
            InitializeComponent();
            this.lf = lf;
            this.db = db;
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryButton_Click();
        }

        private void InventoryButton_Click()
        {
            ClearCurrent();

            if (InventoryList.Items.Count == 0) 
            {
                var items = db.INVENTORies.OrderBy(i => i.ItemName);
                foreach (var item in items)
                {
                    if (item.QtyInStock != 0)
                    {
                        InventoryList.Items.Add(item.ItemName +
                            "\t$" + item.Price);
                        qtyInStock.Add(Convert.ToInt32(item.QtyInStock));
                    }
                }                
            }
            InventoryList.Visible = true;
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            var cust = db.CUSTOMERs.Where(c => c.Username.Equals(lf.UsernameText.Text)).First();
            if (cust.Balance >= 1000)
            {
                BalanceLabel.Text = "Your current balance is: $" + cust.Balance +
                    "\nYou cannot make a purchase until your balance is less than $1000.";
                BalanceLabel.Visible = true;
            }
            else
            {
                InventoryButton_Click();

                SelectItemLabel.Visible = true;
                SelectItemQty.Visible = true;
                CartButton.Visible = true;
            }         
        }

        private void InventoryList_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectItemQty.Maximum = qtyInStock.ElementAt(
                InventoryList.Items.IndexOf(InventoryList.SelectedItem));
            SelectItemQty.Value = 0;
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            decimal qty = SelectItemQty.Value;
            if (qty > 0) 
            { 
                items.Add(qty.ToString());
                int index = InventoryList.SelectedItem.ToString().IndexOf("$");
                items.Add(InventoryList.SelectedItem.ToString().Substring(0, index).Trim());
                CheckoutButton.Visible = true;
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            InventoryList.Visible = false;
            for (int i = 0; i < items.Count; i += 2)
            {
                int qty = Convert.ToInt32(items.ElementAt(i));
                string item = items.ElementAt(i + 1);
                if (qty > 0)
                {
                    CheckoutList.Items.Add(qty.ToString() + "\t" + item);
                }
            }           
            CheckoutList.Visible = true;
            PlaceOrderButton.Visible = true;
            SelectItemLabel.Visible = false;
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();
            OrderPlacedLabel.Visible = true;

            decimal totalPrice = 0;
            decimal linePrice = 0;
            var cust = db.CUSTOMERs.Where(c => c.Username.Equals(lf.UsernameText.Text)).First();

            for (int i = 0; i < items.Count; i += 2)
            {
                int qty = Convert.ToInt32(items.ElementAt(i));
                string item = items.ElementAt(i + 1);

                var it = db.INVENTORies.Where(p => p.ItemName.Equals(item)).First();
                it.QtyInStock -= qty;
                linePrice += it.Price * qty;
                totalPrice += linePrice;

                cust.PURCHASEs.Add(new PURCHASE
                { CustID = cust.Id, ItemName = item, Qty = qty, Price = linePrice });
            }
            cust.Balance += totalPrice;
            db.SubmitChanges();

            for (int i = items.Count - 1; i >= 0; i--)
            {
                items.RemoveAt(i);
            }
            for (int i = qtyInStock.Count - 1; i >= 0; i--)
            {
                qtyInStock.RemoveAt(i);
            }
            InventoryList.Items.Clear();
            CheckoutList.Items.Clear();
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            var cust = db.CUSTOMERs.Where(c => c.Username.Equals(lf.UsernameText.Text)).First();
            BalanceLabel.Text = "Your current balance is: $"+ cust.Balance +
                "\nEnter payment amount below:";

            BalanceLabel.Visible = true;
            PaymentText.Visible = true;
            PaymentButton.Visible = true;
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            string amount = PaymentText.Text.Trim();
            PaymentText.Text = "";
            string pattern = @"\d+(\.\d{1-2})?";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(amount))
            {
                if (Convert.ToDouble(amount) > 0)
                {
                    double payment = Convert.ToDouble(amount);
                    var cust = db.CUSTOMERs.Where
                        (c => c.Username.Equals(lf.UsernameText.Text)).First();
                    cust.Balance -= Convert.ToDecimal(amount);

                    db.SubmitChanges();
                    BalanceLabel.Text = "Thank you for your payment! Your current balance is: " +
                         "$" + cust.Balance;
                }
                else
                {
                    BalanceLabel.Text = "Invalid amount. Please try again.";
                }
            }
            else
            {
                BalanceLabel.Text = "Please enter using currect numerical format.";
            }

        }


        private void ViewPurchasesButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();
            ViewAllPurchasesButton.Visible = true;
            SearchByDateCalendar.Visible = true;
            PriceRangeText.Visible = true;
        }


        private void ViewAllPurchasesButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            var cust = db.CUSTOMERs.Where(c => c.Username.Equals(lf.UsernameText.Text)).First();

            var purchases = cust.PURCHASEs.Select(c => c);
            foreach (var p in purchases)
            {
                PurchasesList.Items.Add(p.DateOfPurchase + "\t" +
                p.ItemName + "\t" +
                p.Qty + "\t$" +
                p.Price);
            }
            
            PurchasesList.Visible = true;
        }

        private void SearchByDateCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.ShowDialog();
            this.Close();
        }

        private void ClearCurrent()
        {
            InventoryList.Visible = false;
            CheckoutList.Visible = false;
            BalanceLabel.Visible = false;
            PaymentButton.Visible = false;
            PaymentText.Visible = false;
            PlaceOrderButton.Visible = false;
            CartButton.Visible = false;
            CheckoutButton.Visible = false;
            SelectItemQty.Visible = false;
            SelectItemLabel.Visible = false;
            OrderPlacedLabel.Visible = false;
            ViewAllPurchasesButton.Visible = false;
            SearchByDateCalendar.Visible = false;
            PurchasesList.Visible = false;
            PriceRangeText.Visible = false;
        }


    }
}
