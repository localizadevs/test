using StockManagerSystem.ConsoleApplicationControl.RentingVehicle;
using StockManagerSystem.ConsoleApplicationControl.ReturningVehicle;
using StockManagerSystem.ConsoleApplicationControl.StockStatus;
using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem.ConsoleApplicationControl
{
    public class InitialSelection : AbstactSelectionCommand

    {

        private const string
            CurrentStatusStockReport = "1",
            RentVehicle = "2",
            ReturnVehicle = "3",
            Exit = "4";

        private readonly StockStatusCommand currentStockStatusCommand;
        private RentingInitialCommand rentingInitialCommand;
        private ReturningInitialCommand returningInitialCommand;
        public InitialSelection(StockController stockController)
        {
            currentStockStatusCommand = new StockStatusCommand(stockController);
            rentingInitialCommand = new RentingInitialCommand(stockController);
            returningInitialCommand = new ReturningInitialCommand(stockController);
        }


        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.DisplayInitialMenu();
        }

        public override bool Selection(string keyPressed, string lastMessage)
        {
            bool repeatSelection = true;
            switch (keyPressed)
            {
                case CurrentStatusStockReport:
                    currentStockStatusCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case RentVehicle:
                    rentingInitialCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case ReturnVehicle:
                    returningInitialCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case Exit:
                    repeatSelection = false;
                    break;
                default:
                    repeatSelection = InvalidSelection(lastMessage);
                    break;
            }
            return repeatSelection;
        }



    }
}
