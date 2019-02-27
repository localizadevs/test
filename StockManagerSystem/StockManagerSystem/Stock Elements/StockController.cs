using System.Collections.Generic;

namespace StockManagerSystem
{
    public class StockController
    {
        private StockComposite stockRepository;
        public RentedVehicles RentedVehicleModels { get; private set; } = new RentedVehicles();


        public StockController(string fileName)
        {
            stockRepository = new StockComposite();
            LoadData(fileName);
        }

        private void LoadData(string fileName)
        {
            CSVStockParser csvStockParser = new CSVStockParser(stockRepository);

            csvStockParser.ReadFile(fileName);
        }

        public bool RentVehicle(string agencyName, string modelName)
        {
            Agency agency = stockRepository.GetAgency(agencyName);
            bool isRented = agency.TryRentVehicle(modelName);
            if (isRented)
            {
                RentedVehicleModels.AddModelName(modelName);
            }
            return isRented;
        }

        public bool ReturnVehicle(string agencyName, string modelName)
        {
            Agency agency = stockRepository.GetAgency(agencyName);
            bool hasReturn = agency.TryReturnVehicle(modelName);
            if (hasReturn)
            {
                RentedVehicleModels.ReduceOneByModelName(modelName);
            }
            return hasReturn;
        }

        public List<Agency> GetAgencies()
        {
            return stockRepository.Agencies;
        }

        public StockComposite GetStock()
        {
            return stockRepository;
        }
        
        

    }
}
