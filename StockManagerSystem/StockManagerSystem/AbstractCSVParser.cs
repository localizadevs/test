using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagerSystem
{
    public abstract class AbstractCSVParser
    {
        public Dictionary<int, int> AttributesPosition { get; set; } = new Dictionary<int, int>();

        protected abstract void LoadInitialAttributesPositions();

        public abstract void LoadAttributesPositions (string headerLine);

        public abstract void LoadContentDataByPosition(string contentLine);

        public virtual void ReadFile(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string actualLine = sr.ReadLine();
                this.LoadAttributesPositions(actualLine);
                while ((actualLine = sr.ReadLine()) != null)
                {
                    this.LoadContentDataByPosition(actualLine);                    
                }
            }
        }
    }
}
