using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weather.Models
{
    [MetadataType(typeof(Geoinfo_Metadata))]
    public partial class Geoinfo
    {
        class Geoinfo_Metadata
        {
            [StringLength(50)]
            [DisplayName("Sök på stad")]
            [Required]
            public string City { get; set; }
        }
    }
}