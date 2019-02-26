using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    public interface IStockRepository
    {

        int CountAgencies();

        Agency GetAgency(string name);

        Agency TryInsertAgency(string name);

               
    }
}
