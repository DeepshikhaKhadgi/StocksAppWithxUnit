using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;

namespace StocksAppWithxUnit.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public HomeController(IFinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubService = finnhubService;
            _tradingOptions = tradingOptions;
        }
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }
            Dictionary<string, object>? responseDictionary = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            return View();
        }
    }
}
