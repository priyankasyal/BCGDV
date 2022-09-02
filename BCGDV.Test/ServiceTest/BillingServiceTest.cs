using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service;
using BCGDV.Service.Interfaces;
using Moq;

namespace BCGDV.Test.ServiceTest
{
    public class BillingServiceTest
    {
        private BillingService billingService;
        private MockData mockData;

        public BillingServiceTest()
        {
            mockData = new MockData();
        }

        [Fact]
        public void TestBillingWithEmptyCart()
        {
            Cart cart = new Cart();
            var discountService = new Mock<IDiscountService>();
            discountService.Setup(service => service.getDiscountPrice(cart))
            .Returns(0);
            billingService = new BillingService(discountService.Object);
            double result = billingService.getBillingValue(new Cart());
            Assert.Equal(result, 0);
        }


        [Fact]
        public void TestBillingWithOffer1Cart()
        {
            var discountService = new Mock<IDiscountService>();
            discountService.Setup(service => service.getDiscountPrice(mockData.cartWithRolexWatches))
            .Returns(mockData.offer1.discountPrice);
            billingService = new BillingService(discountService.Object);
            double result = billingService.getBillingValue(mockData.cartWithRolexWatches);
            Assert.Equal(result, (mockData.rolexWatch.getUnitPrice()*mockData.offer1.discountQuantity) - mockData.offer1.discountPrice);
        }


        [Fact]
        public void TestBillingWithOffer2Cart()
        {
            var discountService = new Mock<IDiscountService>();
            discountService.Setup(service => service.getDiscountPrice(mockData.cartWithMichealKorsWatches))
            .Returns(mockData.offer2.discountPrice);
            billingService = new BillingService(discountService.Object);
            double result = billingService.getBillingValue(mockData.cartWithMichealKorsWatches);
            Assert.Equal(result, (mockData.michealKorsWatch.getUnitPrice() * mockData.offer2.discountQuantity) - mockData.offer2.discountPrice);
        }

        [Fact]
        public void TestBillingWithoutOfferCart()
        {
            var discountService = new Mock<IDiscountService>();
            discountService.Setup(service => service.getDiscountPrice(mockData.cartWithoutOfferWatches))
            .Returns(0);
            billingService = new BillingService(discountService.Object);
            double result = billingService.getBillingValue(mockData.cartWithoutOfferWatches);
            Assert.Equal(result, (mockData.casioWatch.getUnitPrice() + mockData.swatchWatch.getUnitPrice()));
        }

        [Fact]
        public void TestBillingWithBothOfferCart()
        {
            var discountService = new Mock<IDiscountService>();
            discountService.Setup(service => service.getDiscountPrice(mockData.cartWithRolexAndMichealKorsWatches))
            .Returns(mockData.offer1.discountPrice + mockData.offer2.discountPrice);
            billingService = new BillingService(discountService.Object);
            double result = billingService.getBillingValue(mockData.cartWithRolexAndMichealKorsWatches);
            Assert.Equal(result, ((mockData.rolexWatch.getUnitPrice() * mockData.offer1.discountQuantity) +
                (mockData.michealKorsWatch.getUnitPrice() * mockData.offer2.discountQuantity) -
                mockData.offer1.discountPrice - mockData.offer2.discountPrice));
        }

    }
}

