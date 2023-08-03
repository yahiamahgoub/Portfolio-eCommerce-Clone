using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLib.Models
{
    public enum Status
    {
        Available, OutOfStock, Delisted, Deleted
    }
    public enum Currency
    {
        SEK, USD, EGP, EURO
    }

    public abstract class ItemBase
    {
        [Required(ErrorMessage = "You should provide a value for name")]
        public string ItemName { get; set; }

        public string? ItemDescription { get; set; }

        [Required(ErrorMessage = "You should provide a price for the item, or if free set to zero!")]
        public decimal ItemPrice { get; set; }

        [Required(ErrorMessage = "You should provide a value for Currency")]

        public Currency Currency { get; set; }

        [Required(ErrorMessage = "You should provide a value for status")]
        public Status Status { get; set; }

		public ICollection<ItemListToItemJoin> ItemListToItemJoin { get; set; } = new List<ItemListToItemJoin>();

	}


	public class Item : ItemBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

		// Navigation properties		
		[NotMapped]
		User User { get; set; }
        internal Category Category { get; set; }
        public int CategoryId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public ICollection<Image> ImageList { get; set; } = new List<Image>();
		
		[NotMapped]
		public Image MainImage { get => ImageList.FirstOrDefault(item => item.IsMainImage); }

        public DateTime DatePosted { get; set; }

        public DateTime DateLastedUpdated { get; set; }

        [NotMapped]
        public DateTime? TimeSincePost { get; set; }
    }

    public class ItemMini : ItemBase
    {
        public int ItemId { get; set; }
		public Image MainImage { get; set; }
        public DateTime? TimeSincePost { get; set; }
	}

    public class ItemForAdd : ItemBase
    {
        public int ItemId { get; set; }
        // Navigation properties		
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Image> ImageList { get; set; } = new List<Image>();
    }

    public class ItemForUpdate : ItemBase
    {
        public int ItemId { get; set; }

        // Navigation properties		
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Image> ImageList { get; set; } = new List<Image>();
    }
}
