using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Unions
{
    public class Apartment 
    {
        public Apartment(int id, string name, string zipCode, string city, string country, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; }
        public string Name { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string Country { get; }
        public double Latitude { get; }
        public double Longitude { get; }

      
    }
}
