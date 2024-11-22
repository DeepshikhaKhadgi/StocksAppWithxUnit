using System.ComponentModel.DataAnnotations;

namespace StocksAppWithxUnit.Models
{
    public class StockTrade
    {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public double Price { get; set; }

        [Range(1, 10000, ErrorMessage = "Quantity should be between {1} and {2}")]
        public uint Quantity { get; set; }
    }
}
