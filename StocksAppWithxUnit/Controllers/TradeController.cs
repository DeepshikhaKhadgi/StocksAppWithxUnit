using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using StocksAppWithxUnit.Models;
using System.Security.Cryptography.X509Certificates;

namespace StocksAppWithxUnit.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        private readonly IStocksService _stocksService;
        private readonly IOptions<TradingOptions> _tradingOptions;
        private readonly IConfiguration _configuration;

        public TradeController(IFinnhubService finnhubService, IStocksService stocksService, IOptions<TradingOptions> tradingOptions, IConfiguration configuration)
        {
            _finnhubService = finnhubService;
            _stocksService = stocksService;
            _tradingOptions = tradingOptions;
            _configuration = configuration;

        }
        [Route("Index")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }
            Dictionary<string, object>? getStockPriceDictionary = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            Dictionary<string, object>? getCompanyProfileDictionary = await _finnhubService.GetCompanyProfile(_tradingOptions.Value.DefaultStockSymbol);

            StockTrade stockTradeModel = new StockTrade()
            {
                StockName = getCompanyProfileDictionary["name"].ToString(),
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                Price = Double.Parse(getStockPriceDictionary["c"].ToString()),
                Quantity = _tradingOptions.Value.DefaultOrderQuantity,

            };

            //Send Finnhub token to view
            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            return View(stockTradeModel);
        }

        [Route("Orders")]
        [HttpGet]
        public IActionResult Orders()
        {
            Orders orders = new Orders()
            {
                BuyOrders = _stocksService.GetBuyOrders(),
                SellOrders  = _stocksService.GetSellOrders(),
            };

            return View(orders);
        }

        [Route("SellOrder")]
        [HttpPost]
        public IActionResult SellOrder(StockTrade stockTrade)
        {
            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();
                return View("Index", stockTrade);
            }

            SellOrderRequest request = new SellOrderRequest()
            {
                StockSymbol = stockTrade.StockSymbol,
                StockName = stockTrade.StockName,
                Price = stockTrade.Price,
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = stockTrade.Quantity

            };

            _stocksService.CreateSellOrder(request);
            return RedirectToAction("Index");
        }

        [Route("BuyOrder")]
        [HttpPost]
        public IActionResult BuyOrder(StockTrade stockTrade)
        {
            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();
                return View("Index", stockTrade);
            }

            BuyOrderRequest request = new BuyOrderRequest()
            {
                StockSymbol = stockTrade.StockSymbol,
                StockName = stockTrade.StockName,
                Price = stockTrade.Price,
                DateAndTimeOfOrder = DateTime.Now,
                Quantity = stockTrade.Quantity

            };

            _stocksService.CreateBuyOrder(request);
            return RedirectToAction("Index");
        }
    }
}
