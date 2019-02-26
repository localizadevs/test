using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    class UnitOfWork
    {
        StockRepository stockRepository;
        

        public UnitOfWork(string fileName)
        {
            stockRepository = new StockRepository();
            this.LoadData(fileName);
        }

        private void LoadData(string fileName)
        {
            CSVStockParser csvStockParser = new CSVStockParser(stockRepository);

            csvStockParser.ReadFile(fileName);
        }



    }
}
