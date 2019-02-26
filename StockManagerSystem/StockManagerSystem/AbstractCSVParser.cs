using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagerSystem
{
    public abstract class AbstractCSVParser
    {
        public Dictionary<string, int> Header { get; set; } = new Dictionary<string, int>();

        public abstract void LoadHeaderWithPositions (string headerLine);

        public abstract void LoadContentData(string contentLine);

        public virtual void ReadFile(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string actualLine = sr.ReadLine();
                this.LoadHeaderWithPositions(actualLine);
                while ((actualLine = sr.ReadLine()) != null)
                {
                    this.LoadContentData(actualLine);                    
                }
            }
        }
    }
}
