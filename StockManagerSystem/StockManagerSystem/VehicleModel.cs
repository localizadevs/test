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

        public double GetDiscountRate()
        {

            if (this.Available == 1)
                return 0.0;

            return 10 * this.Available / this.Capacity;
        }

        public (double costs, double discount) GetCostsAndDiscountToRent()
        {
            return (this.GetFinalPrice(), this.GetDiscountRate());
        }

        public double GetFinalPrice()
        {
            return this.DefaultPrice * (1 - (this.GetDiscountRate() / 100));
        }

        public bool RentVehicle()
        {
            if (this.MayRentVehicle())
            {
                this.Available--;
                return true;
            }
            return false;
        }

        public bool ReturnVehicle()
        {
            if (this.MayReturn())
            {
                this.Available++;
                return true;
            }
            return false;
        }

        private bool MayReturn()
        {
            return this.Available + 1 <= this.Capacity;
        }

    }
}