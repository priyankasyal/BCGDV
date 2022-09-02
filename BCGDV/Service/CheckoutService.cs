using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service.Interfaces;

namespace BCGDV.Service
{
    /**
     * Checkout service is a facade which gets checkout value by creating cart and
     * generating the bill for the cart
     */
    public class CheckoutService : ICheckoutService
    {

        private ICartService cartService;
        private IBillingService billingService;

        public CheckoutService(ICartService cartService, IBillingService billingService)
        {
            this.cartService = cartService;
            this.billingService = billingService;
        }

        /**
         * Gets a checkout value given a list of item Ids 
         * throws an exception if all ids are invalid 
         */
        public double getCheckoutValue(List<string> items)
        {
            try
            {
                Cart cart = cartService.createCart(items);
                return billingService.getBillingValue(cart);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create cart with product Ids", ex);
            }
        }

    }
}

