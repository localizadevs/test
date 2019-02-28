namespace StockManagerSystem
{
    class StockStatusCommand : AbstactSelectionCommand
    {
        private const string ReturnToInitialScreenOption = "y";
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

            if (InvalidOption(keyPressed) ){ 
                    repeatSelection = InvalidSelection(lastMessage);                 
            }
            return repeatSelection;
        }
        public bool InvalidOption(string keyPressed)
        {
            return !(ReturnToInitialScreenOption.Equals(keyPressed));
        }
    }
}
