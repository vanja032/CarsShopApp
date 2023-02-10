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
    public partial class CarTypesPanel : Form
    {
        List<CarType> types = null;
        DataController.DataController database_management = new DataController.DataController();
        public CarTypesPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
        }

        private void CarTypesPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                lbTypes.Items.Clear();
                types = database_management.GetTypes();
                if (types == null)
                    return;
                foreach (CarType type in types)
                {
                    lbTypes.Items.Add("Type id: " + type.id + " Type name: " + type.name);
                }
            }
            catch(Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string type_name = tbName.Text;
            if (type_name != "")
            {
                bool success = database_management.InsertType(type_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbTypes.SelectedIndex = -1;
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
            int type_id = lbTypes.SelectedIndex;
            if (type_id != -1)
            {
                bool success = database_management.DeleteType(types[type_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbTypes.SelectedIndex = -1;
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
            int type_id = lbTypes.SelectedIndex;
            string type_name = tbName.Text;
            if (type_id != -1 && type_name != "")
            {
                bool success = database_management.UpdateType(types[type_id].id, type_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbTypes.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void lbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbTypes.SelectedIndex;
            if (index != -1)
                tbName.Text = types[index].name;
        }
    }
}
