using System;

namespace StockManagerSystem
{
    
    public class CSVStockParser : AbstractCSVParser
    {
        private IStockRepository stockRepository;
        private readonly int attributesQuantity;
        protected enum ExpectedAttributes
        {
            agencia,
            carro,
            capacidade,
            quantidade,
            tarifapadrao
        }

        public CSVStockParser(IStockRepository respository) 
        {
            this.stockRepository = respository;
            this.attributesQuantity = Enum.GetValues(typeof(ExpectedAttributes)).Length;
        }

        /// <summary>
        /// Load Attribute as Keys and their position as values.
        /// </summary>
        /// <param name="headerLine">First line of the CSV file.</param>
        public override void LoadHeaderWithPositions(string headerLine)
        {
            int position = 0;
            foreach( string attribute in headerLine.Split(";"))
            {
                if (IsValidAttribute(attribute))
                {
                    this.Header.Add(attribute.ToLower(), position);
                }
                    position++;

            }
        }

        private bool IsValidAttribute(string attribute)
        {
            return !string.IsNullOrEmpty(attribute) && Enum.IsDefined(typeof(ExpectedAttributes), attribute);
        }

        public override void LoadContentData(string contentLine)
        {
            string[] values = contentLine.Split(";");
            if (values.Length >= attributesQuantity)
            {
                Agency agency = stockRepository.TryInsertAgency(values[this.Header[ExpectedAttributes.agencia.ToString()]]);
                VehicleModel vehicleModel = agency.TryAddModel(values[this.Header[ExpectedAttributes.carro.ToString()]]);
                vehicleModel.Capacity = int.Parse(values[this.Header[ExpectedAttributes.capacidade.ToString()]]);
                vehicleModel.Quantity = int.Parse(values[this.Header[ExpectedAttributes.quantidade.ToString()]]);
                vehicleModel.DefaultPrice = Double.Parse(values[this.Header[ExpectedAttributes.tarifapadrao.ToString()]]);
            }
        }

         

    }
}
