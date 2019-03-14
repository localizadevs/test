using System;

namespace StockManagerSystem.Stock_Elements
{
    public enum ExpectedAttributes
    {
        Agencia = 0,
        Carro,
        Capacidade,
        Quantidade,
        Tarifapadrao
    }
    public static class CsvStockCommon
    {
        public static bool TryConvertToExpectedAttributesEnum(string attribute, out ExpectedAttributes attributeEnum)
        {
            return Enum.TryParse(attribute, true, out attributeEnum);
        }
    }
}
