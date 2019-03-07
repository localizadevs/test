﻿using NUnit.Framework;
using System;
using StockManagerSystem.Vehicle;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class AgencyTest
    {
        [Test]
        public void Agency_LoadFleet_CheckCount()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            bhAngecy.TryAddVehicle("chevrolet fusca");

            int sizeOfFleet = bhAngecy.Fleet.Count;

            Assert.AreEqual(1, sizeOfFleet);
        }


        [Test]
        public void Agency_GetVehicle_Exists()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            bhAngecy.TryAddVehicle("chevrolet fusca");

            VehicleModel fusca = bhAngecy.GetVehicle("chevrolet fusca");

            Assert.AreEqual(fusca.Name, "chevrolet fusca");
        }


        [Test]
        public void Agency_GetVehicle_NotExists()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");

            Exception error = Assert.Throws<Exception>(() => bhAngecy.GetVehicle("chevrolet fusca"));

            Assert.That(error.Message, Is.EqualTo("Vehicle Model Not Found"));
        }

        [Test]
        public void Agency_ContainsVehicle_OK()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            bhAngecy.TryAddVehicle("chevrolet fusca");

            bool containsElement = bhAngecy.ContainsVehicle("chevrolet fusca");

            Assert.IsTrue(containsElement);
        }

        [Test]
        public void Agency_ContainsVehicle_Absence()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            bhAngecy.TryAddVehicle("chevrolet fusca");

            bool containsElement = bhAngecy.ContainsVehicle("ds fusca");

            Assert.IsFalse(containsElement);
        }

        [Test]
        public void Agency_RentVehicle_RentWorks()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            VehicleModel vehicleModel = bhAngecy.TryAddVehicle("chevrolet fusca");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 10;

            bool performedRent = bhAngecy.TryRentVehicle("chevrolet fusca");

            Assert.IsTrue(performedRent);
        }

        [Test]
        public void Agency_RentVehicle_VehicleAbsent()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");

            Exception error = Assert.Throws<Exception>(() => bhAngecy.TryRentVehicle("chevrolet fusca"));

            Assert.That(error.Message, Is.EqualTo("Vehicle Model Not Found"));
        }

        [Test]
        public void Agency_RentVehicle_ReturnWorks()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            VehicleModel vehicleModel = bhAngecy.TryAddVehicle("chevrolet fusca");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 9;

            bool performedRent = bhAngecy.TryReturnVehicle("chevrolet fusca");

            Assert.IsTrue(performedRent);
        }

        [Test]
        public void Agency_ReturnVehicle_VehicleAbsent()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");

            Exception error = Assert.Throws<Exception>(() => bhAngecy.TryReturnVehicle("chevrolet fusca"));

            Assert.That(error.Message, Is.EqualTo("Vehicle Model Not Found"));
        }

        [Test]
        public void Agency_CanReturn_ListOfRentableVehicles()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            VehicleModel vehicleModel = bhAngecy.TryAddVehicle("chevrolet fusca");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 9;
            vehicleModel = bhAngecy.TryAddVehicle("chevrolet camaro");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 10;

            System.Collections.Generic.List<string> mayRentVehicles = bhAngecy.GetRentableVehicles();


            Assert.AreEqual(2, mayRentVehicles.Count);
            
        }

        [Test]
        public void Agency_CanRent_ListOfReturnableVehicles()
        {
            Agency.Agency bhAngecy = new Agency.Agency("bh");
            VehicleModel vehicleModel = bhAngecy.TryAddVehicle("chevrolet fusca");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 9;
            vehicleModel = bhAngecy.TryAddVehicle("chevrolet camaro");
            vehicleModel.Capacity = 10;
            vehicleModel.Available = 10;


            System.Collections.Generic.List<string> mayReturnVehicles = bhAngecy.GetReturnableVehicles();


            Assert.Contains("chevrolet fusca", mayReturnVehicles);
            Assert.AreEqual(1, mayReturnVehicles.Count);
        }


    }
}
