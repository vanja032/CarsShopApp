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
    public partial class CarGearboxesPanel : Form
    {
        List<CarGearbox> gearboxes = null;
        DataController.DataController database_management = new DataController.DataController();
        public CarGearboxesPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
        }

        private void CarGearboxesPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                lbGearboxes.Items.Clear();
                gearboxes = database_management.GetGearboxes();
                if (gearboxes == null)
                    return;
                foreach (CarGearbox gearbox in gearboxes)
                {
                    lbGearboxes.Items.Add("Gearbox id: " + gearbox.id + " Gearbox name: " + gearbox.name);
                }
            }
            catch(Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string gearbox_name = tbName.Text;
            if (gearbox_name != "")
            {
                bool success = database_management.InsertGearbox(gearbox_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbGearboxes.SelectedIndex = -1;
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
            int gearbox_id = lbGearboxes.SelectedIndex;
            if (gearbox_id != -1)
            {
                bool success = database_management.DeleteGearbox(gearboxes[gearbox_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbGearboxes.SelectedIndex = -1;
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
            int gearbox_id = lbGearboxes.SelectedIndex;
            string gearbox_name = tbName.Text;
            if (gearbox_id != -1 && gearbox_name != "")
            {
                bool success = database_management.UpdateGearbox(gearboxes[gearbox_id].id, gearbox_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbGearboxes.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void lbGearboxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbGearboxes.SelectedIndex;
            if (index != -1)
                tbName.Text = gearboxes[index].name;
        }
    }
}
