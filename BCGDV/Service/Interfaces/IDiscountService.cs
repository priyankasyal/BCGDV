using System;
using BCGDV.Models;
using BCGDV.Product;

namespace BCGDV.Service.Interfaces
{
    /*
     * Interface for Discount Service
     */
    public interface IDiscountService
    {
        public double getDiscountPrice(Cart cart);
    }
}

