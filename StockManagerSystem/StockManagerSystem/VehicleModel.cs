using System;

namespace StockManagerSystem
{
    public class VehicleModel : IRentableVehicle
    {
        public string Name { get; set; }
        public int Capacity { get;  set; }
        public int Available { get;  set; }
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
            return this.Available > 0;
        }

        public double DiscountRate()
        {

            if (this.Available == 1)
                return 0.0;

            return 10 * this.Available / this.Capacity;
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