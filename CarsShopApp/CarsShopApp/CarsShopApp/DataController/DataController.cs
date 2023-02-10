using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsShopApp.DataModel;
using CarsShopApp.DataModel.Models;
using System.Data;
using System.Windows.Forms;

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
        #region Constructors
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
        #endregion
        #region User methods
        public User LogIn(string username, string password)
        {
            try
            {
                DataSet set = users_database_manager.GetData(String.Format(@"SELECT User_id, User_first_name, User_last_name, User_email, User_username, User_password, User_picture, User_role
                        FROM Users WHERE User_username = '{0}' AND User_password = '{1}'", username, password));
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
                        profile_picture = row.ItemArray.GetValue(6).ToString(),
                        role = row.ItemArray.GetValue(7).ToString()
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
        public List<User> GetUsers()
        {
            try
            {
                DataSet set = users_database_manager.GetData("SELECT User_id, User_first_name, User_last_name, User_email, User_username, User_password, User_picture, User_role FROM Users");
                users_dataset = set;
                if (set.Tables[0].Rows.Count > 0)
                {
                    List<User> users = new List<User>();
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        User user = new User
                        {
                            id = Convert.ToInt32(row.ItemArray.GetValue(0)),
                            first_name = row.ItemArray.GetValue(1).ToString(),
                            last_name = row.ItemArray.GetValue(2).ToString(),
                            email = row.ItemArray.GetValue(3).ToString(),
                            username = row.ItemArray.GetValue(4).ToString(),
                            password = row.ItemArray.GetValue(5).ToString(),
                            profile_picture = row.ItemArray.GetValue(6).ToString(),
                            role = row.ItemArray.GetValue(7).ToString()
                        };
                        users.Add(user);
                    }
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { return null; }
        }
        public bool InsertUser(string first_name, string last_name, string email, string username, string password, string picture, string role)
        {
            try
            {
                DataRow row = users_dataset.Tables[0].NewRow();
                row[1] = first_name.Trim();
                row[2] = last_name.Trim();
                row[3] = email.Trim();
                row[4] = username.Trim();
                row[5] = password.Trim();
                row[6] = picture.Trim();
                row[7] = role.Trim();
                users_dataset.Tables[0].Rows.Add(row);
                users_database_manager.RefreshDatabase(users_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateUser(int user_id, string first_name, string last_name, string email, string username, string password, string picture, string role)
        {
            try
            {
                GetUsers();
                foreach (DataRow row in users_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == user_id)
                    {
                        row[1] = first_name.Trim();
                        row[2] = last_name.Trim();
                        row[3] = email.Trim();
                        row[4] = username.Trim();
                        row[5] = password.Trim();
                        row[6] = picture.Trim();
                        row[7] = role.Trim();
                    }
                }
                users_database_manager.RefreshDatabase(users_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteUser(int user_id)
        {
            try
            {
                GetUsers();
                foreach (DataRow row in users_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == user_id)
                    {
                        row.Delete();
                    }
                }
                users_database_manager.RefreshDatabase(users_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        #endregion
        #region Get data
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
        public List<CarModel> GetModels(int mark_id)
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
        #endregion
        #region Insert data
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
                string query = String.Format(@"INSERT INTO Car_Models(Model_name, Car_Mark)
                        VALUES('{0}', {1})", name.Trim(), mark_id);
                car_models_database_manager.ExecuteExternalTableCommand(query);
                GetAllModels();
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool InsertCar(string name, int mark_id, int model_id, string manufacturing_date, int fuel_id, int engine_volume, int gearbox_id, int type_id)
        {
            try
            {
                string query = String.Format(@"INSERT INTO Cars(Car_name, Car_mark, Car_model, Car_manufacturing_date, Car_fuel, Car_engine_volume, Car_gearbox, Car_type)
                        VALUES('{0}', {1}, {2}, '{3}', {4}, {5}, {6}, {7})", name.Trim(), mark_id, model_id, manufacturing_date.Trim(), fuel_id, engine_volume, gearbox_id, type_id);
                cars_database_manager.ExecuteExternalTableCommand(query);
                GetCars();
                return true;
            }
            catch (Exception e) { return false; }
        }
        #endregion
        #region Update data
        public bool UpdateMark(int mark_id, string name)
        {
            try
            {
                GetMarks();
                foreach(DataRow row in car_marks_dataset.Tables[0].Rows)
                {
                    if(Convert.ToInt32(row[0]) == mark_id)
                    {
                        row[1] = name.Trim();
                    }
                }
                car_marks_database_manager.RefreshDatabase(car_marks_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateGearbox(int gearbox_id, string name)
        {
            try
            {
                GetGearboxes();
                foreach (DataRow row in car_gearboxes_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == gearbox_id)
                    {
                        row[1] = name.Trim();
                    }
                }
                car_gearboxes_database_manager.RefreshDatabase(car_gearboxes_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateType(int type_id, string name)
        {
            try
            {
                GetTypes();
                foreach (DataRow row in car_types_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == type_id)
                    {
                        row[1] = name.Trim();
                    }
                }
                car_types_database_manager.RefreshDatabase(car_types_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateFuel(int fuel_id, string name)
        {
            try
            {
                GetFuels();
                foreach (DataRow row in fuels_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == fuel_id)
                    {
                        row[1] = name.Trim();
                    }
                }
                fuels_database_manager.RefreshDatabase(fuels_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateModel(int model_id, string name, int mark_id)
        {
            try
            {
                string query = String.Format(@"UPDATE Car_Models
                        SET Model_name = '{0}', Car_Mark = {1}
                        WHERE Model_id = {2}", name.Trim(), mark_id, model_id);
                car_models_database_manager.ExecuteExternalTableCommand(query);
                GetAllModels();
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool UpdateCar(int car_id, string name, int mark_id, int model_id, string manufacturing_date, int fuel_id, int engine_volume, int gearbox_id, int type_id)
        {
            try
            {
                string query = String.Format(@"UPDATE Cars
                        SET Car_name = '{0}', Car_mark = {1}, Car_model = {2}, Car_manufacturing_date = '{3}', Car_fuel = {4}, Car_engine_volume = {5}, Car_gearbox = {6}, Car_type = {7}
                        WHERE Car_id = {8}", name.Trim(), mark_id, model_id, manufacturing_date.Trim(), fuel_id, engine_volume, gearbox_id, type_id, car_id);
                cars_database_manager.ExecuteExternalTableCommand(query);
                GetCars();
                return true;
            }
            catch (Exception e) { return false; }
        }
        #endregion
        #region Delete data
        public bool DeleteMark(int mark_id)
        {
            try
            {
                GetMarks();
                foreach (DataRow row in car_marks_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == mark_id)
                    {
                        row.Delete();
                    }
                }
                car_marks_database_manager.RefreshDatabase(car_marks_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteGearbox(int gearbox_id)
        {
            try
            {
                GetGearboxes();
                foreach (DataRow row in car_gearboxes_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == gearbox_id)
                    {
                        row.Delete();
                    }
                }
                car_gearboxes_database_manager.RefreshDatabase(car_gearboxes_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteType(int type_id)
        {
            try
            {
                GetTypes();
                foreach (DataRow row in car_types_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == type_id)
                    {
                        row.Delete();
                    }
                }
                car_types_database_manager.RefreshDatabase(car_types_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteFuel(int fuel_id)
        {
            try
            {
                GetFuels();
                foreach (DataRow row in fuels_dataset.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row[0]) == fuel_id)
                    {
                        row.Delete();
                    }
                }
                fuels_database_manager.RefreshDatabase(fuels_dataset);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteModel(int model_id)
        {
            try
            {
                try
                {
                    string query = String.Format(@"DELETE FROM Car_Models
                        WHERE Model_id = {0}", model_id);
                    car_models_database_manager.ExecuteExternalTableCommand(query);
                    GetAllModels();
                    return true;
                }
                catch (Exception e) { return false; }
            }
            catch (Exception e) { return false; }
        }
        public bool DeleteCar(int car_id)
        {
            try
            {
                string query = String.Format(@"DELETE FROM Cars
                        WHERE Car_id = {0}", car_id);
                cars_database_manager.ExecuteExternalTableCommand(query);
                GetCars();
                return true;
            }
            catch (Exception e) { return false; }
        }
        #endregion
    }
}
