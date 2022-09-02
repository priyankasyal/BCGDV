using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service;
using BCGDV.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BCGDV.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {

        private ICheckoutService checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            this.checkoutService = checkoutService;
        }

        /**
         * Controller for Checkout returns the price with discount applied
         * or 400 if the the product Id list is invalid
         * Accepts a list of strings which correspond to productIds
         */
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> PostItem([FromBody] List<string> productIdList)
        {
            try
            {

                double cartValue = checkoutService.getCheckoutValue(productIdList);
                CheckoutDto checkoutDto = new CheckoutDto(cartValue);
                return CreatedAtAction(nameof(PostItem), new { price = cartValue }, checkoutDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

    }
}

