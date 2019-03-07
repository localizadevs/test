using System;

namespace StockManagerSystem.ConsoleApplicationControl
{
    /// <summary>
    /// Mechanism to registry the choice of the user and creates a chain of responsability.
    /// </summary>
    public abstract class AbstactSelectionCommand
    {
        protected const string CancelOption = "c";
        

        public void Command()
        {
            string lastMessage = DisplayCommand();
            bool repeatSelection;
            do
            {
                string userInput = Console.ReadLine();
                repeatSelection = Selection(userInput, lastMessage);

            } while (repeatSelection);

        }
        public abstract string DisplayCommand();

        public abstract bool Selection(string userInput, string lastMessage);

        public bool InvalidSelection(string lastMessage)
        {
            ViewDisplayBuilder.ClearCurrentConsoleLine();
            Console.Write("Invalid choice! " + lastMessage);
            return true;
        }

        public virtual bool IsNotACancelOption(string userInput)
        {
            return !(userInput.Equals(CancelOption, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}