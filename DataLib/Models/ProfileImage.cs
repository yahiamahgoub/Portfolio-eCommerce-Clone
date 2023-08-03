using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
	public class ProfileImage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserImageId { get; set; }

		[Required]
		public byte[] ImageBytes { get; set; }

		// Navigation properties		
		public int UserId { get; set; }
		public User User { get; set; }

		public static Image FromByteArray(byte[] imageBytes)
		{
			return new Image { ImageBytes = imageBytes };
		}
	}
}
