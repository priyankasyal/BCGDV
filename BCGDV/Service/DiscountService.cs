using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;
using BCGDV.Service.Interfaces;

namespace BCGDV.Service
{
    /**
     * Discount service calculates the cart discount given a list of offers for the cart
     */
    public class DiscountService : IDiscountService
    {

        private IOfferService offerService;

        public DiscountService(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        /**
         * get Discount for a cart
         */
        public double getDiscountPrice(Cart cart)
        {
            CartDiscount offerDiscount = new CartDiscount(this.offerService.getCurrentOffers());
            return offerDiscount.calculateDiscount(cart);

        }
    }
}

