using System;
using BCGDV.Product;

namespace BCGDV.Service.Interfaces
{
    /*
     * Interface for Product Service
     */
    public interface IProductService
    {
        public IProduct getProductById(string id);
    }
}

