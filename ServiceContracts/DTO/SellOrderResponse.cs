using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid SellOrderID { get; set; }

        [Required]
        public string? StockSymbol { get; set; }

        [Required]
        public string? StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000)]
        public uint Quantity { get; set; }

        [Range(1, 10000)]
        public double Price { get; set; }

        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(SellOrderResponse)) return false;

            SellOrderResponse sellOrder_to_compare = obj as SellOrderResponse;
            return
                 this.SellOrderID == sellOrder_to_compare.SellOrderID
                 && this.StockSymbol == sellOrder_to_compare.StockSymbol
                 && this.StockName == sellOrder_to_compare.StockName
                && this.Price == sellOrder_to_compare.Price
                 && this.DateAndTimeOfOrder == sellOrder_to_compare.DateAndTimeOfOrder
                 && this.Quantity == sellOrder_to_compare.Quantity;


        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class SellOrderExtensions
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                SellOrderID = sellOrder.SellOrderID,
                StockSymbol = sellOrder.StockName,
                Price = sellOrder.Price,
                DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
                Quantity = sellOrder.Quantity,
                TradeAmount = sellOrder.Price * sellOrder.Quantity
            };
        }
    }
}
