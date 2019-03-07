using System.Data.SqlTypes;
using System.Runtime.Serialization.Formatters;
using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem.ConsoleApplicationControl.RentingVehicle
{
    public class RentingVehicleSelection : AbstactSelectionCommand
    {
        private readonly StockController stockController;
        private readonly string agencyToRent;
        public bool ChangeAgency { get; set; } = false;

        public RentingVehicleSelection( StockController stock, string agencySelected)
        {
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
                RentingPriceConfirmation priceCommand = new RentingPriceConfirmation(stockController, agencyToRent, userInput);
                priceCommand.Command();
                if (priceCommand.PriceRefused)
                {
                    repeatSelection = true;
                    this.DisplayCommand();
                }
            }
            else if (userInput.Equals(CancelOption, System.StringComparison.OrdinalIgnoreCase))
            {
                ChangeAgency = true;
            }
            else
            {
                repeatSelection = InvalidSelection(lastMessage);
            }

            return repeatSelection;
        }

        
    }
}
