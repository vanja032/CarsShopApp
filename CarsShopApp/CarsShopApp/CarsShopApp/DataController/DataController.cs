using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsShopApp.DataModel;
using CarsShopApp.DataModel.Models;
using System.Data;

namespace CarsShopApp.DataController
{
    public class DataController
    {
        #region DatabaseConnection Objects
        private DatabaseConnection users_database_manager;
        private DatabaseConnection cars_database_manager;
        private DatabaseConnection car_models_database_manager;
        private DatabaseConnection car_marks_database_manager;
        private DatabaseConnection car_types_database_manager;
        private DatabaseConnection car_gearboxes_database_manager;
        private DatabaseConnection fuels_database_manager;
        #endregion
        #region DataSet Objects
        private DataSet users_dataset;
        private DataSet cars_dataset;
        private DataSet car_models_dataset;
        private DataSet car_marks_dataset;
        private DataSet car_types_dataset;
        private DataSet car_gearboxes_dataset;
        private DataSet fuels_dataset;
        #endregion
        public DataController()
        {
            users_database_manager = new DatabaseConnection();
            cars_database_manager = new DatabaseConnection();
            car_models_database_manager = new DatabaseConnection();
            car_marks_database_manager = new DatabaseConnection();
            car_types_database_manager = new DatabaseConnection();
            car_gearboxes_database_manager = new DatabaseConnection();
            fuels_database_manager = new DatabaseConnection();
        }
        public User LogIn(string username, string password)
        {
            try
            {
                DataSet set = users_database_manager.GetData(String.Format(@"SELECT User_id, User_first_name, User_last_name, User_email, User_username, User_password, User_picture 
                        FROM Users WHERE User_username = '{0}' AND User_password = '{1}'", username, password));
                users_dataset = set;
                if(set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    User user = new User
                    {
                        id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                        first_name = row.ItemArray.GetValue(1).ToString(),
                        last_name = row.ItemArray.GetValue(2).ToString(),
                        email = row.ItemArray.GetValue(3).ToString(),
                        username = row.ItemArray.GetValue(4).ToString(),
                        password = row.ItemArray.GetValue(5).ToString(),
                        profile_picture = row.ItemArray.GetValue(6).ToString()
                    };
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e) { return null; }
        }
        public void LogOut()
        {
            users_database_manager = new DatabaseConnection();
            cars_database_manager = new DatabaseConnection();
            car_models_database_manager = new DatabaseConnection();
            car_marks_database_manager = new DatabaseConnection();
            car_types_database_manager = new DatabaseConnection();
            car_gearboxes_database_manager = new DatabaseConnection();
            fuels_database_manager = new DatabaseConnection();

            users_dataset = null;
            cars_dataset = null;
            car_models_dataset = null;
            car_marks_dataset = null;
            car_types_dataset = null;
            car_gearboxes_dataset = null;
            fuels_dataset = null;
        }
        public List<CarMark> GetMarks()
        {
            try
            {
                DataSet set = car_marks_database_manager.GetData("SELECT Mark_id, Mark_name FROM Car_Marks");
                car_marks_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<CarMark> marks = new List<CarMark>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarMark mark = new CarMark
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString()
                        };
                        marks.Add(mark);
                    }
                    return marks;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<CarGearbox> GetGearboxes()
        {
            try
            {
                DataSet set = car_gearboxes_database_manager.GetData("SELECT Gearbox_id, Gearbox_name FROM Car_Gearboxes");
                car_gearboxes_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<CarGearbox> gearboxes = new List<CarGearbox>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarGearbox gearbox = new CarGearbox
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString()
                        };
                        gearboxes.Add(gearbox);
                    }
                    return gearboxes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<CarType> GetTypes()
        {
            try
            {
                DataSet set = car_types_database_manager.GetData("SELECT Type_id, Type_name FROM Car_Types");
                car_types_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<CarType> types = new List<CarType>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarType type = new CarType
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString()
                        };
                        types.Add(type);
                    }
                    return types;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<Fuel> GetFuels()
        {
            try
            {
                DataSet set = fuels_database_manager.GetData("SELECT Fuel_id, Fuel_name FROM Fuels");
                fuels_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<Fuel> fuels = new List<Fuel>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        Fuel fuel = new Fuel
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString()
                        };
                        fuels.Add(fuel);
                    }
                    return fuels;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<CarModel> GetAllModels()
        {
            try
            {
                DataSet set = car_models_database_manager.GetData(@"SELECT Model_id, Model_name, Car_mark, Mark_name FROM Car_Models, Car_Marks
                        WHERE Car_Models.Car_mark = Car_Marks.Mark_id");
                car_models_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<CarModel> models = new List<CarModel>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarMark mark = new CarMark
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(2)),
                            name = row.ItemArray.GetValue(3).ToString()
                        };
                        CarModel model = new CarModel
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString(),
                            mark = mark
                        };
                        
                        models.Add(model);
                    }
                    return models;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<CarModel> GetModel(int mark_id)
        {
            try
            {
                DatabaseConnection temp_connection = new DatabaseConnection();
                DataSet set = temp_connection.GetData(String.Format(@"SELECT Car_Models.Model_id, Car_Models.Model_name, Car_Models.Car_mark, Car_Marks.Mark_name FROM Car_Models, Car_Marks
                        WHERE Car_Models.Car_mark = Car_Marks.Mark_id AND Car_Models.Car_mark = {0}", mark_id));
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<CarModel> models = new List<CarModel>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarMark mark = new CarMark
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(2)),
                            name = row.ItemArray.GetValue(3).ToString()
                        };
                        CarModel model = new CarModel
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString(),
                            mark = mark
                        };

                        models.Add(model);
                    }
                    return models;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public List<Car> GetCars()
        {
            try
            {
                DataSet set = cars_database_manager.GetData(@"SELECT Cars.Car_id, Cars.Car_name, Cars.Car_mark, Car_Marks.Mark_name, Cars.Car_model, Car_Models.Model_name, 
                        Cars.Car_manufacturing_date, Cars.Car_fuel, Fuels.Fuel_name, Cars.Car_engine_volume, Cars.Car_gearbox, Car_Gearboxes.Gearbox_name, Cars.Car_type, Car_Types.Type_name 
                        FROM Cars, Car_Marks, Car_Models, Fuels, Car_Gearboxes, Car_Types
                        WHERE Cars.Car_mark = Car_Marks.Mark_id AND Cars.Car_model = Car_Models.Model_id AND Cars.Car_fuel = Fuels.Fuel_id AND Cars.Car_gearbox = 
                        Car_Gearboxes.Gearbox_id AND Cars.Car_type = Car_Types.Type_id");
                cars_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<Car> cars = new List<Car>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        CarMark mark = new CarMark
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(2)),
                            name = row.ItemArray.GetValue(3).ToString()
                        };
                        CarModel model = new CarModel
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(4)),
                            name = row.ItemArray.GetValue(5).ToString(),
                            mark = mark
                        };
                        CarGearbox gearbox = new CarGearbox
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(10)),
                            name = row.ItemArray.GetValue(11).ToString()
                        };
                        CarType type = new CarType
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(12)),
                            name = row.ItemArray.GetValue(13).ToString()
                        };
                        Fuel fuel = new Fuel
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(7)),
                            name = row.ItemArray.GetValue(8).ToString()
                        };
                        Car car = new Car
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            name = row.ItemArray.GetValue(1).ToString(),
                            mark = mark,
                            model = model,
                            manufacturing_date = row.ItemArray.GetValue(6).ToString(),
                            fuel = fuel,
                            engine_volume = Convert.ToInt32(row.ItemArray.GetValue(9)),
                            gearbox = gearbox,
                            type = type
                        };

                        cars.Add(car);
                    }
                    return cars;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public bool InsertMark(string name)
        {
            try
            {
                DataRow row = car_marks_dataset.Tables[0].NewRow();
                row[1] = name.Trim();
                car_marks_dataset.Tables[0].Rows.Add(row);
                car_marks_database_manager.RefreshDatabase(car_marks_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool InsertGearbox(string name)
        {
            try
            {
                DataRow row = car_gearboxes_dataset.Tables[0].NewRow();
                row[1] = name.Trim();
                car_gearboxes_dataset.Tables[0].Rows.Add(row);
                car_gearboxes_database_manager.RefreshDatabase(car_gearboxes_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool InsertType(string name)
        {
            try
            {
                DataRow row = car_types_dataset.Tables[0].NewRow();
                row[1] = name.Trim();
                car_types_dataset.Tables[0].Rows.Add(row);
                car_types_database_manager.RefreshDatabase(car_types_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool InsertFuel(string name)
        {
            try
            {
                DataRow row = fuels_dataset.Tables[0].NewRow();
                row[1] = name.Trim();
                fuels_dataset.Tables[0].Rows.Add(row);
                fuels_database_manager.RefreshDatabase(fuels_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool InsertModel(string name, int mark_id)
        {
            try
            {
                DataRow row = car_models_dataset.Tables[0].NewRow();
                row[1] = name.Trim();
                row[2] = mark_id;
                car_models_dataset.Tables[0].Rows.Add(row);
                car_models_database_manager.RefreshDatabase(car_models_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}
