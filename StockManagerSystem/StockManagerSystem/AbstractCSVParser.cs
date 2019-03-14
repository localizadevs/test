using System.IO;

namespace StockManagerSystem
{
    /// <summary>
    /// Aims a design logic to CSV PARSERS.
    /// </summary>
    public abstract class AbstractCsvParser
    {
        protected const string DELIMITER = ";";
        /// <summary>
        /// Gather the position information from the header line.
        /// </summary>
        public abstract void LoadAttributesPositions(string headerLine);
        /// <summary>
        /// Load each attribute data by each position from the content line.
        /// </summary>
        public abstract void LoadAttributeDataByPosition(string contentLine);
        /// <summary>
        /// Parse a csv file and extracts its data.
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void ReadFile(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string actualLine = sr.ReadLine();
                LoadAttributesPositions(actualLine);
                while ((actualLine = sr.ReadLine()) != null)
                {
                    LoadAttributeDataByPosition(actualLine);
                }
            }
        }
    }
}
