using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service.Interfaces;

namespace BCGDV.Service
{
    /**
     * Billing service to generate bills with discount applied
     */
    public class BillingService : IBillingService
    {
        private IDiscountService discountService;

        public BillingService(IDiscountService discountService)
        {
            this.discountService = discountService;

        }

        /**
         * Gets the final bill value
         */
        public double getBillingValue(Cart cart)
        {
            return (getPrice(cart) - getDiscountValue(cart));
        }

        /**
         * Gets the cart price without discount 
         */
        private double getPrice(Cart cart)
        {
            double cartValue=0;
            List<IProduct> productsInCart = cart.getItems();

            foreach( IProduct product in productsInCart)
            {
                cartValue += cart.getQuantity(product) * product.getUnitPrice();
            }
            return cartValue;
        }


        /**
         * Gets the discount price for a cart
         */
        private double getDiscountValue(Cart cart)
        {
            return discountService.getDiscountPrice(cart);
        }
    }
}

