using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarsShopApp.DataController;
using CarsShopApp.DataModel.Models;

namespace CarsShopApp.DataViews
{
    public partial class LogIn : Form
    {
        DataController.DataController database_management = new DataController.DataController();
        public LogIn()
        {
            InitializeComponent();
            //Press Enter keyboard button to Log in
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (username != "" && password != "")
            {
                User user = database_management.LogIn(username, password);
                tbUsername.Text = "";
                tbPassword.Text = "";
                if (user != null)
                {
                    lblMessage.Text = "";
                    UserPanel user_panel = new UserPanel(database_management, user);
                    user_panel.FormClosed += (s, args) => {
                        if (user_panel.DialogResult == DialogResult.Abort)
                            this.Show();
                        else
                            this.Close();
                        database_management.LogOut();
                    };
                    user_panel.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "Wrong username and/or password.";
                }
            }
            else
                MessageBox.Show("Fields must not be empty. Please fill the fields.");
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
