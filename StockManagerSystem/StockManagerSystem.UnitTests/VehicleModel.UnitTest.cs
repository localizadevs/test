using NUnit.Framework;

namespace StockManagerSystem.UnitTest
{
    [TestFixture]
    public class VehicleModelTest
    {
        [Test]
        public void VehicleModel_RentableVehicle_RentIsPossible()
        {
            VehicleModel vehicleModel = new VehicleModel{ Name = "fusca", Capacity = 100, Available = 10, DefaultPrice = 10.1 };

            bool isRentable = vehicleModel.MayRentVehicle();

            Assert.IsTrue(isRentable);

        }

        [Test]
        public void VehicleModel_RentableVehicle_RentIsNotPossible()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 10, Available = 0, DefaultPrice = 10.1 };

            bool isRentable = vehicleModel.MayRentVehicle();

            Assert.IsFalse(isRentable);

        }

        [Test]
        public void VehicleModel_DiscountRate_FirstCheck()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 50, Available = 40, DefaultPrice = 10.1 };

            double discountValue = vehicleModel.DiscountRate();

            Assert.AreEqual(8.0, discountValue);

        }

        [Test]
        public void VehicleModel_DiscountRate_SecondCheck()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 40, DefaultPrice = 10.1 };

            double discountValue = vehicleModel.DiscountRate();

            Assert.AreEqual(10.0, discountValue);

        }

        [Test]
        public void VehicleModel_DiscountRate_AbsenceOfDiscount()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 1, DefaultPrice = 10.1 };

            double discountValue = vehicleModel.DiscountRate();

            Assert.AreEqual(0.0, discountValue);

        }
    }
}