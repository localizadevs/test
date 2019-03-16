using System;
using System.Collections.Generic;
using System.Dynamic;

namespace StockManagerSystem.Stock_Elements
{
    public class StockComposite : IStockComposite
    {
        public List<Agency.Agency> Agencies { get; private set; } = new List<Agency.Agency>();

        public int CountAgencies()
        {
            return Agencies.Count;
        }

        public Agency.Agency TryInsertAgency(string name)
        {

            int index = GetAgencyIndex(name);
            if (index >= 0)
            {
                return Agencies[index];
            }

            Agency.Agency agencyToInsert = new Agency.Agency(name);
            Agencies.Add(agencyToInsert);
            return agencyToInsert;
        }


        public int GetAgencyIndex(string name)
        {
            for (int i = 0; i < Agencies.Count; i++)
            {
                if (Agencies[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        public bool ContainsAgency(string name)
        {
            return GetAgencyIndex(name) >= 0;
        }

        public Agency.Agency GetAgency(string name)
        {
            int index = GetAgencyIndex(name);
            if (index == -1)
            {
                throw new Exception("Agency Not Found");
            }

            return Agencies[index];
        }
 
    }
}
