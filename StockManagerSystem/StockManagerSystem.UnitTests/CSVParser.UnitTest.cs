using NUnit.Framework;
using System;
using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class CsvParserTest
    {
        private const string DefaultHeader = "agencia;carro;capacidade;quantidade;tarifapadrao";
        private string[] fileContentData;
        [OneTimeSetUp]
        public void LoadFileContent()
        {
            fileContentData = ($"BH;BMW 320i;10;3;100{Environment.NewLine}" +
                            $"BH;VOLVO XC60;5;0;120{Environment.NewLine}" +
                            $"BH;AUDI A3;15;5;90{Environment.NewLine}" +
                            $"SP;BMW 320i;20;4;90{Environment.NewLine}" +
                            $"SP;VOLVO XC60;10;9;110{Environment.NewLine}" +
                            $"SP;AUDI A3;20;5;80{Environment.NewLine}").Split(Environment.NewLine);
        }

        [Test]
        public void CSVParser_ReadHeader_CheckReader()
        {
            CsvStockParser csvParser = new CsvStockParser(null);
            string[] expectedHeader = DefaultHeader.Split(";");
            csvParser.LoadAttributesPositions(DefaultHeader);

            int capacidadePosition = csvParser.ExpectedAttributesPosition[(int) ExpectedAttributes.Capacidade];

            Assert.AreEqual(2, capacidadePosition);

        }

        [Test]
        public void CSVParser_ReadHeader_OmitInvalidHeaders()
        {
            CsvStockParser csvParser = new CsvStockParser(null);
            string fakeHeader = "agencia;dummy;carro;capacidade;quantidade;tarifapadrao";
            csvParser.LoadAttributesPositions(fakeHeader);

            int capacidadePosition = csvParser.ExpectedAttributesPosition[(int) ExpectedAttributes.Capacidade];

            Assert.AreEqual(3, capacidadePosition);
        }

        [Test]
        public void CSVParser_ReadHeader_MissingHeaders()
        {
            CsvStockParser csvParser = new CsvStockParser(null);
            string fakeHeader = "agencia;capacidade;quantidade;tarifapadrao";

            Exception ex = Assert.Throws<Exception>(() => csvParser.LoadAttributesPositions(fakeHeader));

            Assert.That(ex.Message, Is.EqualTo("CSV Parser found a problem: Missing attributes. Please Check the input file."));

        }

        [Test]
        public void CSVParser_ReadHeader_CheckQuantityRead()
        {
            CsvStockParser csvParser = new CsvStockParser(null);
            string[] expectedHeader = (DefaultHeader + ";").Split(";");

            csvParser.LoadAttributesPositions(DefaultHeader);

            Assert.AreEqual(5, csvParser.ExpectedAttributesPosition.Count);

        }

        [Test]
        public void CSVParser_ReadContent_CheckAgencies()
        {
            StockComposite stockRepository = new StockComposite();
            CsvStockParser csvParser = new CsvStockParser(stockRepository);
            csvParser.LoadAttributesPositions(DefaultHeader);

            foreach (string line in fileContentData)
                csvParser.LoadAttributeDataByPosition(line);

            Assert.AreEqual(2, stockRepository.CountAgencies());

        }

        [Test]
        public void CSVParser_ReadContent_WithoutHeader()
        {
            StockComposite stockRepository = new StockComposite();
            CsvStockParser csvParser = new CsvStockParser(stockRepository);

            foreach (string line in fileContentData)
                csvParser.LoadAttributeDataByPosition(line);

            Assert.AreEqual(2, stockRepository.CountAgencies());

        }



    }
}