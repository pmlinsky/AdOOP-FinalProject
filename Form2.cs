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

        LoginForm lf;
        SalesTrackerDBDataContext db;
        CUSTOMER cust;

        public CustomerForm(LoginForm lf, SalesTrackerDBDataContext db)
        {
            InitializeComponent();
            this.lf = lf;
            this.db = db;
            cust = db.CUSTOMERs.Where(c => c.Username.Equals(lf.UsernameText.Text)).First();
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
                    }
                }                
            }
            InventoryList.Visible = true;
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

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
            int index = InventoryList.SelectedItem.ToString().IndexOf("\t");
            var item = db.INVENTORies
                .Where(i => i.ItemName
                .Equals(InventoryList.SelectedItem.ToString().Substring(0, index)))
                .First();

            SelectItemQty.Maximum = item.QtyInStock;
            SelectItemQty.Value = 0;
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            decimal qty = SelectItemQty.Value;
            if (qty > 0) 
            {
                int index = InventoryList.SelectedItem.ToString().IndexOf("$");
                CheckoutList.Items.Add(qty + "\t" + 
                    InventoryList.SelectedItem.ToString().Substring(0, index).Trim());
                CheckoutButton.Visible = true;
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            InventoryList.Visible = false;          
            CheckoutList.Visible = true;
            PlaceOrderButton.Visible = true;
            SelectItemLabel.Visible = false;
            CartButton.Visible = false;
            SelectItemQty.Visible = false;
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();
            OrderPlacedLabel.Visible = true;

            decimal totalPrice = 0;
            decimal linePrice = 0;

            foreach (String s in CheckoutList.Items)
            {
                int index = s.IndexOf("\t");
                int qty = Convert.ToInt32(s.Substring(0, index));
                string item = s.Substring(index+1);

                var it = db.INVENTORies.Where(p => p.ItemName.Equals(item)).First();
                it.QtyInStock -= qty;
                linePrice += it.Price * qty;
                totalPrice += linePrice;

                DateTime today = DateTime.Today;
                cust.PURCHASEs.Add(new PURCHASE
                { DateOfPurchase = today, CustID = cust.Id, 
                    ItemName = item, Qty = qty, Price = linePrice });
            }
            cust.Balance += totalPrice;
            db.SubmitChanges();
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

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
            ViewByPriceButton.Visible = true;
            ViewByDateButton.Visible = true;
        }


        private void ViewAllPurchasesButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            var purchases = cust.PURCHASEs.Select(c => c);
            foreach (var p in purchases)
            {
                PurchasesList.Items.Add(p.DateOfPurchase.ToShortDateString() + "\t" +
                p.ItemName + "\t" + p.Qty + "\t$" + p.Price);
            }
            
            PurchasesList.Visible = true;
        }


        private void ViewByPriceButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            PriceFromBox.Visible = true;
            PriceToBox.Visible = true;
            SubmitSearchButton.Visible = true;
        }

        private void ViewByDateButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();

            SearchByDateCalendar.MaxDate = DateTime.Today;
            SearchByDateCalendar.Visible = true;
            SubmitSearchButton.Visible = true;
        }

        private void SubmitSearchButton_Click(object sender, EventArgs e)
        {

            DateTime start, end;
            decimal low = 0, high = decimal.MaxValue;
            if (SearchByDateCalendar.Visible)
            {
                start = SearchByDateCalendar.SelectionRange.Start;
                end = SearchByDateCalendar.SelectionRange.End;
            }
            else
            {
                string lowS = PriceFromBox.Text.Trim();
                string highS = PriceToBox.Text.Trim();
                string pattern = @"\d+(\.\d{1-2})?";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(lowS) && rg.IsMatch(highS))
                {
                    if (Convert.ToDecimal(lowS) > 0 &&
                        Convert.ToDecimal(highS) >= Convert.ToDecimal(lowS))
                    {
                        low = Convert.ToDecimal(PriceFromBox.Text);
                        high = Convert.ToDecimal(PriceToBox.Text);
                    }
                    else
                    {
                        InvalidPriceBox.Text = "Invalid input. Displaying all purchases.";
                        InvalidPriceBox.Visible = true;
                    }
                }
                else
                {
                    InvalidPriceBox.Text = "Invalid input. Displaying all purchases.";
                    InvalidPriceBox.Visible = true;
                }
                start = new DateTime(1800, 01, 01);
                end = DateTime.Today;
                
                PriceFromBox.Text = "Enter Lowest Price Here";
                PriceToBox.Text = "Enter Highest Price Here";
            }
            ClearCurrent();

            var purchases = cust.PURCHASEs.Where(
                c => c.DateOfPurchase >= start && c.DateOfPurchase <= end &&
                c.Price >= low && c.Price <= high);

            foreach (var p in purchases)
            {
                PurchasesList.Items.Add(p.DateOfPurchase.ToShortDateString() + "\t" +
                p.ItemName + "\t" + p.Qty + "\t$" + p.Price);
            }

            PurchasesList.Visible = true;
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
            ViewByDateButton.Visible = false;
            ViewByPriceButton.Visible = false;
            SubmitSearchButton.Visible = false;
            PriceFromBox.Visible = false;
            PriceToBox.Visible = false;
            InvalidPriceBox.Visible = false;
            PurchasesList.Items.Clear();
        }
    }
}
