using System;
using System.Collections.Generic;
using StockManagerSystem.Vehicle;

namespace StockManagerSystem.Agency
{
    /// <summary>
    /// Renting vehicle model Agency
    /// </summary>
    public class Agency : IAgencyComposite
    {

        public string Name { get; set; }
        public List<VehicleModel> Fleet { get; } = new List<VehicleModel>();

        public Agency(string name)
        {
            Name = name;
        }


        public VehicleModel TryAddVehicle(string modelName)
        {
            
            int index = GetVehicleIndex(modelName);
            if (index >= 0)
            {
                return Fleet[index];
            }

            VehicleModel modelToAdd = new VehicleModel(modelName);
            Fleet.Add(modelToAdd);

            return modelToAdd;
        }

        public void AddVehicle(VehicleModel modelToAdd)
        {

            Fleet.Add(modelToAdd);
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

        public bool ContainsVehicle(string name)
        {
            return GetVehicleIndex(name) >= 0;
        }

        public bool TryRentVehicle(string modelName)
        {
            VehicleModel vehicle = GetVehicle(modelName);
            return vehicle.TryPerformRent();
        }

        public VehicleModel GetVehicle(string modelName)
        {
            int vehicleIndex = GetVehicleIndex(modelName);
            if (vehicleIndex == -1)
            {
                throw new Exception("Vehicle Model Not Found");
            }
            return Fleet[vehicleIndex];
        }

        public bool TryReturnVehicle(string modelName)
        {
            VehicleModel vehicle = GetVehicle(modelName);
            return vehicle.TryReturn();
        }

        public List<string> GetReturnableVehicles()
        {
            List<string> returnableNamedVehicles = new List<string>();
            for (int i = 0; i < Fleet.Count; i++)
            {
                if (Fleet[i].CanBeReturned())
                {
                    returnableNamedVehicles.Add(Fleet[i].Name);
                }
            }
            return returnableNamedVehicles;
        }

        public List<string> GetRentableVehicles()
        {
            List<string> rentableNamedVehicles = new List<string>();
            for (int i = 0; i < Fleet.Count; i++)
            {
                if (Fleet[i].CanBeRented())
                {
                    rentableNamedVehicles.Add(Fleet[i].Name);
                }
            }
            return rentableNamedVehicles;
        }

        
    }
}