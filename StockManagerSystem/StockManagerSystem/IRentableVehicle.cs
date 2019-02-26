using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    interface IRentableVehicle
    {        
        bool MayRentVehicle();
        Double GetDiscountRate();
        (double costs, double discount) GetCostsAndDiscountToRent();
        bool RentVehicle();
        bool ReturnVehicle();
    }
}
