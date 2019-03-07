using System;
using System.Collections.Generic;
using System.Data;
using ConsoleTableExt;
using StockManagerSystem.Vehicle;

namespace StockManagerSystem.ConsoleApplicationControl
{
    /// <summary>
    /// Builder to produce the user interface in the console.
    /// </summary>
    public static class ViewDisplayBuilder
    {
        /// <summary>
        /// Clears last console line to be used again.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor - 1);
        }

        /// <summary>
        /// First screen to the user.
        /// </summary>
        /// <returns>The last message in the console.</returns>
        public static string DisplayInitialMenu()
        {
            string finalMessage = "Please, select an ID: ";
            Console.Clear();
            BuildTitleMenu("Stock Management System");
            ConsoleTableBuilder
               .From(ContentInitialMenu())
               .ExportAndWriteLine();
            Console.WriteLine(new string('*', 10));
            Console.Write(finalMessage);
            return finalMessage;
        }
        /// <summary>
        /// Provides a common console title
        /// </summary>
        /// <param name="title">Title to be presented in the console.</param>
        private static void BuildTitleMenu(string title)
        {
            int windowWidthRest = Console.WindowWidth % 2;
            int emptySpace = (Console.WindowWidth - windowWidthRest - title.Length - 2) / 2;

            Console.WriteLine(new string('*', Console.WindowWidth));
            Console.WriteLine($"*{new string(' ', emptySpace)}{title.ToUpper()}{new string(' ', emptySpace)}{new string('*', 1 + windowWidthRest)}");
            Console.WriteLine(new string('*', Console.WindowWidth));
        }

        /// <summary>
        /// The initial table of option to user interaction.
        /// </summary>
        /// <returns>DataTable with default user's option </returns>
        private static DataTable ContentInitialMenu()
        {
            DataTable content = new DataTable();
            content.Columns.Add("ID", typeof(string));
            content.Columns.Add("Option", typeof(string));

            content.Rows.Add("1", "Show current stock`s agencies ");
            content.Rows.Add("2", "Rent a Car");
            content.Rows.Add("3", "Return a Car");
            content.Rows.Add("4", "Exit");

            return content;
        }
        /// <summary>
        /// Screen to display rental stock data.
        /// </summary>
        /// <param name="agencies">Collection of agencies to be displayed</param>
        /// <returns>Last message used in the console.</returns>
        public static string DisplayCurrentStock(List<Agency.Agency> agencies)
        {
            string finalMessage = "Return to last menu (y): ";

            Console.Clear();
            BuildTitleMenu("Current Stock");
            ConsoleTableBuilder
               .From(GetContentCurrentStockByAgencies(agencies))
               .ExportAndWriteLine();
            Console.WriteLine(new string('*', 10));
            Console.Write(finalMessage);

            return finalMessage;
        }
        /// <summary>
        /// Build an rental stock data table.
        /// </summary>
        /// <param name="agencies">Collection of agencies to build data table</param>
        /// <returns>DataTable with the content of current stock.</returns>
        private static DataTable GetContentCurrentStockByAgencies(List<Agency.Agency> agencies)
        {
            DataTable currentStockContent = new DataTable();

            currentStockContent.Columns.Add("Agency", typeof(string));
            currentStockContent.Columns.Add("Vehicle Model", typeof(string));
            currentStockContent.Columns.Add("Capacity", typeof(int));
            currentStockContent.Columns.Add("Available", typeof(int));
            currentStockContent.Columns.Add("Default Price", typeof(double));
            foreach (Agency.Agency agency in agencies)
            {
                foreach (VehicleModel vehicle in agency.Fleet)
                {
                    DataRow rowInstance = currentStockContent.NewRow();
                    rowInstance["Agency"] = agency.Name;
                    rowInstance["Vehicle Model"] = vehicle.Name;
                    rowInstance["Capacity"] = vehicle.Capacity;
                    rowInstance["Available"] = vehicle.Available;
                    rowInstance["Default Price"] = vehicle.DefaultPrice;
                    currentStockContent.Rows.Add(rowInstance);
                }
            }

            return currentStockContent;
        }
    

        /// <summary>
        /// Display a menu to select agency with the proper title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="finalMessage"></param>
        /// <param name="agencies"></param>
        /// <returns></returns>
        public static string AgencyMenuSelection(string title, String finalMessage, List<Agency.Agency> agencies)
        {
            Console.Clear();
            BuildTitleMenu(title);
            ConsoleTableBuilder
               .From(GetAgencyNames(agencies))
               .ExportAndWriteLine();
            Console.WriteLine(new string('*', 10));
            Console.Write(finalMessage);
            return finalMessage;
        }
        /// <summary>
        /// Gets the names of agencies.
        /// </summary>
        /// <param name="agencies">Collection of Agency</param>
        /// <returns>Datatable with agencies name reduced</returns>
        private static DataTable GetAgencyNames(List<Agency.Agency> agencies)
        {
            DataTable agencyNames = new DataTable();

            agencyNames.Columns.Add("Agency", typeof(string));
            foreach (Agency.Agency agency in agencies)
            {
                DataRow rowInstance = agencyNames.NewRow();
                rowInstance["Agency"] = agency.Name;
                agencyNames.Rows.Add(rowInstance);

            }

            return agencyNames;
        }
        /// <summary>
        /// Displays the vehicles in the agency.
        /// </summary>
        /// <param name="agencyToRent">Name of the agency to be exhibit.</param>
        /// <param name="fleet">Vehicles from the agency</param>
        /// <returns>Last message used in the console.</returns>
        public static string RentMenuVehicleSelection(string agencyToRent, List<VehicleModel> fleet)
        {
            string finalMessage = "Rent Which Vehicle Model (c to Cancel)? ";
            Console.Clear();
            BuildTitleMenu($"({agencyToRent}) Rent Menu -> Vehicles Selection");

            ConsoleTableBuilder
               .From(GetFleetContentToRent(fleet))
               .ExportAndWriteLine();
            Console.WriteLine(new string('*', 10));
            Console.Write(finalMessage);
            return finalMessage;
        }
        /// <summary>
        /// Gets the content to be exhibit in the rent menu.
        /// </summary>
        /// <param name="fleet">Vehicles from the agency</param>
        /// <returns>Data table of the fleet.</returns>
        private static DataTable GetFleetContentToRent(List<VehicleModel> fleet)
        {
            DataTable fleetToRent = new DataTable();

            fleetToRent.Columns.Add("Vehicle Model", typeof(string));
            fleetToRent.Columns.Add("Default Price", typeof(double));


            foreach (VehicleModel vehicle in fleet)
            {
                DataRow rowInstance = fleetToRent.NewRow();
                rowInstance["Vehicle Model"] = vehicle.Name;
                rowInstance["Default Price"] = vehicle.DefaultPrice;

                fleetToRent.Rows.Add(rowInstance);

            }

            return fleetToRent;
        }
        /// <summary>
        /// Displays costs's data of the rent 
        /// </summary>
        /// <param name="vehicleName">Name of the model to be rent</param>
        /// <param name="rentCosts">The costs's values to display in the console.</param>
        /// <returns>last Message used in the console</returns>
        public static string FinalRentMenuDisplay(string vehicleName, (double costs, double discount) rentCosts)
        {
            string finalMessage = "Are you sure (y/n)? ";
            BuildTitleMenu(" ==> Renting " + vehicleName);

            Console.WriteLine($" Discount Rate: {rentCosts.discount:0.##} %");
            Console.WriteLine(new String('-', 10));
            Console.WriteLine($"     Final Price: $ {rentCosts.costs:0.####}");
            Console.Write(finalMessage);

            return finalMessage;
        }
        /// <summary>
        /// Congrulations screen to be exhibit after a sucessful rent.
        /// </summary>
        /// <param name="vehicleName">Name of the vehicle</param>
        public static void CongratulationsRentMenuDisplay(string vehicleName)
        {
            string finalMessage = "Press any key... ";

            Console.Clear();

            BuildTitleMenu($"Congratulations on -> Renting {vehicleName}");
            Console.WriteLine();
            Console.Write(finalMessage);

        }
        /// <summary>
        /// Display a selection menu to a return of rented vehicles.
        /// </summary>
        /// <param name="rentedVehicleModelNames">List of rented vehicles.</param>
        /// <returns>Last message used in console</returns>
        public static string ReturnMenu(List<string> rentedVehicleModelNames)
        {
            string finalMessage;
            Console.Clear();

            BuildTitleMenu("Returning Vehicle Menu -> Agency Selection");
            if (rentedVehicleModelNames.Count > 0)
            {
                finalMessage = "Return Which Vehicle Model (c to Cancel)? ";

                ConsoleTableBuilder
                    .From(GetContentVehiclesToReturn(rentedVehicleModelNames))
                    .ExportAndWriteLine();
            }
            else
            {
                finalMessage = "No rented vehicle to return. Press c to Cancel... ";

            }

            Console.Write(finalMessage);

            return finalMessage;
        }
        /// <summary>
        /// Get the names of rented vehicles.
        /// </summary>
        /// <param name="rentedVehicleModelNames">List of vehicles names.</param>
        /// <returns>Data table to be displayed in console</returns>
        private static DataTable GetContentVehiclesToReturn(List<string> rentedVehicleModelNames)
        {
            DataTable fleetToReturn = new DataTable();

            fleetToReturn.Columns.Add("Vehicle Model", typeof(string));

            foreach (string vehicle in rentedVehicleModelNames)
            {
                DataRow rowInstance = fleetToReturn.NewRow();
                rowInstance["Vehicle Model"] = vehicle;
                fleetToReturn.Rows.Add(rowInstance);
            }

            return fleetToReturn;
        }
        
        /// <summary>
        /// Displays a congratulations message when returns is sucessful.
        /// </summary>
        /// <param name="agency">Name of the agency to be exhibit.</param>
        /// <param name="vehicleName">Name of the vehicle to exhibit</param>
        public static void CongratulationsReturnMenuDisplay(string agency, string vehicleName)
        {
            Console.Clear();

            string finalMessage = "Press any key... ";
            BuildTitleMenu($"The {vehicleName} has been returned to {agency}!");
            Console.WriteLine();
            Console.Write(finalMessage);

        }
    }
}