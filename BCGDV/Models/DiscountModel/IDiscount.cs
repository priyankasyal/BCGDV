using System;
using BCGDV.Models;

namespace BCGDV.Product.DiscountModel
{
    /**
    * Abstract class for offer handler chain to calculate cart discount 
    */
    public abstract class IDiscount
    {
        protected IDiscount? successor;

        public void SetSuccessor(IDiscount successor)
        {
            this.successor = successor;
        }
        public abstract double calculateDiscount(Cart cart, double discountValueTillNow);
    }
}

