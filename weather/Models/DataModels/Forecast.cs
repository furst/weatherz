//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace weather.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forecast
    {
        public int ForecastId { get; set; }
        public int GeoinfoId { get; set; }
        public System.DateTime Day { get; set; }
        public int Temperature { get; set; }
        public int Symbol { get; set; }
    
        public virtual Geoinfo Geoinfo { get; set; }
    }
}
