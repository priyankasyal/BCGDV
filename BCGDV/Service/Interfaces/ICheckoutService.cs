using System;
namespace BCGDV.Service.Interfaces
{
     /*
     * Interface for Checkout Service
     */
    public interface ICheckoutService
    {
        public double getCheckoutValue(List<string> items);
    }
}

