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
    public partial class CarMarksPanel : Form
    {
        List<CarMark> marks = null;
        DataController.DataController database_management = new DataController.DataController();
        public CarMarksPanel(DataController.DataController database_management)
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
                lbMarks.Items.Clear();
                marks = database_management.GetMarks();
                if (marks == null)
                    return;
                foreach (CarMark mark in marks)
                {
                    lbMarks.Items.Add("Mark id: " + mark.id + " Mark name: " + mark.name);
                }
            }
            catch(Exception e) { return; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string mark_name = tbName.Text;
            if (mark_name != "")
            {
                bool success = database_management.InsertMark(mark_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbMarks.SelectedIndex = -1;
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
            int mark_id = lbMarks.SelectedIndex;
            if (mark_id != -1)
            {
                bool success = database_management.DeleteMark(marks[mark_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbMarks.SelectedIndex = -1;
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
            int mark_id = lbMarks.SelectedIndex;
            string mark_name = tbName.Text;
            if (mark_id != -1 && mark_name != "")
            {
                bool success = database_management.UpdateMark(marks[mark_id].id, mark_name);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    lbMarks.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void lbMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbMarks.SelectedIndex;
            if (index != -1)
                tbName.Text = marks[index].name;
        }
    }
}
