using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIbge { get; set; }
        public Guid UfId { get; set; }
    }
}
