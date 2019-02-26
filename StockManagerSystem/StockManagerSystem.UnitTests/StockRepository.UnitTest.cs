using NUnit.Framework;
using System;

namespace StockManagerSystem.UnitTest
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


    }
}