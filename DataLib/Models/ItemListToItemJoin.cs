namespace DataLib.Models
{
	public class ItemListToItemJoin
	{
		public int ItemId { get; set; }
		public Item? Item { get; set; }

		public int ItemListId { get; set; }
		public ItemList? ItemList { get; set; }
	}
}
