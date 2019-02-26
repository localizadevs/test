using NUnit.Framework;
using System;

namespace StockManagerSystem.UnitTest
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

            csvParser.LoadHeaderWithPositions(DEFAULT_HEADER);
            
            Assert.Contains("agencia", csvParser.Header.Keys) ;
            Assert.Contains("carro", csvParser.Header.Keys);
            Assert.Contains("capacidade", csvParser.Header.Keys);
            Assert.Contains("tarifapadrao", csvParser.Header.Keys);

        }

        [Test]
        public void CSVParser_ReadHeader_OmitInvalidHeaders()
        {
            CSVStockParser csvParser = new CSVStockParser(null);
            string[] expectedHeader = "agencia;fake;capacidade;quantidade;tarifapadrao".Split(";"); 

            csvParser.LoadHeaderWithPositions(DEFAULT_HEADER);

            Assert.Contains("agencia", csvParser.Header.Keys);
            Assert.Contains("capacidade", csvParser.Header.Keys);
            Assert.Contains("tarifapadrao", csvParser.Header.Keys);
            Assert.AreEqual(2, csvParser.Header["capacidade"]);


        }

        [Test]
        public void CSVParser_ReadHeader_CheckQuantityRead()
        {
            CSVStockParser csvParser = new CSVStockParser(null);
            string[] expectedHeader = (DEFAULT_HEADER + ";").Split(";");

            csvParser.LoadHeaderWithPositions(DEFAULT_HEADER);

            Assert.AreEqual(5, csvParser.Header.Count);

        }

        [Test]
        public void CSVParser_ReadContent_CheckAgencies()
        {
            IStockRepository stockRepository = new StockRepository();

            CSVStockParser csvParser = new CSVStockParser(stockRepository);
            csvParser.LoadHeaderWithPositions(DEFAULT_HEADER);

            foreach (string line in fileContentData)
                csvParser.LoadContentData(line);

            Assert.AreEqual(2, stockRepository.CountAgencies());

        }



    }
}