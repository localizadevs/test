using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem.ConsoleApplicationControl.RentingVehicle
{
    public class RentingInitialCommand : AbstactSelectionCommand
    {
        private readonly StockController stockController;

        public RentingInitialCommand( StockController stock)
        {
            stockController = stock;
        }

        public override string DisplayCommand()
        {
            const string finalMessage = "Which agency (c to Cancel)? ";
            const string title = "Rent Menu -> Agencies";
            return ViewDisplayBuilder.AgencyMenuSelection(title, finalMessage, stockController.GetAgencies());

        }

        public override bool Selection(string userInput, string lastMessage)
        {
            bool repeatSelection = false;
            bool inputIsValidAgency = stockController.GetStock().ContainsAgency(userInput);

            if (inputIsValidAgency)
            {
                RentingVehicleSelection rentingVehicleSelection = new RentingVehicleSelection(stockController, userInput);

                rentingVehicleSelection.Command();

                if (rentingVehicleSelection.ChangeAgency)
                {
                    this.DisplayCommand();
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
