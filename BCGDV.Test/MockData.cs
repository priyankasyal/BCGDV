using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Product.DiscountModel;

namespace BCGDV.Test
{
    public class MockData
    {
        public List<Offer> offers { get; }
        public RolexWatch rolexWatch { get;  }
        public MichealKorsWatch michealKorsWatch { get;  }
        public CasioWatch casioWatch { get; }
        public SwatchWatch swatchWatch { get; }
        public Offer offer1 { get; }
        public Offer offer2 { get;  }
        public Cart cartWithRolexWatches { get;  }
        public Cart cartWithRolexAndMichealKorsWatches { get; }
        public Cart cartWithMichealKorsWatches { get; }
        public Cart cartWithoutOfferWatches { get;  }
        public Cart cartWithWatchesLessThanMinimumQuantity { get;  }


        public MockData()
        {
            offer1 = new Offer(new RolexWatch(), 3, 100);
            offer2 = new Offer(new MichealKorsWatch(), 2, 40);
            offers = new List<Offer>();
            offers.Add(offer1);
            offers.Add(offer2);
            casioWatch = new CasioWatch();
            rolexWatch = new RolexWatch();
            swatchWatch = new SwatchWatch();
            michealKorsWatch = new MichealKorsWatch();
            cartWithMichealKorsWatches = new Cart(michealKorsWatch, offer2.discountQuantity);
            cartWithRolexWatches = new Cart(rolexWatch, offer1.discountQuantity);
            cartWithWatchesLessThanMinimumQuantity = new Cart(rolexWatch, offer1.discountQuantity - 1);
            cartWithoutOfferWatches = new Cart(swatchWatch, 1);
            cartWithoutOfferWatches.addItemWithQuantity(casioWatch, 1);
            cartWithRolexAndMichealKorsWatches = new Cart(rolexWatch, offer1.discountQuantity);
            cartWithRolexAndMichealKorsWatches.addItemWithQuantity(michealKorsWatch, offer2.discountQuantity);


        }

  
    }
}

