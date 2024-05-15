using System.Collections.Generic;
using ComputerStore.Services;
using ComputerStore.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/discount")]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountCalculatorService _discountCalculatorService;

        public DiscountController(DiscountCalculatorService discountCalculatorService)
        {
            _discountCalculatorService = discountCalculatorService;
        }

        [HttpPost]
        [Route("calculate")]
        public IActionResult CalculateDiscount([FromBody] List<ProductDTO> basket)
        {
            if (basket == null || basket.Count == 0)
            {
                return BadRequest("Basket cannot be empty.");
            }

            decimal discount = _discountCalculatorService.CalculateDiscount(basket);

            return Ok(new { DiscountAmount = discount });
        }
    }
}
