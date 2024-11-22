using ServiceContracts.DTO;

namespace StocksAppWithxUnit.Models
{
    public class Orders
    {
        public List<BuyOrderResponse> BuyOrders { get; set; }
        public List<SellOrderResponse> SellOrders { get; set; }
    }
}
