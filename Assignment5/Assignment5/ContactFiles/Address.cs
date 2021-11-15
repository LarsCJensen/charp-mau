using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Using nuget package with all countries, codes etc
using ISO3166;

// Choosing not to have the "ContactFiles" folder added to the namespace
namespace Assignment5
{
    public class Address
    {
        private string street;
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        private string zipcode;
        public string Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                zipcode = value;
            }
        }
        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        
        // No default Address since city and country is required
        //public Address():
        //{
            
        //}

        public Address(string newCity, string newCountry) : this(newCity, newCountry, "Unknown Street")
        {

        }
        public Address(string newCity, string newCountry, string newStreet) : this(newCity, newCountry, newStreet, "123 45")
        {

        }

        public Address(string newCity, string newCountry, string newStreet, string newPostalCode)
        {
            street = newStreet;
            city = newCity;
            zipcode = newPostalCode;
            country = newCountry;
        }
    }
}
