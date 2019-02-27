namespace StockManagerSystem
{
    class StockStatusCommand : AbstactSelectionCommand
    {
        private StockController stockController;
        public StockStatusCommand(StockController stock)
        {
            stockController = stock;
        }
        public override string DisplayCommand()
        {
            return ViewDisplayBuilder.DisplayCurrentStock(stockController.GetAgencies());
        }

        public override bool Selection(string keyPressed, string lastMessage)
        {
            bool repeatSelection = false;

            switch (keyPressed)
            {
                case "Y":
                case "y":
                    break;
                default:
                    repeatSelection = InvalidSelection(lastMessage);
                    break;
            }
            return repeatSelection;
        }
    }
}
