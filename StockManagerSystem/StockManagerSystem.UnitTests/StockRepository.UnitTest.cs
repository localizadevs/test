using NUnit.Framework;
using System;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class StockRepositoryTest
    {

        [Test]
        public void StockRepository_LoadAgency_CheckCount()
        {
            StockRepository stock = new StockRepository();

            stock.TryInsertAgency("bh");
            int @count = stock.CountAgencies();

            Assert.AreEqual(1, @count);

        }


        [Test]
        public void StockRepository_LoadAgency_CheckAgency()
        {
            StockRepository stock = new StockRepository();

            Agency agency = stock.TryInsertAgency("bh");
 
            Assert.AreEqual("bh", agency.Name);

        }


        [Test]
        public void StockRepository_LoadAgency_CheckAgencyUnicity()
        {
            StockRepository stock = new StockRepository();

            stock.TryInsertAgency("bh");
            stock.TryInsertAgency("bh");


            Assert.AreEqual(1, stock.CountAgencies());

        }

        [Test]
        public void StockRepository_LoadAgency_CheckUnicityCaseSensitive()
        {
            StockRepository stock = new StockRepository();

            stock.TryInsertAgency("bh");
            stock.TryInsertAgency("BH");


            Assert.AreEqual(1, stock.CountAgencies());

        }

        [Test]
        public void StockRepository_GetAgency_Exists()
        {
            StockRepository stock = new StockRepository();
            Agency expectedAgency = new Agency("bh");
            stock.TryInsertAgency("bh");

            Agency bhAgency = stock.GetAgency("bh");

            Assert.AreEqual(expectedAgency.Name, bhAgency.Name);

        }


        [Test]
        public void StockRepository_GetAgency_NotExists()
        {
            StockRepository stock = new StockRepository();                   

            Exception error = Assert.Throws<Exception>(() => stock.GetAgency("bh"));

            Assert.That(error.Message, Is.EqualTo("Agency Not Found"));

           
        }



    }
}