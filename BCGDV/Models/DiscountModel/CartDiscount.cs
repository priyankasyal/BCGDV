using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using BCGDV.Models;

namespace BCGDV.Product.DiscountModel
{
    /**
    * Constructor of the offer handler chain to generate cart discount with the offers provided 
    */
    public class CartDiscount
    {
        private IDiscount? discount;

        public CartDiscount(List<Offer> offers)
        {
            foreach (Offer offer in offers)
            {
                IDiscount newDiscount = new Discount(offer);
                if (this.discount is not null)
                {
                    discount.SetSuccessor(newDiscount);
                }
                else discount = newDiscount;

            }
        }

        public double calculateDiscount(Cart cart)
        {
            if (discount is not null)
                return discount.calculateDiscount(cart,0);
            else return 0;
        }
    }
}

