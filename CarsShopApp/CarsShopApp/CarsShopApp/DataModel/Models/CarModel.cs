using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShopApp.DataModel.Models
{
    public class CarModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public CarMark mark { get; set; }
    }
}
