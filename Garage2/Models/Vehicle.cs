using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace Garage2.Models
{
    public enum VType { Car, MC, Boat, Plane, SpaceShip }

    public class Vehicle
    {
        public int Id { get; set; }
        public VType Type { get; set; }
        public string RegNr { get; set; }
        public string Brand { get; set; }
        public string ProdName { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public DateTime? CheckInTime { get; set; }

    }
}