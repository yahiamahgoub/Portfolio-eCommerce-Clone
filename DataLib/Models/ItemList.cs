using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLib.Models
{
	public enum ItemListType
	{
		//All users have the first two by default, the last one is optional
		FavoriteByUser, ForSaleByUser, 
		CreatedByUser
	}

	public class ItemList
    {
		public ItemList() { }

		public ItemList(string name)
		{
			ListName = name;
			ItemListType = ItemListType.CreatedByUser;
        }

		public ItemList(ItemListType itemListType)
		{
			this.ItemListType = itemListType;
			ListName = this.ItemListType.ToString();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ItemListId { get; set; }
		
		public ItemListType ItemListType { get; set; }

		[Required]
		public string ListName { get; set; }

		//Navigation property
		public User User { get; set; }
		public int UserId { get; set; }
		public ICollection<ItemListToItemJoin> ItemListToItemJoin { get; set; } = new List<ItemListToItemJoin>();
	}
}
