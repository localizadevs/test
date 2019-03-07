using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using StockManagerSystem.ConsoleApplicationControl;
using StockManagerSystem.Stock_Elements;

namespace StockManagerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new Exception("Missing file with initial stock data");

            string fileName = args[0];

            StockController stockController = new StockController(fileName);
            InitialSelection consoleCommand = new InitialSelection(stockController);
            consoleCommand.Command();

            

        }

       
    }
}
