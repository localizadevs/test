using StockManagerSystem.Stock_Elements;
using StockManagerSystem.Vehicle;
using System;
using System.Data.SqlTypes;

namespace StockManagerSystem.ConsoleApplicationControl.RentingVehicle
{
    internal class RentingPriceConfirmation : AbstactSelectionCommand
    {
        private readonly StockController stockController;
        private string agencyToRent;
        private string vehicleToRent;

        public bool PriceRefused { get; set; }


        public RentingPriceConfirmation(StockController stock, string agency, string vehicleSelected)
        {
            stockController = stock;
            agencyToRent = agency;
            vehicleToRent = vehicleSelected;
            PriceRefused = false;
        }

        public override string DisplayCommand()
        {
            VehicleModel vehicleVisualization = stockController.GetStock().GetAgency(agencyToRent).GetVehicle(vehicleToRent);
            (double costs, double discount) rentCosts = vehicleVisualization.GetCostsAndDiscountToRent();
            return ViewDisplayBuilder.FinalRentMenuDisplay(vehicleToRent, rentCosts);
        }

        public override bool Selection(string keyPressed, string lastMessage)
        {
            bool repeatSelection = false;

            switch (keyPressed)
            {
                case "Y":
                case "y":
                    bool rentingOccured = stockController.RentVehicle(agencyToRent, vehicleToRent);
                    if (rentingOccured)
                    {
                        ViewDisplayBuilder.CongratulationsRentMenuDisplay(vehicleToRent);
                        Console.ReadLine();
                    }
                    else
                    {
                        ViewDisplayBuilder.ClearCurrentConsoleLine();
                        Console.WriteLine();
                        Console.WriteLine("Sorry. You almost rent it. This vehicle is no longer available. ");
                        Console.ReadLine();
                        PriceRefused = true;
                    }
                    break;
                case "N":
                case "n":
                    PriceRefused = true;
                    break;
                default:
                    repeatSelection = InvalidSelection(lastMessage);
                    break;
            }

            return repeatSelection;
        }
    }
}
