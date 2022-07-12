using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreate
    {
        [Required(ErrorMessage = "O código postal é obrigatório")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public string Number { get; set; }

        public Guid CityId { get; set; }
    }
}
