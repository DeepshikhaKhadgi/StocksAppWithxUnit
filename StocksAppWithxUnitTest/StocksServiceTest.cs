using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace StocksAppWithxUnitTest
{
    public class StocksServiceTest
    {
        private readonly IStocksService _stocksService;
        public StocksServiceTest()
        {
            _stocksService = new StocksService();
        }

        #region CreateBuyOrder
        [Fact]
        public void CreateBuyOrder_RequestIsNull()
        {
            //Arrange
            BuyOrderRequest request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            //Act
            _stocksService.CreateBuyOrder(request)
            );

        }

        [Fact]

        public void CreateBuyOrder_QuantityIsO_ArgumentException()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 0,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(request));

        }

        [Fact]
        public void CreateBuyOrder_QuantityIs1000O1_ArgumentException()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 100001,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(request));

        }

        [Fact]

        public void CreateBuyOrder_OrderPriceIsO_ArgumentException()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 0,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(request));

        }

        [Fact]
        public void CreateBuyOrder_OrderPriceIs100O1_ArgumentException()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 10001,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(request));

        }

        [Fact]
        public void CreateBuyOrder_DateandTimeofOrder19991231_ArgumentException()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 1,
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateBuyOrder(request));

        }

        [Fact]
        public void CreateBuyOrder_ValidData_ToBeSuccessful()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"), Price = 1, Quantity = 1 };

            //Act
            BuyOrderResponse buyOrderResponseFromCreate = _stocksService.CreateBuyOrder(buyOrderRequest);

            //Assert
            Assert.NotEqual(Guid.Empty, buyOrderResponseFromCreate.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder
        public void CreateSellOrder_RequestIsNull()
        {
            //Arrange
            SellOrderRequest request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            //Act
            _stocksService.CreateSellOrder(request)
            );

        }

        [Fact]

        public void CreateSellOrder_QuantityIsO_ArgumentException()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 0,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(request));

        }

        [Fact]
        public void CreateSellOrder_QuantityIs1000O1_ArgumentException()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 100001,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(request));

        }

        [Fact]

        public void CreateSellOrder_OrderPriceIsO_ArgumentException()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 0,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(request));

        }

        [Fact]
        public void CreateSellOrder_OrderPriceIs100O1_ArgumentException()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 10001,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(request));

        }

        [Fact]
        public void CreateSellOrder_DateandTimeofOrder19991231_ArgumentException()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 1,
                DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"),
            };

            Assert.Throws<ArgumentException>(() => _stocksService.CreateSellOrder(request));

        }

        [Fact]
        public void CreateSellOrder_ValidData_ToBeSuccessful()
        {
            //Arrange
            SellOrderRequest? sellOrderRequest = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"), Price = 1, Quantity = 1 };

            //Act
            SellOrderResponse sellOrderResponseFromCreate = _stocksService.CreateSellOrder(sellOrderRequest);

            //Assert
            Assert.NotEqual(Guid.Empty, sellOrderResponseFromCreate.SellOrderID);
        }
        #endregion

        #region GetAllBuyOrders
        [Fact]
        public void GetAllBuyOrders_EmptyList()
        {
            //Act
            List<BuyOrderResponse> actual_buy_order_response_list = _stocksService.GetBuyOrders();

            //Assert
            Assert.Empty(actual_buy_order_response_list);
        }

        [Fact]
        public void GetAllBuyOrders_AddFewBuyOrders()
        {
            //Arrange
            List<BuyOrderRequest> actual_buy_order_request_list = new List<BuyOrderRequest>()
            {
                new BuyOrderRequest(){
                 StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
                },
                 new BuyOrderRequest(){
                      StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
                }
            };

            //Act
            List<BuyOrderResponse> buy_order_response_list_from_add = new List<BuyOrderResponse>();

            foreach (var buyOrder in actual_buy_order_request_list)
            {
                buy_order_response_list_from_add.Add(_stocksService.CreateBuyOrder(buyOrder));
            }

            List<BuyOrderResponse> actual_buy_order_response_list = _stocksService.GetBuyOrders();

            //Assert
            foreach (var actuallist in actual_buy_order_response_list)
            {
                Assert.Contains(actuallist, buy_order_response_list_from_add);
            }

        }
        #endregion

        #region GetAllSellOrders
        [Fact]
        public void GetAllSellOrders_EmptyList()
        {
            //Act
            List<SellOrderResponse> actual_buy_order_response_list = _stocksService.GetSellOrders();

            //Assert
            Assert.Empty(actual_buy_order_response_list);
        }

        [Fact]
        public void GetAllSellOrders_AddFewBuyOrders()
        {
            //Arrange
            List<SellOrderRequest> actual_buy_order_request_list = new List<SellOrderRequest>()
            {
                new SellOrderRequest(){
                 StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
                },
                 new SellOrderRequest(){
                      StockName = "Microsoft",
                StockSymbol = "MSFT",
                Quantity = 1,
                Price = 100,
                DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"),
                }
            };

            //Act
            List<SellOrderResponse> buy_order_response_list_from_add = new List<SellOrderResponse>();

            foreach (var buyOrder in actual_buy_order_request_list)
            {
                buy_order_response_list_from_add.Add(_stocksService.CreateSellOrder(buyOrder));
            }

            List<SellOrderResponse> actual_buy_order_response_list = _stocksService.GetSellOrders();

            //Assert
            foreach (var actuallist in actual_buy_order_response_list)
            {
                Assert.Contains(actuallist, buy_order_response_list_from_add);
            }

        }
        #endregion
    }
}