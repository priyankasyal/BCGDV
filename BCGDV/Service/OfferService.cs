using System;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;
using BCGDV.Service.Interfaces;

namespace BCGDV.Service
{
    /*
     * Service responsible for getting the list of current offers, can be extended
     * for other functionalities like adding new offers 
     */
    public class OfferService : IOfferService
    {
        private List<Offer> offers; 
        public OfferService()
        {
            this.offers = new List<Offer>();
            offers.Add(new Offer(new RolexWatch(), 3, 100));
            offers.Add(new Offer(new MichealKorsWatch(), 2, 40));
        }

        public List<Offer> getCurrentOffers()
        {
            return this.offers;
        }
    }

}

