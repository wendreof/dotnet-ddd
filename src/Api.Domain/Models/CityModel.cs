using System;

namespace Api.Domain.Models
{
    public class CityModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _codIbge;
        public int CodeIbge
        {
            get { return _codIbge; }
            set { _codIbge = value; }
        }

        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }
    }
}
