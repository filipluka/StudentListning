using System.ComponentModel.DataAnnotations.Schema;

namespace StudentListning.Models
{
    [Table("Addresses")]
    public class Address
    {
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public int AddressID { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }

    }
}
