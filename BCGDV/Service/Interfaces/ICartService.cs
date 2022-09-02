using System;
using BCGDV.Models;
using BCGDV.Product;

namespace BCGDV.Service.Interfaces
{
    /*
     * Interface for Cart Service
     */
    public interface ICartService
    {
        public Cart createCart(List<string> productIdList);

    }
}

