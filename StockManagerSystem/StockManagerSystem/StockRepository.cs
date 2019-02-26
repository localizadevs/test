using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    public class StockRepository : IStockRepository
    {
        private List<Agency> Agencies { get; set; } = new List<Agency>();

        public int CountAgencies()
        {
            return Agencies.Count;
        }

        public Agency TryInsertAgency(string name)
        {

            int index = GetAgencyIndex(name);
            if (index >= 0)
            {
                return Agencies[index];
            }

            Agency agencyToInsert = new Agency(name);
            this.Agencies.Add(agencyToInsert);
            return agencyToInsert;
        }

        public int GetAgencyIndex(string name)
        {            
            for (int i=0; i <Agencies.Count; i++)
            {
                if (Agencies[i].Name.Equals(name,StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}
