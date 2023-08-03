using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
	public abstract class UserBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		[Required]
		public string FirstName { get; set; }

		public string LastName { get; set; }

		[NotMapped]
		public string FullName { get => FirstName + LastName; }

		[Required]
		[MinLength(9)]
		public string PhoneNumber { get; set; }

		public ProfileImage? ProfileImage { get; set; }

		//account settings
        public string Email { get; set; }

        public string UserName { get; set; }

		public string Password { get; set; }


		// Navigation properties	
		public ICollection<Address> Addresses { get; set; } = new List<Address>();
		public ICollection<ItemList> ItemLists { get; set; } = new List<ItemList>();
	}

	public class User : UserBase
	{		
	}
    
    public class UserForRead : UserBase
	{		
	}

	public class UserForAdd : UserBase
	{		
	}

	public class UserForUpdate : UserBase
	{
	}
}