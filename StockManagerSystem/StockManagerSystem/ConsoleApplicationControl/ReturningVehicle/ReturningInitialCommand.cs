namespace StockManagerSystem
{
    public class ReturningInitialCommand : AbstactSelectionCommand
    {
        private StockController stockController;
        
        public ReturningInitialCommand(StockController stock)
        {
            stockController = stock;
        }
        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.ReturnMenu(stockController.RentedVehicleModels.GetListRentedNames());
        }

        public override bool Selection(string userInput, string lastMessage)
        {
            bool repeatSelection = false;
            bool inputIsValidVehicle = stockController.RentedVehicleModels.ModelNames.ContainsKey(userInput);

            if (inputIsValidVehicle)
            {
                ReturningAgencySelection returningAgencySelection = new ReturningAgencySelection(stockController, userInput);
                returningAgencySelection.Command();
            }
             else if (IsNotACancelOption(userInput))
            {
                repeatSelection = InvalidSelection(lastMessage);
            }

            return repeatSelection;
        }
    }
}
