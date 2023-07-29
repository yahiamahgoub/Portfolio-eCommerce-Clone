using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Required]
        public bool IsMainAddress { get; set; }
        [Required]
        public string AddressLine { get; set; }
        public string? ApartmentLine { get; set; }
        public string? City { get; set; }
        public string? ZipOrPostalCode { get; set; }
		
		[NotMapped]
		public string? FullAddress { get => ToString(); }

        // Navigation properties	
        public Country Country { get; set; }
        public int CountryId { get; set; }

        internal User? Poster { get; set; }
        public int? UserId { get; set; }

        internal ICollection<Item> Items { get; set; } = new List<Item>();

		public override string ToString()
		{
			string addressLine = string.IsNullOrEmpty(AddressLine)? string.Empty : $"{AddressLine}";
			string zipOrPostalCode = string.IsNullOrEmpty(ZipOrPostalCode) ? string.Empty : $", {ZipOrPostalCode}";
			string city = string.IsNullOrEmpty(City)? string.Empty : $", {City}";
			string country = string.IsNullOrEmpty(Country?.CountryName) ? string.Empty : $", {Country.CountryName}";

			return $"{addressLine} {zipOrPostalCode} {city} {country}";
		}
	}
}
