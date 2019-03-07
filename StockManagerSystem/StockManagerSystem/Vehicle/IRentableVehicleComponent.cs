using System;

namespace StockManagerSystem.Vehicle
{
    /// <summary>
    /// Vehicle model attributes to an rental agency.
    /// </summary>
    interface IRentableVehicleComponent 
    {
        /// <summary>
        /// Vehicle Model is available to be rented.
        /// </summary>
        /// <returns>True if the model can be rented.</returns>
        bool CanBeRented();
        /// <summary>
        /// Calculate the discount rate to this model.
        /// </summary>
        /// <returns>A percentage of discount.</returns>
        Double GetDiscountRate();
        /// <summary>
        /// Cost values to perform a rent.
        /// </summary>
        /// <returns>Tuple with final costs and discount price applied.</returns>
        (double costs, double discount) GetCostsAndDiscountToRent();
        /// <summary>
        /// Performs a rent only if this vehicle is available.
        /// </summary>
        /// <returns>True to a rent action, false otherwise</returns>
        bool TryPerformRent();
        /// <summary>
        /// A return occurs if the capacity to this vehicle is not suppressed. 
        /// </summary>
        /// <returns>True if a return action occurs, false otherwise.</returns>
        bool TryReturn();
    }
}
