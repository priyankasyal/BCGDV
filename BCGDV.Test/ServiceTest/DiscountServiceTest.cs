using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;
using BCGDV.Service;
using BCGDV.Service.Interfaces;
using Moq;

namespace BCGDV.Test.ServiceTest
{
    public class DiscountServiceTest
    {
        private DiscountService discountService;
        private MockData mockData;

        public DiscountServiceTest()
        {

            mockData = new MockData();
            var offerService = new Mock<IOfferService>();
            offerService.Setup(service => service.getCurrentOffers())
            .Returns(mockData.offers);
            discountService = new DiscountService(offerService.Object);
        }

        [Fact]
        public void TestDiscountWithNoOfferCart()
        {
            double discount = discountService.getDiscountPrice(mockData.cartWithoutOfferWatches);
            Assert.Equal(discount, 0);
        }


        [Fact]
        public void TestDiscountWithOffer1Cart()
        {
            double discount = discountService.getDiscountPrice(mockData.cartWithRolexWatches);
            Assert.Equal(discount, mockData.offer1.discountPrice);
        }


        [Fact]
        public void TestDiscountWithNoOffer2Cart()
        {
            double discount = discountService.getDiscountPrice(mockData.cartWithMichealKorsWatches);
            Assert.Equal(discount, mockData.offer2.discountPrice);
        }


        [Fact]
        public void TestDiscountWithBothOfferCart()
        {
            double discount = discountService.getDiscountPrice(mockData.cartWithRolexAndMichealKorsWatches);
            Assert.Equal(discount, mockData.offer2.discountPrice + mockData.offer1.discountPrice);
        }


        [Fact]
        public void TestDiscountWithEmptyCart()
        {
            double discount = discountService.getDiscountPrice(new Cart());
            Assert.Equal(discount, 0);
        }
    }
}

