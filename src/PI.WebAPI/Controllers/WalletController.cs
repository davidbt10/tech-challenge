using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI.Application.Interfaces;
using PI.Application.Models.Responses;

namespace PI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        [Authorize]
        [Route("wallet/{userid}")]
        public async Task<ActionResult<WalletSummaryResponse>> GetWalletSummaryByUserId(int userid)
        {
            var response = await _walletService.GetWalletSummaryByUserId(userid);
            return Ok(response.Stocks);
        }
    }
}
