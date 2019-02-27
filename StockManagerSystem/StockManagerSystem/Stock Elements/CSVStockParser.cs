using System;
using CommonParsers;

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
        private StockComposite stock;
        private readonly int attributesQuantity;


        public CSVStockParser(StockComposite stockComposite)
        {
            this.stock = stockComposite;
            attributesQuantity = Enum.GetValues(typeof(ExpectedAttributes)).Length;
            LoadInitialAttributesPositions();
        }

        protected override void LoadInitialAttributesPositions()
        {
            int position;
            foreach (ExpectedAttributes attribute in Enum.GetValues(typeof(ExpectedAttributes)))
            {
                position = (int)attribute;
                ExpectedAttributesPosition.Add((int)attribute, position);
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
                    ExpectedAttributesPosition[(int)attributeEnum] = position;
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
            return totalAttributesParsed != this.ExpectedAttributesPosition.Count;
        }

        public override void LoadAttributeDataByPosition(string contentLine)
        {
            string[] values = contentLine.Split(";");
            if (values.Length >= attributesQuantity)
            {
                Agency agency = stock.TryInsertAgency(values[GetExpectedAttributePosition(ExpectedAttributes.agencia)]);
                VehicleModel vehicleModel = agency.TryAddVehicle(values[GetExpectedAttributePosition(ExpectedAttributes.carro)]);
                vehicleModel.Capacity = int.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.capacidade)]);
                vehicleModel.Available = int.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.quantidade)]);
                vehicleModel.DefaultPrice = Double.Parse(values[GetExpectedAttributePosition(ExpectedAttributes.tarifapadrao)]);
            }
        }

        public int GetExpectedAttributePosition(ExpectedAttributes attribute)
        {
            return ExpectedAttributesPosition[(int)attribute];
        }

        public StockComposite GetStock()
        {
            return this.stock;
        }
    }
}
