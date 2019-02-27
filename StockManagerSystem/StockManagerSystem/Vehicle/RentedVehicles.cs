using System;
using System.Collections.Generic;

namespace StockManagerSystem
{
    public class RentedVehicles
    {
        public Dictionary<string, int> ModelNames { get; private set; } = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public void AddModelName(string modelName)
        {
            if (!ModelNames.ContainsKey(modelName))
            {
                ModelNames.Add(modelName, 0);
            }
            ModelNames[modelName]++;
        }

        public int GetTotalRentedByModelName(string modelName)
        {
            if (ModelNames.ContainsKey(modelName))
            {
                return ModelNames[modelName];
            }
            return 0;
        }
        /// <summary>
        /// Reduce One from the amount of rented to the model Name requested.
        /// </summary>
        /// <param name="modelName"></param>
        public void ReduceOneByModelName(string modelName)
        {
            if (ModelNames.ContainsKey(modelName))
            {
                ModelNames[modelName]--;
                if (ModelNames[modelName] <= 0)
                {
                    ModelNames.Remove(modelName);
                }
            }

        }

        public List<string> GetListRentedNames()
        {
            return new List<string>(this.ModelNames.Keys);
        }
    }
}
