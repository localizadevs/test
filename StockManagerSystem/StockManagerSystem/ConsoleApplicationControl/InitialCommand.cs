namespace StockManagerSystem
{
    public class InitialSelection : AbstactSelectionCommand

    {
        private StockStatusCommand currentStockStatusCommand;
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
                case "1":
                    currentStockStatusCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case "2":
                    rentingInitialCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case "3":
                    returningInitialCommand.Command();
                    ViewDisplayBuilder.DisplayInitialMenu();
                    break;
                case "4":
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
