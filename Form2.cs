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
        static string conn_string = @"Driver={SQL Server};
                                    Server=DESKTOP-FGFE61N\SQLEXPRESS01;
                                    Database=SALES_TRACKER";
        OdbcConnection conn = new OdbcConnection(conn_string);

        public static Stack<Object> buttons = new Stack<Object>();

        LoginForm lf;
        public CustomerForm(LoginForm lf)
        {
            InitializeComponent();
            this.lf = lf;
            conn.Open();
            buttons.Push(InventoryList);
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM INVENTORY ORDER BY ItemName";
            var rs = command.ExecuteReader();
            while (rs.Read())
            {
                if (!rs["QtyInStock"].ToString().Trim().Equals("0"))
                {
                    InventoryList.Items.Add(rs["ItemName"].ToString().Trim() +
                        " -- $" + rs["Price"]);
                }
            }
            InventoryList.Visible = true;
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {

        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
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

        }

        private void click()
        {
            foreach (Button b in buttons)
            {
                b.Visible = false;
            }
        }
        private void done()
        {
            foreach (Button b in buttons)
            {
                b.Visible = true;
            }
        }

        private void Menu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.ShowDialog();
            this.Close();
        }

    }
}
