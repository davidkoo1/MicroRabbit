using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public BankingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> Index()
        {
            var accounts = await _unitOfWork.Accounts.GetAll();

            return Ok(accounts);
        }
    }
}
