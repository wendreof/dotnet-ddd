using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.City
{
    public class CityDtoCreate
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [MaxLength(length: 60, ErrorMessage = "O nome da cidade deve ter no máximo 60 caracteres {1} caracteres")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O código IBGE deve ser maior que 0")]
        public int CodIbge { get; set; }

        [Required(ErrorMessage = "Código da Uf É obrigatório")]
        public Guid UfId { get; set; }
    }
}
