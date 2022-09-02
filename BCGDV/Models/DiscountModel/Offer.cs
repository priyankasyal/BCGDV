using System;
namespace BCGDV.Product.DiscountModel
{
    /**
    * Offer Class that represents the discounted price for specific quantity of product
    */
    public class Offer
    {
        public IProduct product { get; }
        public int discountQuantity { get; }
        public double discountPrice { get; }

        public Offer(IProduct product, int discountQuantity, double discountPrice)
        {
            this.product = product;
            this.discountPrice = discountPrice;
            this.discountQuantity = discountQuantity;
        }
    }
}

