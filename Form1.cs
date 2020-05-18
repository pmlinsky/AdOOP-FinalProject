using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace FinalProject
{
    public partial class LoginForm : Form
    {
        Customer cust;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameText.Text;
            string password = PasswordText.Text;

            string conn_string = @"Driver={SQL Server};
                                    Server=DESKTOP-FGFE61N\SQLEXPRESS01;
                                    Database=SALES_TRACKER";
            OdbcConnection conn = new OdbcConnection(conn_string);
            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM CUSTOMER WHERE USERNAME= '" + username+"'";
            var rs = command.ExecuteReader();
            while (rs.Read())
            {
                cust = new Customer(Convert.ToInt32(rs["Id"]));
                if (rs["Pswrd"].ToString().Trim().Equals(password))
                {
                    CustomerForm cf = new CustomerForm(this, cust);
                    this.Hide();
                    cf.ShowDialog();
                    this.Close();
                }
            }
            ValidateInfo.SetError(LoginButton, "Invalid Username or Password");
        }
    }
}
