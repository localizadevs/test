using NUnit.Framework;
using System;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class VehicleModelTest
    {
        [Test]
        public void VehicleModel_RentableVehicle_RentIsPossible()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 100, Available = 10, DefaultPrice = 10.1 };

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

            double discountValue = vehicleModel.GetDiscountRate();

            Assert.AreEqual(8.0, discountValue);

        }

        [Test]
        public void VehicleModel_DiscountRate_SecondCheck()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 40, DefaultPrice = 10.1 };

            double discountValue = vehicleModel.GetDiscountRate();

            Assert.AreEqual(10.0, discountValue);

        }

        [Test]
        public void VehicleModel_DiscountRate_AbsenceOfDiscount()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 1, DefaultPrice = 10.1 };

            double discountValue = vehicleModel.GetDiscountRate();

            Assert.AreEqual(0.0, discountValue);

        }

        [Test]
        public void VehicleModel_PerformRent_CheckAvailabilityReduction()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 1, DefaultPrice = 10.1 };

            vehicleModel.RentVehicle();

            Assert.AreEqual(0, vehicleModel.Available);

        }
        [Test]
        public void VehicleModel_PerformRent_CanNotRent()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 0, DefaultPrice = 10.1 };

            bool processRented = vehicleModel.RentVehicle();

            Assert.IsFalse(processRented);

        }

        [Test]
        public void VehicleModel_CostToRent_GetValues()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 40, DefaultPrice = 10.1 };
            ValueTuple<double, double> expectedCosts = (9.09, 10.0);

            ValueTuple<double, double> actualCosts = vehicleModel.GetCostsAndDiscountToRent();

            Assert.AreEqual(expectedCosts, actualCosts);

        }

        [Test]
        public void VehicleModel_CostToRent_GetValuesNoDiscount()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 1, DefaultPrice = 10.1 };
            ValueTuple<double, double> expectedCosts = (10.1, 0.0);

            ValueTuple<double, double> actualCosts = vehicleModel.GetCostsAndDiscountToRent();

            Assert.AreEqual(expectedCosts, actualCosts);

        }


        [Test]
        public void VehicleModel_ReturnVehicle_ReturnOk()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 1, DefaultPrice = 10.1 };

            bool hasReturned = vehicleModel.ReturnVehicle();

            Assert.IsTrue(hasReturned);

        }

        [Test]
        public void VehicleModel_ReturnVehicle_ReturnNOk()
        {
            VehicleModel vehicleModel = new VehicleModel { Name = "fusca", Capacity = 40, Available = 40, DefaultPrice = 10.1 };

            bool hasReturned = vehicleModel.ReturnVehicle();

            Assert.IsFalse(hasReturned);

        }


    }
}
