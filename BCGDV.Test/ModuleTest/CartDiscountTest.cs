using System;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;
using BCGDV.Service;
using Moq;

namespace BCGDV.Test.ModuleTest
{
    public class CartDiscountTest
    {
        private MockData mockData;
        private CartDiscount cartDiscount;
        public CartDiscountTest()
        {
            mockData = new MockData();
            cartDiscount = new CartDiscount(mockData.offers);
        }

        [Fact]
        public void TestCartDiscountWithBothOffers()
        {
            double discount = cartDiscount.calculateDiscount(mockData.cartWithRolexAndMichealKorsWatches);
            Assert.Equal(discount, mockData.offer1.discountPrice + mockData.offer2.discountPrice);

        }

        [Fact]
        public void TestCartDiscountWithOffer1()
        {
            double discount = cartDiscount.calculateDiscount(mockData.cartWithRolexWatches);
            Assert.Equal(discount, mockData.offer1.discountPrice);

        }

        [Fact]
        public void TestCartDiscountWithOffer2()
        {
            double discount = cartDiscount.calculateDiscount(mockData.cartWithMichealKorsWatches);
            Assert.Equal(discount, mockData.offer2.discountPrice);

        }

        [Fact]
        public void TestCartDiscountWithNoOffer()
        {
            double discount = cartDiscount.calculateDiscount(mockData.cartWithoutOfferWatches);
            Assert.Equal(discount, 0);

        }

        [Fact]
        public void TestCartDiscountWithInsufficienQuantity()
        {
            double discount = cartDiscount.calculateDiscount(mockData.cartWithWatchesLessThanMinimumQuantity);
            Assert.Equal(discount, 0);

        }
    }
}

