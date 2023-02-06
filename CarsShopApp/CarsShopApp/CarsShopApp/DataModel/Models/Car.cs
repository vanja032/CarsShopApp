using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShopApp.DataModel.Models
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public CarMark mark { get; set; }
        public CarModel model { get; set; }
        public string manufacturing_date { get; set; }
        public Fuel fuel { get; set; }
        public int engine_volume { get; set; }
        public CarGearbox gearbox { get; set; }
        public CarType type { get; set; }
    }
}
