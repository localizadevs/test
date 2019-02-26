using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    interface IAgencyRepository
    {
        VehicleModel TryAddModel(string modelName);
        int GetVehicleIndex(string name);
    }
}
