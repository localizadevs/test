using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class AgencyTest
    {
        [Test]
        public void Agency_LoadFleet_CheckCount()
        {
            Agency bhAngecy = new Agency("bh");
            bhAngecy.TryAddModel("chevrolet fusca");

            int sizeOfFleet = bhAngecy.Fleet.Count;

            Assert.AreEqual(1, sizeOfFleet);
        }


        [Test]
        public void Agency_GetVehicle_Exists()
        {
            Agency bhAngecy = new Agency("bh");
            bhAngecy.TryAddModel("chevrolet fusca");

            VehicleModel fusca = bhAngecy.GetVehicle("chevrolet fusca");

            Assert.AreEqual(fusca.Name, "chevrolet fusca");
        }

        [Test]
        public void Agency_GetVehicle_NotExists()
        {
            Agency bhAngecy = new Agency("bh");            

            Exception error = Assert.Throws<Exception>(() => bhAngecy.GetVehicle("chevrolet fusca"));

            Assert.That(error.Message, Is.EqualTo("Vehicle Model Not Found"));
        }

    }
}
