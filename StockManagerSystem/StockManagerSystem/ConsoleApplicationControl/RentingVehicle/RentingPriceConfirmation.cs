using System;

namespace StockManagerSystem.ConsoleApplicationControl.RentingVehicle
{
    class RentingPriceConfirmation : AbstactSelectionCommand
    {
        private RentingVehicleSelection rentingVehicleSelection;
        private StockController stockController;
        private readonly string agencyToRent;
        private readonly string vehicleToRent;

        public RentingPriceConfirmation(RentingVehicleSelection rentingVehicleSelectionCommand, StockController stock,
            string agencySelected, string vehicleSelected)
        {
            rentingVehicleSelection = rentingVehicleSelectionCommand;
            stockController = stock;
            agencyToRent = agencySelected;
            vehicleToRent = vehicleSelected;
        }

        public override string DisplayCommand()
        {
            VehicleModel vehicleVisualition = stockController.GetStock().GetAgency(agencyToRent).GetVehicle(vehicleToRent);
            (double costs, double discount) rentCosts = vehicleVisualition.GetCostsAndDiscountToRent();
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
                        rentingVehicleSelection.Command();
                    }
                    break;
                case "N":
                case "n":
                    rentingVehicleSelection.Command();
                    break;
                default:
                    repeatSelection = InvalidSelection(lastMessage);
                    break;
            }

            return repeatSelection;
        }
    }
}
