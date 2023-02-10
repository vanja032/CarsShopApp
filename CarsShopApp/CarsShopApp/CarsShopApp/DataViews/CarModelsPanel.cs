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
    public partial class CarModelsPanel : Form
    {
        List<CarModel> models = null;
        List<CarMark> marks = null;
        DataController.DataController database_management = new DataController.DataController();
        public CarModelsPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
        }

        private void CarModelsPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
            FillComboMarks();
        }

        private void RefreshList()
        {
            try
            {
                lbModels.Items.Clear();
                models = database_management.GetAllModels();
                if (models == null)
                    return;
                foreach (CarModel model in models)
                {
                    lbModels.Items.Add("Model id: " + model.id + " Model name: " + model.name + " Mark name: " + model.mark.name);
                }
            }
            catch(Exception e) { return; }
        }
        private void FillComboMarks()
        {
            try
            {
                cbMarks.Items.Clear();
                marks = database_management.GetMarks();
                if (marks == null)
                    return;
                foreach (CarMark mark in marks)
                {
                    cbMarks.Items.Add(mark.name);
                }
            }
            catch (Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string model_name = tbName.Text;
            int mark_id = cbMarks.SelectedIndex;
            if (model_name != "" && mark_id != -1)
            {
                bool success = database_management.InsertModel(model_name, marks[mark_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    lbModels.SelectedIndex = -1;
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
            int model_id = lbModels.SelectedIndex;
            if (model_id != -1)
            {
                bool success = database_management.DeleteModel(models[model_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    lbModels.SelectedIndex = -1;
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
            int model_id = lbModels.SelectedIndex;
            string mark_name = tbName.Text;
            int mark_id = cbMarks.SelectedIndex;
            if (mark_id != -1 && mark_name != "" && model_id != -1)
            {
                bool success = database_management.UpdateModel(models[model_id].id, mark_name, marks[mark_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    lbModels.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void lbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbModels.SelectedIndex;
            if (index != -1) {
                tbName.Text = models[index].name;
                cbMarks.SelectedItem = models[index].mark.name;
            }
        }
    }
}
