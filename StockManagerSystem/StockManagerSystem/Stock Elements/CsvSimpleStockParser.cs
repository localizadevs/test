using StockManagerSystem.Vehicle;
using System;

namespace StockManagerSystem.Stock_Elements
{
    public class CsvSimpleStockParser : AbstractCsvParser
    {
        private StockComposite stock;
        private readonly int attributesQuantity;

        public CsvSimpleStockParser(StockComposite stockComposite)
        {
            stock = stockComposite;
            attributesQuantity = Enum.GetValues(typeof(ExpectedAttributes)).Length;
        }

        public override void LoadAttributesPositions(string headerLine)
        {
            int position = 0;
            int totalAttributesParsed = 0;
            foreach (string attribute in headerLine.Split(DELIMITER))
            {
                if (CsvStockCommon.TryConvertToExpectedAttributesEnum(attribute, out ExpectedAttributes attributeEnum))
                {
                    totalAttributesParsed++;
                    if (position != (int)attributeEnum)
                    {
                        throw new Exception("CSV Parser found a problem: Missing attributes. Please Check the input file.");
                    }
                }

                position++;
            }
            if (attributesQuantity != totalAttributesParsed)
            {
                throw new Exception("CSV Parser found a problem: Missing attributes. Please Check the input file.");
            }
        }

        public override void LoadAttributeDataByPosition(string contentLine)
        {
            string[] values = contentLine.Split(DELIMITER);

            if (values.Length < attributesQuantity) return;

            string agencyName = values[(int)ExpectedAttributes.Agencia];
            Agency.Agency agency = stock.TryInsertAgency(agencyName);
            string vehicleName = values[(int)ExpectedAttributes.Carro];
            VehicleModel vehicleModel = agency.TryAddVehicle(vehicleName);
            vehicleModel.Capacity = int.Parse(values[(int)ExpectedAttributes.Capacidade]);
            vehicleModel.Available = int.Parse(values[(int)ExpectedAttributes.Quantidade]);
            vehicleModel.DefaultPrice = Double.Parse(values[(int)ExpectedAttributes.Tarifapadrao]);
        }


    }
}
