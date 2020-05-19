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
        SalesTrackerDBDataContext db;
        public LoginForm()
        {
            InitializeComponent();
            db = new SalesTrackerDBDataContext();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameText.Text;
            string password = PasswordText.Text;

            var cust = db.CUSTOMERs.Where(c => c.Username.Equals(username)).FirstOrDefault();
            if (cust == null)
            {
                ValidateInfo.SetError(LoginButton, "Invalid Username or Password");
            }
            else if (cust.Pswrd.Trim().Equals(password))
            {
                CustomerForm cf = new CustomerForm(this, db);
                this.Hide();
                cf.ShowDialog();
                this.Close();
            }
            ValidateInfo.SetError(LoginButton, "Invalid Username or Password");
        }
    }
}
