using System;

namespace StockManagerSystem
{
    public class ReturningAgencySelection : AbstactSelectionCommand
    {
        private StockController stockController;
        private readonly string vehicleToReturn;
        public ReturningAgencySelection(StockController stock, string vehicle)
        {
            stockController = stock;
            vehicleToReturn = vehicle;
        }
        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.ReturnAgencyMenu(vehicleToReturn, stockController.GetAgencies());
        }

        public override bool Selection(string userInput, string lastMessage)
        {
            bool repeatSelection = false;
            bool inputIsValidAgency = stockController.GetStock().ContainsAgency(userInput);

            if (inputIsValidAgency)
            {
                bool hasReturned = stockController.ReturnVehicle(userInput, vehicleToReturn);
                if (hasReturned)
                {
                    ViewDisplayBuilder.CongratulationsReturnMenuDisplay(userInput, vehicleToReturn);
                    Console.ReadLine();
                }
                else
                {
                    ViewDisplayBuilder.ClearCurrentConsoleLine();
                    Console.Write($"The agency {userInput} selected can not receive this vehicle at this moment! {lastMessage}");
                    repeatSelection = true;
                }
            }            
            else if (IsNotACancelOption(userInput))
            {
                repeatSelection = InvalidSelection(lastMessage);
            }

            return repeatSelection;
        }
    }
}
