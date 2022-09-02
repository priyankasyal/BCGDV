using System;
using BCGDV.Models;

namespace BCGDV.Product.DiscountModel
{
    /**
    * Implementation of the abstract class of offer handler chain to implement discount calculation
    * for generating cart discount
    */
    public class Discount : IDiscount
    {
        private Offer offer;

        public Discount(Offer offer)
        {
            this.offer = offer;
        }

        public override double calculateDiscount(Cart cart, double discountValueTillNow)
        {
            if (cart.getQuantity(offer.product) >= offer.discountQuantity)
            {
                int quantity = cart.getQuantity(offer.product);
                double discount = (quantity / offer.discountQuantity) * offer.discountPrice;
                discountValueTillNow = discountValueTillNow + discount;
            }
            if (successor != null)
            {
                return successor.calculateDiscount(cart, discountValueTillNow);
            }
            else return discountValueTillNow;
        }
    }
}

