using System;

namespace StockManagerSystem
{
    public enum ExpectedAttributes
    {
        agencia = 0,
        carro,
        capacidade,
        quantidade,
        tarifapadrao
    }

    public class CSVStockParser : AbstractCSVParser
    {
        private IStockRepository stockRepository;
        private readonly int attributesQuantity;


        public CSVStockParser(IStockRepository respository)
        {
            stockRepository = respository;
            attributesQuantity = Enum.GetValues(typeof(ExpectedAttributes)).Length;
            LoadInitialAttributesPositions();
        }

        protected override void LoadInitialAttributesPositions()
        {
            int position;
            foreach (ExpectedAttributes attribute in Enum.GetValues(typeof(ExpectedAttributes)))
            {
                position = (int)attribute;
                AttributesPosition.Add((int)attribute, position);
            }
        }

        /// <summary>
        /// Load Attribute as Keys and their position as values.
        /// </summary>
        /// <param name="headerLine">First line of the CSV file.</param>
        public override void LoadAttributesPositions(string headerLine)
        {
            int position = 0;
            int totalAttributesParsed = 0;
            foreach (string attribute in headerLine.Split(";"))
            {
                if (TryConvertToExpectedAttributesEnum(attribute, out ExpectedAttributes attributeEnum))
                {
                    AttributesPosition[(int)attributeEnum] = position;
                    totalAttributesParsed++;
                }
                position++;

            }
            if (MissingAttributes(totalAttributesParsed))
            {
                throw new Exception("CSV Parser found a problem: Missing attributes. Please Check the input file.");
            }
        }

        private bool TryConvertToExpectedAttributesEnum(string attribute, out ExpectedAttributes attributeEnum)
        {
            return Enum.TryParse(attribute, true, out attributeEnum);
        }

        private bool MissingAttributes(int totalAttributesParsed)
        {
            return totalAttributesParsed != this.AttributesPosition.Count;
        }

        public override void LoadContentDataByPosition(string contentLine)
        {
            string[] values = contentLine.Split(";");
            if (values.Length >= attributesQuantity)
            {
                Agency agency = stockRepository.TryInsertAgency(values[GetExpectedAttributePosition(ExpectedAttributes.agencia)]);
                VehicleModel vehicleModel = agency.TryAddModel(values[GetExpectedAttributePosition(ExpectedAttributes.carro)]);
                vehicleModel.Capacity = int.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.capacidade)]);
                vehicleModel.Available = int.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.quantidade)]);
                vehicleModel.DefaultPrice = Double.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.tarifapadrao)]);
            }
        }

        public int GetExpectedAttributePosition(ExpectedAttributes attribute)
        {
            return AttributesPosition[(int)attribute];
        }

    }
}
