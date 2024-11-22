using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class BuyOrderResponse
    {
        public Guid BuyOrderID { get; set; }

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
            if (obj.GetType() != typeof(BuyOrderResponse)) return false;

            BuyOrderResponse buyOrder_to_compare = obj as BuyOrderResponse;
            return
                 this.BuyOrderID == buyOrder_to_compare.BuyOrderID
                 && this.StockSymbol == buyOrder_to_compare.StockSymbol
                 && this.StockName == buyOrder_to_compare.StockName
                && this.Price == buyOrder_to_compare.Price
                 && this.DateAndTimeOfOrder == buyOrder_to_compare.DateAndTimeOfOrder
                 && this.Quantity == buyOrder_to_compare.Quantity;


        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public static class BuyOrderExtensions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse()
            {
                BuyOrderID = buyOrder.BuyOrderID,
                StockSymbol = buyOrder.StockSymbol,
                StockName = buyOrder.StockName,
                Price = buyOrder.Price,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                TradeAmount = buyOrder.Price * buyOrder.Quantity
            };
        }
    }
}
