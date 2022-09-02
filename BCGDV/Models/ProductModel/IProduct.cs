using System;
using System.Drawing;

namespace BCGDV.Product
{
    /**
    * Abstract Class for creating watch products
    */
    public abstract class IProduct
    {

        public abstract string getName();
        public abstract string getId();
        public abstract int getUnitPrice();

        public override bool Equals(Object obj)
        {
            // Perform an equality check on two rectangles (Point object pairs).
            if (obj == null || GetType() != obj.GetType())
                return false;
            IProduct product = (IProduct)obj;
            return this.getName().Equals(product.getName()) &&  this.getUnitPrice().Equals(product.getUnitPrice()) && this.getId().Equals(product.getId());
        }

        public override int GetHashCode()
        {
            return (getName().GetHashCode() + getId().GetHashCode() + getUnitPrice().GetHashCode());

        }


    }
}

