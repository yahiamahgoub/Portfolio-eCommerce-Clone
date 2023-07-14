using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }

        [Required]
        public bool IsMainImage { get; set; }

        public string? Description { get; set; }

        [Required]
        public byte[] ImageBytes { get; set; }

        // Navigation properties		
        //public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
