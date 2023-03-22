using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Car : Vehicle
    {
        //Fixed the string from String class
        public string GetVehicleType()
        {
            return "Car";
        }
              

        public bool IsTollFree()
        {
            // Check if the car then false
            return false;
        }
    }
}