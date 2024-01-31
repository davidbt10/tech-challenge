using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;

namespace PI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Authorize]
        [Route("stock/")]
        public ActionResult<GetAllAssetsResponse> GetAllStocks()
        {
            return Ok(_stockService.GetAllAssets());
        }

        [HttpPost]
        [Authorize]
        public ActionResult<BuyStockResponse> BuyStock([FromBody] BuyStockRequest request)
        {
            return Ok(_stockService.BuyStock(request));
        }
    }
}
