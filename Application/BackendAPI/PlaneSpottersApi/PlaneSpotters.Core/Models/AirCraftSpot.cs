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
    /// <summary>
    /// AirCraftSpot
    /// </summary>
    public class AirCraftSpot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Allow 255 characters only.")]
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Date)]
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the aircraft identifier.
        /// </summary>
        /// <value>
        /// The aircraft identifier.
        /// </value>
        [JsonProperty("aircraftId")]
        public int AircraftId { get; set; }
        /// <summary>
        /// Gets or sets the aircraft.
        /// </summary>
        /// <value>
        /// The aircraft.
        /// </value>
        public Aircraft Aircraft { get; set; }
    }
}
