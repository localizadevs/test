using System;
using System.Collections.Generic;

namespace StockManagerSystem
{
    public class Agency : IAgencyRepository
    {
        public string Name { get; set; }
        private List<VehicleModel> Fleet { get; set; } = new List<VehicleModel>();

        public Agency(string name)
        {
            this.Name = name;
        }

        public VehicleModel TryAddModel(string modelName)
        {
            int index = GetVehicleIndex(modelName);
            if (index >= 0)
            {
                return Fleet[index];
            }

            VehicleModel modelToAdd = new VehicleModel(modelName);
            this.Fleet.Add(modelToAdd);
            return modelToAdd;
        }

        public int GetVehicleIndex(string name)
        {
            for (int i = 0; i < Fleet.Count; i++)
            {
                if (Fleet[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}