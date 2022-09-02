using System;
using System.Runtime.Serialization;
using EnumStringValues;

namespace BCGDV.Models
{
    /**
    * Enum for Creating Product Catalogue and mapping product ID's with their type
    */
    public enum ProductCatalogue 
    {
        [StringValue("001")]
        RolexWatch,
        [StringValue("002")]
        MichealKorsWatch,
        [StringValue("003")]
        SwatchWatch,
        [StringValue("004")]
        CasioWatch
    }
}

