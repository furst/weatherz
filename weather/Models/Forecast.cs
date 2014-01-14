using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weather.Models
{
    [MetadataType(typeof(Forecast_Metadata))]
    public partial class Forecast
    {
        public int Period { get; set; }

        class Forecast_Metadata
        {
        }
    }
}