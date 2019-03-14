using StockManagerSystem.Vehicle;
using System;
using System.Collections.Generic;

namespace StockManagerSystem.Stock_Elements
{



    public class CsvStockParser : AbstractCsvParser
    {
        public Dictionary<int, int> ExpectedAttributesPosition { get; set; } = new Dictionary<int, int>();


        private StockComposite stock;
        private readonly int attributesQuantity;


        public CsvStockParser(StockComposite stockComposite)
        {
            stock = stockComposite;
            attributesQuantity = Enum.GetValues(typeof(ExpectedAttributes)).Length;
            LoadInitialAttributesPositions();
        }

        protected void LoadInitialAttributesPositions()
        {
            foreach (ExpectedAttributes attribute in Enum.GetValues(typeof(ExpectedAttributes)))
            {
                int position = (int)attribute;
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
            foreach (string attribute in headerLine.Split(DELIMITER))
            {
                if (CsvStockCommon.TryConvertToExpectedAttributesEnum(attribute, out ExpectedAttributes attributeEnum))
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



        private bool MissingAttributes(int totalAttributesParsed)
        {
            return totalAttributesParsed != ExpectedAttributesPosition.Count;
        }

        public override void LoadAttributeDataByPosition(string contentLine)
        {
            string[] values = contentLine.Split(DELIMITER);

            if (values.Length < attributesQuantity) return;

            string agencyName = values[ExpectedAttributesPosition[(int)ExpectedAttributes.Agencia]];
            Agency.Agency agency = stock.TryInsertAgency(agencyName);
            string vehicleName = values[ExpectedAttributesPosition[(int)ExpectedAttributes.Carro]];
            VehicleModel vehicleModel = agency.TryAddVehicle(vehicleName);
            vehicleModel.Capacity = int.Parse(values[ExpectedAttributesPosition[(int)ExpectedAttributes.Capacidade]]);
            vehicleModel.Available = int.Parse(values[ExpectedAttributesPosition[(int)ExpectedAttributes.Quantidade]]);
            vehicleModel.DefaultPrice = Double.Parse(values[ExpectedAttributesPosition[(int)ExpectedAttributes.Tarifapadrao]]);
        }


        public StockComposite GetStock()
        {
            return stock;
        }
    }



    
}
