namespace InventoryConsoleApp
{
	public interface IInventoryLogic
	{
		public event Action<List<ItemData>> OnInventoryChanged;
		public event Action<ItemData> OnItemChanged;

		public List<ItemData> GetInventory();
		public ItemData? GetInformationAboutSlot(int id);
		public void Move(int from, int to);
		public bool TryAddItem(ItemData newItem, int count = 1);
		public bool TryRemoveItem(ItemData newItem, int count = 1);
	}
}
