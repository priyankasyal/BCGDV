using System;
namespace BCGDV.Product
{
    /**
    * Class Implementing Swatch Watch Product
    */
    public class SwatchWatch: IProduct
    {
        private string watchName;
        private string watchId;
        private int unitPrice;
        public SwatchWatch()
        {
            watchName = "Swatch";
            watchId = "003";
            unitPrice = 50;

        }
        public override int getUnitPrice()
        {
            return this.unitPrice;
        }

        public override string getId()
        {
            return this.watchId;
        }

        public override string getName()
        {
            return this.watchName;
        }

    }
}

