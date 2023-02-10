using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarsShopApp.DataModel.Models;

namespace CarsShopApp.DataViews
{
    public partial class UserPanel : Form
    {
        User current_user;
        DataController.DataController database_management = new DataController.DataController();
        public UserPanel(DataController.DataController database_management, User user)
        {
            this.database_management = database_management;
            this.current_user = user;
            InitializeComponent();
            //Show Admin Dashboard if user has "admin" role
            if (current_user.role == UserRoles.AdminRole)
                AdminDashboard.Visible = true;
        }

        private void panelMarks_Click(object sender, EventArgs e)
        {
            CarMarksPanel marks_panel = new CarMarksPanel(database_management);
            marks_panel.FormClosed += (s, args) => this.Show();
            marks_panel.Show();
            this.Hide();
        }

        private void panelTypes_Click(object sender, EventArgs e)
        {
            CarTypesPanel types_panel = new CarTypesPanel(database_management);
            types_panel.FormClosed += (s, args) => this.Show();
            types_panel.Show();
            this.Hide();
        }

        private void panelGearboxes_Click(object sender, EventArgs e)
        {
            CarGearboxesPanel gearboxes_panel = new CarGearboxesPanel(database_management);
            gearboxes_panel.FormClosed += (s, args) => this.Show();
            gearboxes_panel.Show();
            this.Hide();
        }

        private void panelFuels_Click(object sender, EventArgs e)
        {
            FuelPanel fuels_panel = new FuelPanel(database_management);
            fuels_panel.FormClosed += (s, args) => this.Show();
            fuels_panel.Show();
            this.Hide();
        }

        private void panelModels_Click(object sender, EventArgs e)
        {
            CarModelsPanel models_panel = new CarModelsPanel(database_management);
            models_panel.FormClosed += (s, args) => this.Show();
            models_panel.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void panelCars_Click(object sender, EventArgs e)
        {
            CarsPanel cars_panel = new CarsPanel(database_management);
            cars_panel.FormClosed += (s, args) => this.Show();
            cars_panel.Show();
            this.Hide();
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            try
            {
                pbProfilePicture.Image = Image.FromFile(current_user.profile_picture);
                lblUsername.Text = current_user.username;
                lblEmail.Text = current_user.email;
                lblWelcome.Text = "Welcome, " + current_user.first_name + " " + current_user.last_name;
            }
            catch(Exception ex) { return; }
        }

        private void AdminUsersPanel_Click(object sender, EventArgs e)
        {
            ManageUsersPanel user_manager_panel = new ManageUsersPanel(database_management);
            user_manager_panel.FormClosed += (s, args) => this.Show();
            user_manager_panel.Show();
            this.Hide();
        }
    }
}
