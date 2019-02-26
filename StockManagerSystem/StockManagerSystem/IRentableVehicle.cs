using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    interface IRentableVehicle
    {        
        bool MayRentVehicle();
        Double DiscountRate();
        Tuple<Double, Double> CostsToRentVehicle();
        void RentVehicle();
        void ReturnVehicle();
    }
}
