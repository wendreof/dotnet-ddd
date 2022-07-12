using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ZipCodeEntity : BaseEntity
    {
        [Required]
        [MaxLength(length: 10)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(length: 60)]
        public string Logradouro { get; set; }

        [MaxLength(length: 10)]
        public string Number { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public CityEntity City { get; set; }
    }
}
