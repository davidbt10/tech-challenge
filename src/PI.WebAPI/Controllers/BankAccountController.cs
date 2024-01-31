using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI.Application.Interfaces;
using PI.Application.Models.Requests;
using PI.Application.Models.Responses;

namespace PI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateUserRes>> CashDeposit(CashDepositRequest user)
        {
            await _bankAccountService.CashDeposit(user);
            return Ok();
        }
    }
}
