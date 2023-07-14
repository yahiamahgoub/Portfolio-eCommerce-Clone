using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        // Navigation properties	
        internal ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
