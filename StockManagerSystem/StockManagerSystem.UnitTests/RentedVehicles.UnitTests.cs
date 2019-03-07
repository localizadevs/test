using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagerSystem.Vehicle;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class RentedVehiclesTest
    {
        [Test]
        public void RentedVehicles_LoadVehicle_CheckCount()
        {
            RentedVehicles rentedVehicles = new RentedVehicles();
            rentedVehicles.AddModelName("chevrolet fusca");

            int total = rentedVehicles.GetTotalRentedByModelName("chevrolet fusca");

            Assert.AreEqual(1, total);
        }

        [Test]
        public void RentedVehicles_LoadVehicle_CheckCountIgnoreCase()
        {
            RentedVehicles rentedVehicles = new RentedVehicles();
            rentedVehicles.AddModelName("chevrolet fusca");
            rentedVehicles.AddModelName("chevrolet FUSCA");


            int total = rentedVehicles.GetTotalRentedByModelName("chevrolet fusca");

            Assert.AreEqual(2, total);
        }

        [Test]
        public void RentedVehicles_ReturnableVehicle_CheckCount()
        {
            RentedVehicles rentedVehicles = new RentedVehicles();
            rentedVehicles.AddModelName("chevrolet fusca");
            rentedVehicles.AddModelName("chevrolet fusca");
            rentedVehicles.ReduceOneByModelName("chevrolet fusca");

            int total = rentedVehicles.GetTotalRentedByModelName("chevrolet fusca");

            Assert.AreEqual(1, total);


        }

        [Test]
        public void RentedVehicles_GetListVehicleNames_CheckCount()
        {
            RentedVehicles rentedVehicles = new RentedVehicles();
            rentedVehicles.AddModelName("chevrolet fusca");

            System.Collections.Generic.List<string> actualOutput = rentedVehicles.GetListRentedNames();

            Assert.AreEqual(1, actualOutput.Count);
            Assert.Contains("chevrolet fusca", actualOutput);


        }
    }
}
