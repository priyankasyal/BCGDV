using System;
using BCGDV.Product.DiscountModel;

namespace BCGDV.Service.Interfaces
{
     /*
     * Interface for Offer Service
     */
    public interface IOfferService
    {
        public List<Offer> getCurrentOffers();
    }
}

