using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(9)]
        public string PhoneNumber { get; set; }

        // Navigation properties	
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }


	public class UserForRead
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public ICollection<Address> Addresses { get; set; } = new List<Address>();
		public ICollection<Item> Items { get; set; } = new List<Item>();
	}
}
