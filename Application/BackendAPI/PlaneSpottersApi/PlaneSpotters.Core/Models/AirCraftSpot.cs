using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Models
{
    public class AirCraftSpot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Allow 255 characters only.")]
        [JsonProperty("location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Date)]
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("aircraftId")]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
