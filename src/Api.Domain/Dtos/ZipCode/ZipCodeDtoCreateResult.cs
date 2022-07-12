using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreateResult
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Logradouro { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
