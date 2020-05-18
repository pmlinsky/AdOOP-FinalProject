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
        Customer cust;

        static string conn_string = @"Driver={SQL Server};
                                    Server=DESKTOP-FGFE61N\SQLEXPRESS01;
                                    Database=SALES_TRACKER;
                                    MultipleActiveResultSets=true";
        OdbcConnection conn = new OdbcConnection(conn_string);

        List<int> qtyInStock = new List<int>();
        List<string> items = new List<string>();

        LoginForm lf;
        public CustomerForm(LoginForm lf, Customer cust)
        {
            InitializeComponent();
            this.lf = lf;
            this.cust = cust;
            conn.Open();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryButton_Click();
        }

        private void InventoryButton_Click()
        {
            ClearCurrent();
            if (InventoryList.Items.Count == 0) { 
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM INVENTORY ORDER BY ItemName";
                var rs = command.ExecuteReader();

                while (rs.Read())
                {
                    if (!rs["QtyInStock"].ToString().Trim().Equals("0"))
                    {
                        InventoryList.Items.Add(rs["ItemName"].ToString().Trim() +
                            "\t$" + rs["Price"]);
                        qtyInStock.Add(Convert.ToInt32(rs["QtyInStock"]));
                    }
                }
            }
            InventoryList.Visible = true;
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            ClearCurrent();
            var command = conn.CreateCommand();
            command.CommandText = "SELECT BALANCE FROM CUSTOMER WHERE USERNAME= '" 
                + lf.UsernameText.Text + "'";
            var rs = command.ExecuteReader();
            while (rs.Read())
            {
                if (Convert.ToInt32(rs["Balance"]) >= 1000)
                {
                    BalanceLabel.Text = "Your current balance is: $" + rs["Balance"].ToString() +
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
            items.Add(qty.ToString());
            int index = InventoryList.SelectedItem.ToString().IndexOf("$");
            items.Add(InventoryList.SelectedItem.ToString().Substring(0, index).Trim());
            CheckoutButton.Visible = true;
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

            var command = conn.CreateCommand();
            var c2 = conn.CreateCommand();
            decimal price = 0;
            for (int i = 0; i < items.Count; i += 2)
            {
                int qty = Convert.ToInt32(items.ElementAt(i));
                string item = items.ElementAt(i + 1);
                foreach (String s in items)
                {
                    Console.WriteLine(s);
                }

                c2.CommandText = "INSERT INTO PURCHASES (CustID, ItemName, Qty) VALUES (" +
                    cust.Id + ", '" + item + "', " + qty + ")";
                c2.ExecuteNonQuery();

                command.CommandText = "UPDATE INVENTORY SET QtyInStock -= "+ qty +
                    " WHERE ItemName = '" + item + "'";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT PRICE FROM INVENTORY " +
                    "WHERE ItemName = '" + item + "'";
                var rs = command.ExecuteReader();
                while (rs.Read())
                {
                    price += Convert.ToDecimal(rs["Price"]) * qty;
                }
            }

            c2.CommandText = "UPDATE CUSTOMER SET Balance += " + price +
                "WHERE USERNAME= '" + lf.UsernameText.Text + "'";
            c2.ExecuteNonQuery();

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
            var command = conn.CreateCommand();
            command.CommandText = "SELECT BALANCE FROM CUSTOMER WHERE USERNAME= '" + lf.UsernameText.Text + "'";
            var rs = command.ExecuteReader();
            while (rs.Read())
            {
                BalanceLabel.Text = "Your current balance is: $"+rs["Balance"].ToString() +
                    "\nEnter payment amount below:";
            }
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
                    var command = conn.CreateCommand();
                    command.CommandText = "UPDATE CUSTOMER SET BALANCE -= '" + payment +
                        "'WHERE USERNAME= '" + lf.UsernameText.Text + "'";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT BALANCE FROM CUSTOMER WHERE USERNAME= '" + lf.UsernameText.Text + "'";
                    var rs = command.ExecuteReader();
                    while (rs.Read())
                    {
                        BalanceLabel.Text = "Thank you for your payment! Your current balance is: $" +
                            rs["Balance"];
                    }
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
        }
    }
}
