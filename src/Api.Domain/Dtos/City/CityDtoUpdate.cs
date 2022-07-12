using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [MaxLength(length: 60, ErrorMessage = "O nome da cidade deve ter no máximo 60 caracteres {1} caracteres")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O código IBGE deve ser maior que 0")]
        public int CodIbge { get; set; }

        [Required(ErrorMessage = "Código da Uf É obrigatório")]
        public Guid UfId { get; set; }
    }
}
