using NUnit.Framework;
using System;
using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class StockCompositeTest
    {

        [Test]
        public void StockComposite_LoadAgency_CheckCount()
        {
            StockComposite stock = new StockComposite();

            stock.TryInsertAgency("bh");
            int @count = stock.CountAgencies();

            Assert.AreEqual(1, @count);
        }
       
        [Test]
        public void StockComposite_LoadAgency_Contains()
        {
            StockComposite stock = new StockComposite();

            stock.TryInsertAgency("bh");
            bool containsAgency = stock.ContainsAgency("bh");

            Assert.IsTrue(containsAgency);
        }
        [Test]
        public void StockComposite_ContainsAgency_Absence()
        {
            StockComposite stock = new StockComposite();

            stock.TryInsertAgency("bh");
            bool containsAgency = stock.ContainsAgency("bhx");

            Assert.IsFalse(containsAgency);
        }


        [Test]
        public void StockComposite_LoadAgency_CheckAgencyUnicity()
        {
            StockComposite stock = new StockComposite();

            stock.TryInsertAgency("bh");
            stock.TryInsertAgency("bh");


            Assert.AreEqual(1, stock.CountAgencies());

        }

        [Test]
        public void StockComposite_LoadAgency_CheckUnicityCaseSensitive()
        {
            StockComposite stock = new StockComposite();

            stock.TryInsertAgency("bh");
            stock.TryInsertAgency("BH");


            Assert.AreEqual(1, stock.CountAgencies());

        }

        [Test]
        public void StockComposite_GetAgency_Exists()
        {
            StockComposite stock = new StockComposite();
            Agency.Agency expectedAgency = new Agency.Agency("bh");
            stock.TryInsertAgency("bh");

            Agency.Agency bhAgency = stock.GetAgency("bh");

            Assert.AreEqual(expectedAgency.Name, bhAgency.Name);

        }


        [Test]
        public void StockComposite_GetAgency_NotExists()
        {
            StockComposite stock = new StockComposite();                   

            Exception error = Assert.Throws<Exception>(() => stock.GetAgency("bh"));

            Assert.That(error.Message, Is.EqualTo("Agency Not Found"));
           
        }



    }
}