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
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [StringLength(128 , ErrorMessage = "Allow 128 characters only.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(128 ,ErrorMessage = "Allow 128 characters only.")]
        [DataType(DataType.Text)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        public string Registration { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Text)]
        [StringLength(255, ErrorMessage = "Allow 255 characters only.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public byte[] Image { get; set; }
    }
}
