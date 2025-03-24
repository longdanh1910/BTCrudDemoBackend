using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;


namespace TourWebApi.Models
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Destination { get; set; }
        public DateTime Start { get; set; }
        public string Img { get; set; }

        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        public required Province Province { get; set; }

    }
}