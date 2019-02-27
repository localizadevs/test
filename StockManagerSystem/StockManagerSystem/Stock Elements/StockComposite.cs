using System;
using System.Collections.Generic;

namespace StockManagerSystem
{
    public class StockComposite : IStockComposite
    {
        public List<Agency> Agencies { get; private set; } = new List<Agency>();

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

        public Agency GetAgency(string name)
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
