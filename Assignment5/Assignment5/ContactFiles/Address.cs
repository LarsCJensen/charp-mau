// Choosing not to have the "ContactFiles" folder added to the namespace as it is too verbose IMO
namespace Assignment5
{
    /// <summary>
    /// Class which holds address information
    /// </summary>
    public class Address
    {
        private string street;
        public string Street
        {
            get
            {
                return street;
            }            
        }
        private string city;
        public string City
        {
            get
            {
                return city;
            }            
        }

        private string zipcode;
        public string Zipcode
        {
            get
            {
                return zipcode;
            }
        }
        private string country;
        public string Country
        {
            get
            {
                return country;
            }
        }
        
        // No default constructor since city and country is required
        //public Address():
        //{
            
        //}
        // This overload and chain example is a bit strange, but it works. 
        public Address(string newCity, string newCountry) : this(newCity, newCountry, "")
        {}
        public Address(string newCity, string newCountry, string newStreet) : this(newCity, newCountry, newStreet, "")
        {}

        public Address(string newCity, string newCountry, string newStreet, string newPostalCode)
        {
            street = newStreet;
            city = newCity;
            zipcode = newPostalCode;
            country = newCountry;
        }
    }
}
