using StockManagerSystem.ConsoleApplicationControl.RentingVehicle;

namespace StockManagerSystem
{
    public class RentingInitialCommand : AbstactSelectionCommand
    {
        private StockController stockController;        

        public RentingInitialCommand( StockController stock)
        {
            stockController = stock;
            
        }

        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.RentMenuAgenciesSelection(stockController.GetAgencies());
        }

        public override bool Selection(string userInput, string lastMessage)
        {
            bool repeatSelection = false;
            bool inputIsValidAgency = stockController.GetStock().ContainsAgency(userInput);

            if (inputIsValidAgency)
            {
                RentingVehicleSelection rentingVehicleSelection = new RentingVehicleSelection(this, stockController, userInput);
                rentingVehicleSelection.Command();                
            }
            else if (IsNotACancelOption(userInput))
            {
                repeatSelection = InvalidSelection(lastMessage);
            }

            return repeatSelection;
        }
    }
}
