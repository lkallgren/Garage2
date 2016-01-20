﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
 
namespace Garage2.Models
{
    public enum VType { Car, MC, Boat, Plane, SpaceShip }
    
    public class Vehicle
    {
        
        public int Id { get; set; }

        [Required]
        public VType Type { get; set; }

        [StringLength(10,MinimumLength=4)]
        [Required]
        public string RegNr { get; set; }

        public string Brand { get; set; }
        public string ProdName { get; set; }

        [Required]
        public string Color { get; set; }
        public int Wheels { get; set; }
        public DateTime? CheckInTime { get; set; }
    }
}