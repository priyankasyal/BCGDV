using System;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;
using BCGDV.Service;

namespace BCGDV.Test.ServiceTest
{
    public class OfferServiceTest
    {
        private OfferService offerService;
        private int offerCount;
        private MockData mockData;

        public OfferServiceTest()
        {
            this.offerService = new OfferService();
            mockData = new MockData();
            offerCount = mockData.offers.Count;
        }

        [Fact]
        public void TestgetCurrentOffers()
        {
            List<Offer> offers = offerService.getCurrentOffers();
            Assert.Equal(offers.Count, 2);
            Assert.Collection(offers, item => Assert.Equal(item.product, mockData.offer1.product),
                              item => Assert.Equal(item.product, mockData.offer2.product));
          
        }

    }
}

