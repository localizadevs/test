namespace StockManagerSystem
{
    /// <summary>
    /// Represents an renting vehicle model Agency and provides operation on its fleet.
    /// </summary>
    interface IAgencyComposite
    {
        /// <summary>
        /// Name of this Agency.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Add a new vehicle by its name if it did not exist.
        /// </summary>
        /// <param name="modelName">Vehicle Model Name.</param>
        /// <returns>The instance of Vehicle Model created.</returns>
        VehicleModel TryAddVehicle(string modelName);
        /// <summary>
        /// Performs a rent by the vehicle name.
        /// </summary>
        /// <param name="modelName">The vehicle model name.</param>
        /// <returns>True when the process has occurred, False otherwise</returns>
        bool TryRentVehicle(string modelName);
        /// <summary>
        /// Get a VehicleModel instance from the fleet in this agency. 
        /// </summary>
        /// <param name="modelName">Model Name to look for</param>
        /// <returns>An instance of vehicle model found.</returns>
        VehicleModel GetVehicle(string modelName);

    }
}
