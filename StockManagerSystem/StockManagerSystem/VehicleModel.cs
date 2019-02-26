using System;

namespace StockManagerSystem
{
    public class VehicleModel : IRentableVehicle
    {
        public string Name { get; set; }
        public int Capacity { get;  set; }
        public int Quantity { get;  set; }
        public Double DefaultPrice { get;  set; }

        public VehicleModel()
        {

        }

        public VehicleModel(string name)
        {
            this.Name = name;
        }
        

        public bool MayRentVehicle()
        {
            throw new NotImplementedException();
        }

        public double DiscountRate()
        {
            throw new NotImplementedException();
        }

        public Tuple<double, double> CostsToRentVehicle()
        {
            throw new NotImplementedException();
        }

        public void RentVehicle()
        {
            throw new NotImplementedException();
        }

        public void ReturnVehicle()
        {
            throw new NotImplementedException();
        }
    }
}