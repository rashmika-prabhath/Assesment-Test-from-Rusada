using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace PlaneSpotters.Core.Models
{
    public class Aircraft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [JsonProperty("make")]
        [StringLength(128, ErrorMessage = "Allow 128 characters only.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(128, ErrorMessage = "Allow 128 characters only.")]
        [JsonProperty("model")]
        [DataType(DataType.Text)]
        public string Model { get; set; }

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

        [DataType(DataType.ImageUrl)]
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("sighting")]
        public bool Sighting { get; set; }
        public ICollection<AirCraftSpot> AirCraftSpots { get; set; }
    }
}
