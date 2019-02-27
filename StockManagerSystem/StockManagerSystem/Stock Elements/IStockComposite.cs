using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagerSystem
{
    /// <summary>
    /// A repository to hold agencies status of stock data.
    /// </summary>
    public interface IStockComposite
    {

        int CountAgencies();
        /// <summary>
        /// Get Agency instance by its name.
        /// </summary>
        /// <param name="name">Name to be searched</param>
        /// <returns>Agency instance.</returns>
        Agency GetAgency(string name);
        /// <summary>
        /// Inserts an agency only if it does not already exists.
        /// </summary>
        /// <param name="name">Name of Agency to be created.</param>
        /// <returns>Agency instance.</returns>
        Agency TryInsertAgency(string name);

               
    }
}
