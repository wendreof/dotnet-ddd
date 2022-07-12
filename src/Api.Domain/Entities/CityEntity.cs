using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(length: 60)]
        public string Name { get; set; }

        public int CodIbge { get; set; }

        [Required]
        public Guid UfId { get; set; }

        public UfEntity Uf { get; set; }

        public IEnumerable<ZipCodeEntity> ZipCodes { get; set; }
    }
}
