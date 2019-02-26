using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    public interface IStockRepository
    {

        int CountAgencies();

        int GetAgencyIndex(string name);

        Agency TryInsertAgency(string name);

               
    }
}
