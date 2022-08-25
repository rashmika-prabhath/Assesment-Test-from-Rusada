using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace PlaneSpotters.Core.Models
{
    /// <summary>
    /// Aircraft
    /// </summary>
    public class Aircraft
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
        /// Gets or sets the make.
        /// </summary>
        /// <value>
        /// The make.
        /// </value>
        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [JsonProperty("make")]
        [StringLength(128, ErrorMessage = "Allow 128 characters only.")]
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [Required(ErrorMessage = "Required field.")]
        [StringLength(128, ErrorMessage = "Allow 128 characters only.")]
        [JsonProperty("model")]
        [DataType(DataType.Text)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the registration.
        /// </summary>
        /// <value>
        /// The registration.
        /// </value>
        [Required(ErrorMessage = "Required field.")]
        [RegularExpression(@"[a-zA-Z]{1,2}-[a-zA-Z]{1,5}", ErrorMessage = "Invalid Entry.")]
        [JsonProperty("registration")]
        [DataType(DataType.Text)]
        public string Registration { get; set; }

        //[Required(ErrorMessage = "Required field.")]
        //[DataType(DataType.Text)]
        //[StringLength(255, ErrorMessage = "Allow 255 characters only.")]
        //[JsonProperty("location")]
        //public string Location { get; set; }

        //[Required(ErrorMessage = "Required field.")]
        //[DataType(DataType.Date)]
        //[JsonProperty("dateTime")]
        //public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [DataType(DataType.ImageUrl)]
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Aircraft"/> is sighting.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sighting; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("sighting")]
        public bool Sighting { get; set; }
        /// <summary>
        /// Gets or sets the air craft spots.
        /// </summary>
        /// <value>
        /// The air craft spots.
        /// </value>
        public ICollection<AirCraftSpot> AirCraftSpots { get; set; }
    }
}
