using System;

namespace StockManagerSystem.Vehicle
{
    public class VehicleModel : IRentableVehicleComponent
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Available { get; set; }
        public Double DefaultPrice { get; set; }

        public VehicleModel()
        {

        }

        public VehicleModel(string name)
        {
            Name = name;
        }

        public double GetDiscountRate()
        {

            if (Available == 1)
                return 0.0;

            return 10 * Available / Capacity;
        }

        public (double costs, double discount) GetCostsAndDiscountToRent()
        {
            return (GetFinalPrice(), GetDiscountRate());
        }

        public double GetFinalPrice()
        {
            return DefaultPrice * (1 - (GetDiscountRate() / 100));
        }

        public bool TryPerformRent()
        {
            if (CanBeRented())
            {
                Available--;
                return true;
            }
            return false;
        }

        public bool CanBeRented()
        {
            return Available > 0;
        }

        public bool TryReturn()
        {
            if (CanBeReturned())
            {
                Available++;
                return true;
            }
            return false;
        }

        public bool CanBeReturned()
        {
            return Available + 1 <= Capacity;
        }

    }
}