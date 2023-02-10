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
    public partial class CarsPanel : Form
    {
        #region Data lists
        List<CarModel> models = null;
        List<CarMark> marks = null;
        List<CarType> types = null;
        List<Fuel> fuels = null;
        List<CarGearbox> gearboxes = null;
        List<Car> cars = null;
        #endregion
        DataController.DataController database_management = new DataController.DataController();
        public CarsPanel(DataController.DataController database_management)
        {
            this.database_management = database_management;
            InitializeComponent();
            manufacturingDate.Value = DateTime.Now;
        }

        private void CarModelsPanel_Load(object sender, EventArgs e)
        {
            RefreshList();
            FillComboMarks();
            FillComboGearboxes();
            FillComboTypes();
            FillComboFuels();
        }
        #region Filling the data
        private void RefreshList()
        {
            try
            {
                lbCars.Items.Clear();
                cars = database_management.GetCars();
                if (cars == null)
                    return;
                foreach (Car car in cars)
                {
                    lbCars.Items.Add("Car id: " + car.id + " Car name: " + car.name + "Mark name: " + car.mark.name + " Model name: " + car.model.name + " Gearbox: " + car.gearbox.name + " Fuel: " + car.fuel.name + " Type: " + car.type.name + " Engine volume (cm3): " + car.engine_volume + " Manufacturing date: " + car.manufacturing_date);
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
        private void FillComboModels(int mark_id)
        {
            try
            {
                cbModels.Items.Clear();
                models = database_management.GetModels(mark_id);
                if (models == null)
                    return;
                foreach (CarModel model in models)
                {
                    cbModels.Items.Add(model.name);
                }
            }
            catch (Exception e) { return; }
        }
        private void FillComboGearboxes()
        {
            try
            {
                cbGearboxes.Items.Clear();
                gearboxes = database_management.GetGearboxes();
                if (gearboxes == null)
                    return;
                foreach (CarGearbox gearbox in gearboxes)
                {
                    cbGearboxes.Items.Add(gearbox.name);
                }
            }
            catch (Exception e) { return; }
        }
        private void FillComboTypes()
        {
            try
            {
                cbTypes.Items.Clear();
                types = database_management.GetTypes();
                if (types == null)
                    return;
                foreach (CarType type in types)
                {
                    cbTypes.Items.Add(type.name);
                }
            }
            catch (Exception e) { return; }
        }
        private void FillComboFuels()
        {
            try
            {
                cbFuels.Items.Clear();
                fuels = database_management.GetFuels();
                if (fuels == null)
                    return;
                foreach (Fuel fuel in fuels)
                {
                    cbFuels.Items.Add(fuel.name);
                }
            }
            catch (Exception e) { return; }
        }
        #endregion
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string car_name = tbName.Text;
            int mark_id = cbMarks.SelectedIndex;
            int model_id = cbModels.SelectedIndex;
            int gearbox_id = cbGearboxes.SelectedIndex;
            int type_id = cbTypes.SelectedIndex;
            int fuel_id = cbFuels.SelectedIndex;
            DateTime date = manufacturingDate.Value;
            string engine_vol = tbEngineVolume.Text;
            int engine_v = 0;
            if (car_name != "" && mark_id != -1 && model_id != -1 && gearbox_id != -1 && type_id != -1 && fuel_id != -1 && date != null && date.ToString() != "" && engine_vol != "" && int.TryParse(engine_vol, out engine_v))
            {
                bool success = database_management.InsertCar(car_name, marks[mark_id].id, models[model_id].id, date.ToString(), fuels[fuel_id].id, engine_v, gearboxes[gearbox_id].id, types[type_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    cbModels.SelectedIndex = -1;
                    cbGearboxes.SelectedIndex = -1;
                    cbTypes.SelectedIndex = -1;
                    cbFuels.SelectedIndex = -1;
                    manufacturingDate.Value = DateTime.Now;
                    tbEngineVolume.Text = "";
                    lbCars.SelectedIndex = -1;
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
            int car_id = lbCars.SelectedIndex;
            if (car_id != -1)
            {
                bool success = database_management.DeleteCar(cars[car_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    cbModels.SelectedIndex = -1;
                    cbGearboxes.SelectedIndex = -1;
                    cbTypes.SelectedIndex = -1;
                    cbFuels.SelectedIndex = -1;
                    manufacturingDate.Value = DateTime.Now;
                    tbEngineVolume.Text = "";
                    lbCars.SelectedIndex = -1;
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
            int car_id = lbCars.SelectedIndex;
            string car_name = tbName.Text;
            int mark_id = cbMarks.SelectedIndex;
            int model_id = cbModels.SelectedIndex;
            int gearbox_id = cbGearboxes.SelectedIndex;
            int type_id = cbTypes.SelectedIndex;
            int fuel_id = cbFuels.SelectedIndex;
            DateTime date = manufacturingDate.Value;
            string engine_vol = tbEngineVolume.Text;
            int engine_v = 0;
            if (car_id != -1 && car_name != "" && mark_id != -1 && model_id != -1 && gearbox_id != -1 && type_id != -1 && fuel_id != -1 && date != null && date.ToString() != "" && engine_vol != "" && int.TryParse(engine_vol, out engine_v))
            {
                bool success = database_management.UpdateCar(cars[car_id].id, car_name, marks[mark_id].id, models[model_id].id, date.ToString(), fuels[fuel_id].id, engine_v, gearboxes[gearbox_id].id, types[type_id].id);
                if (success)
                {
                    RefreshList();
                    tbName.Text = "";
                    cbMarks.SelectedIndex = -1;
                    cbModels.SelectedIndex = -1;
                    cbGearboxes.SelectedIndex = -1;
                    cbTypes.SelectedIndex = -1;
                    cbFuels.SelectedIndex = -1;
                    manufacturingDate.Value = DateTime.Now;
                    tbEngineVolume.Text = "";
                    lbCars.SelectedIndex = -1;
                    MessageBox.Show("Successful operation Update.");
                }
                else
                    MessageBox.Show("Error occured while updating the data in the database.");
            }
            else
                MessageBox.Show("Please select an item and fill the fields for update.");
        }

        private void cbMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbMarks.SelectedIndex;
            if (index != -1)
            {
                FillComboModels(marks[index].id);
                cbModels.Enabled = true;
            }
            else
            {
                cbModels.Enabled = false;
                cbModels.SelectedIndex = -1;
                models = null;
            }
        }

        private void lbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbCars.SelectedIndex;
            if (index != -1)
            {
                tbName.Text = cars[index].name;
                cbMarks.SelectedItem = cars[index].mark.name;
                cbModels.SelectedItem = cars[index].model.name;
                cbGearboxes.SelectedItem = cars[index].gearbox.name;
                cbTypes.SelectedItem = cars[index].type.name;
                cbFuels.SelectedItem = cars[index].fuel.name;
                manufacturingDate.Value = DateTime.Parse(cars[index].manufacturing_date);
                tbEngineVolume.Text = cars[index].engine_volume.ToString();
            }
        }
    }
}
