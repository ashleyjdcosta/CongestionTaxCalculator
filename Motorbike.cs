using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Motorbike : Vehicle
    {
        //Fixed to object string instead of String class
        public string GetVehicleType()
        {
            return "motorbike";
        }

        //Since MotorBIke is always toll-free in GothenBurg, The IsTollFree method returns true
        public bool IsTollFree()
        {
            return true;
        }
    }
}