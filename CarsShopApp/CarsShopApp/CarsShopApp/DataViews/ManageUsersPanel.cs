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
    public partial class ManageUsersPanel : Form
    {
        List<User> users = null;
        DataController.DataController database_management = new DataController.DataController();
        public ManageUsersPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
        }

        private void CarMarksPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                lbUsers.Items.Clear();
                users = database_management.GetUsers();
                if (users == null)
                    return;
                foreach (User user in users)
                {
                    lbUsers.Items.Add("User id: " + user.id + " First name: " + user.first_name + " Last name: " + user.last_name + " Email: " + user.email + " Username: " + user.username + " Password: " + "".PadLeft(user.password.Length, '*') + " User role: " + user.role);
                }
            }
            catch(Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string first_name = tbFirstName.Text;
            string last_name = tbLastName.Text;
            string email = tbEmail.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string profile = ProfilePictureDialog.FileName;
            string role = tbRole.Text;
            if (first_name != "" && last_name != "" && email != "" && username != "" && password != "" && profile != "")
            {
                bool success = database_management.InsertUser(first_name, last_name, email, username, password, profile, role);
                if (success)
                {
                    RefreshList();
                    tbFirstName.Text = "";
                    tbLastName.Text = "";
                    tbEmail.Text = "";
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    ProfilePictureDialog.FileName = "";
                    pbProfilePicture.Image = null;
                    tbRole.Text = "";
                    lbUsers.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Insert.");
                }
                else
                    MessageBox.Show("Error occured while inserting the data into database.");
            }
            else
                MessageBox.Show("Fields must not be empty. Please fill the fields.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int user_id = lbUsers.SelectedIndex;
            if (user_id != -1)
            {
                bool success = database_management.DeleteUser(users[user_id].id);
                if (success)
                {
                    RefreshList();
                    tbFirstName.Text = "";
                    tbLastName.Text = "";
                    tbEmail.Text = "";
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    ProfilePictureDialog.FileName = "";
                    pbProfilePicture.Image = null;
                    tbRole.Text = "";
                    lbUsers.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Delete.");
                }
                else
                    MessageBox.Show("Error occured while deleting the data in the database.");
            }
            else
                MessageBox.Show("Please select an item for remove.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int user_id = lbUsers.SelectedIndex;
            string first_name = tbFirstName.Text;
            string last_name = tbLastName.Text;
            string email = tbEmail.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string profile = ProfilePictureDialog.FileName;
            string role = tbRole.Text;
            if (user_id != -1 && first_name != "" && last_name != "" && email != "" && username != "" && password != "" && profile != "")
            {
                bool success = database_management.UpdateUser(users[user_id].id, first_name, last_name, email, username, password, profile, role);
                if (success)
                {
                    RefreshList();
                    tbFirstName.Text = "";
                    tbLastName.Text = "";
                    tbEmail.Text = "";
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    ProfilePictureDialog.FileName = "";
                    pbProfilePicture.Image = null;
                    tbRole.Text = "";
                    lbUsers.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void btnProfilePicture_Click(object sender, EventArgs e)
        {
            try
            {
                ProfilePictureDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if(ProfilePictureDialog.ShowDialog() == DialogResult.OK)
                {
                    pbProfilePicture.Image = new Bitmap(ProfilePictureDialog.FileName);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); return; }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbUsers.SelectedIndex;
            if (index != -1)
            {
                tbFirstName.Text = users[index].first_name;
                tbLastName.Text = users[index].last_name;
                tbEmail.Text = users[index].email;
                tbUsername.Text = users[index].username;
                tbPassword.Text = users[index].password;
                ProfilePictureDialog.FileName = users[index].profile_picture;
                pbProfilePicture.Image = new Bitmap(users[index].profile_picture);
                tbRole.Text = users[index].role;
            }
        }
    }
}
