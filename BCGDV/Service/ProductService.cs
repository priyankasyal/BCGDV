using System;
using BCGDV.Models;
using BCGDV.Product;
using BCGDV.Service.Interfaces;
using EnumStringValues;

namespace BCGDV.Service
{
    /*
     * Service Responsible for getting products from the given product catalogue
     * Can be extended for other product related functionalities like checking if the
     * given product id exists in the catalogue
     */
    public class ProductService : IProductService
    {
        public IProduct getProductById(string id)
        {
            if (id.Equals(ProductCatalogue.CasioWatch.GetStringValue()))
                return new CasioWatch();
            else if (id.Equals(ProductCatalogue.MichealKorsWatch.GetStringValue()))
                return new MichealKorsWatch();
            else if (id.Equals(ProductCatalogue.RolexWatch.GetStringValue()))
                return new RolexWatch();
            else if (id.Equals(ProductCatalogue.SwatchWatch.GetStringValue()))
                return new SwatchWatch();
            else throw new NotSupportedException();
        }    

    }
}

