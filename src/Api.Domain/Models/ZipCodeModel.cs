using System;

namespace Api.Domain.Models
{
    public class ZipCodeModel
    {
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }

        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }

    }
}
