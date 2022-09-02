using System;
using BCGDV.Models;
using BCGDV.Product;

namespace BCGDV.Service.Interfaces
{
    /*
     * Interface for Billing Service
     */
    public interface IBillingService
    {
        public double getBillingValue(Cart cart);
    }
}

