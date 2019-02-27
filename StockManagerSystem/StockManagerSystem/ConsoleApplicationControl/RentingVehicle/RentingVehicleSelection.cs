namespace StockManagerSystem.ConsoleApplicationControl.RentingVehicle
{
    public class RentingVehicleSelection : AbstactSelectionCommand
    {
        private RentingInitialCommand rentingInitial;
        private StockController stockController;
        private readonly string agencyToRent;

        public RentingVehicleSelection(RentingInitialCommand rentingInitialCommand, StockController stock, string agencySelected)
        {
            rentingInitial = rentingInitialCommand;
            stockController = stock;
            agencyToRent = agencySelected;
        }

        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.
                RentMenuVehicleSelection(agencyToRent, stockController.GetStock().GetAgency(agencyToRent).Fleet);
        }

        public override bool Selection(string userInput, string lastMessage)
        {
            bool repeatSelection = false;
            bool inputIsValidVehicle = stockController.GetStock().GetAgency(agencyToRent).ContainsVehicle(userInput);

            if (inputIsValidVehicle)
            {
                RentingPriceConfirmation priceCommand = new RentingPriceConfirmation(this, stockController, agencyToRent, userInput);
                priceCommand.Command();                
            }
            else if (userInput.Equals("c", System.StringComparison.OrdinalIgnoreCase))
            {
                rentingInitial.Command();
            }
            else
            {
                repeatSelection = InvalidSelection(lastMessage);
            }

            return repeatSelection;
        }
    }
}
