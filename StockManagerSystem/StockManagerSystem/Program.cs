using System;

namespace StockManagerSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileContentData2 = ($"BH;BMW 320i;10;3;100{Environment.NewLine}" +
                        $"BH;VOLVO XC60;5;0;120{Environment.NewLine}" +
                        $"BH;AUDI A3;15;5;90{Environment.NewLine}" +
                        $"SP;BMW 320i;20;4;90{Environment.NewLine}" +
                        $"SP;VOLVO XC60;10;9;110{Environment.NewLine}" +
                        $"SP;AUDI A3;20;5;80{Environment.NewLine}").Split(Environment.NewLine);

            Console.WriteLine("Hello World!");
        }
    }
}
