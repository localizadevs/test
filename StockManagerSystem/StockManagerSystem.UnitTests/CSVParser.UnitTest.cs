using NUnit.Framework;
using System;

namespace StockManagerSystem.UnitTests
{
    [TestFixture]
    public class CSVParserTest
    {
        private const string DEFAULT_HEADER = "agencia;carro;capacidade;quantidade;tarifapadrao";
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
            CSVStockParser csvParser = new CSVStockParser(null);
            string[] expectedHeader = DEFAULT_HEADER.Split(";");
            csvParser.LoadAttributesPositions(DEFAULT_HEADER);

            int capacidadePosition = csvParser.GetExpectedAttributePosition(ExpectedAttributes.capacidade);

            Assert.AreEqual(2, capacidadePosition);

        }

        [Test]
        public void CSVParser_ReadHeader_OmitInvalidHeaders()
        {
            CSVStockParser csvParser = new CSVStockParser(null);
            string fakeHeader = "agencia;dummy;carro;capacidade;quantidade;tarifapadrao";
            csvParser.LoadAttributesPositions(fakeHeader);

            int capacidadePosition = csvParser.GetExpectedAttributePosition(ExpectedAttributes.capacidade);

            Assert.AreEqual(3, capacidadePosition);
        }

        [Test]
        public void CSVParser_ReadHeader_MissingHeaders()
        {
            CSVStockParser csvParser = new CSVStockParser(null);
            string fakeHeader = "agencia;capacidade;quantidade;tarifapadrao";

            Exception ex = Assert.Throws<Exception>(() => csvParser.LoadAttributesPositions(fakeHeader));

            Assert.That(ex.Message, Is.EqualTo("CSV Parser found a problem: Missing attributes. Please Check the input file."));

        }

        [Test]
        public void CSVParser_ReadHeader_CheckQuantityRead()
        {
            CSVStockParser csvParser = new CSVStockParser(null);
            string[] expectedHeader = (DEFAULT_HEADER + ";").Split(";");

            csvParser.LoadAttributesPositions(DEFAULT_HEADER);

            Assert.AreEqual(5, csvParser.AttributesPosition.Count);

        }

        [Test]
        public void CSVParser_ReadContent_CheckAgencies()
        {
            IStockRepository stockRepository = new StockRepository();
            CSVStockParser csvParser = new CSVStockParser(stockRepository);
            csvParser.LoadAttributesPositions(DEFAULT_HEADER);

            foreach (string line in fileContentData)
                csvParser.LoadContentDataByPosition(line);

            Assert.AreEqual(2, stockRepository.CountAgencies());

        }

        [Test]
        public void CSVParser_ReadContent_WithoutHeader()
        {
            IStockRepository stockRepository = new StockRepository();
            CSVStockParser csvParser = new CSVStockParser(stockRepository);

            foreach (string line in fileContentData)
                csvParser.LoadContentDataByPosition(line);

            Assert.AreEqual(2, stockRepository.CountAgencies());

        }



    }
}