using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public interface Vehicle
    {
        //This interface will have two methods that all the Vehicle classes should implement
        string GetVehicleType();
        bool IsTollFree();
    }
}