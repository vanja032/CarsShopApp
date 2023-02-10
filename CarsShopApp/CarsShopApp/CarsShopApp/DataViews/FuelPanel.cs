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
    public partial class FuelPanel : Form
    {
        List<Fuel> fuels = null;
        DataController.DataController database_management = new DataController.DataController();
        public FuelPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
        }

        private void FuelsPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                lbFuels.Items.Clear();
                fuels = database_management.GetFuels();
                if (fuels == null)
                    return;
                foreach (Fuel fuel in fuels)
                {
                    lbFuels.Items.Add("Fuel id: " + fuel.id + " Fuel name: " + fuel.name);
                }
            }
            catch(Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string fuel_name = tbName.Text;
            if (fuel_name != "")
            {
                bool success = database_management.InsertFuel(fuel_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbFuels.SelectedIndex = -1;
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
            int fuel_id = lbFuels.SelectedIndex;
            if (fuel_id != -1)
            {
                bool success = database_management.DeleteFuel(fuels[fuel_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbFuels.SelectedIndex = -1;
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
            int fuel_id = lbFuels.SelectedIndex;
            string fuel_name = tbName.Text;
            if (fuel_id != -1 && fuel_name != "")
            {
                bool success = database_management.UpdateFuel(fuels[fuel_id].id, fuel_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbFuels.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void lbFuels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbFuels.SelectedIndex;
            if (index != -1)
                tbName.Text = fuels[index].name;
        }
    }
}
