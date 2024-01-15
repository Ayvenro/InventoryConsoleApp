namespace InventoryConsoleApp
{
	public class InventoryLogic : IInventoryLogic
	{
		private List<ItemData> _items = new List<ItemData>();

		public event Action<List<ItemData>> OnInventoryChanged;
		public event Action<ItemData> OnItemChanged;

		public ItemData? GetInformationAboutSlot(int id)
		{
			return id >= 0 && id < _items.Count ? _items[id] : null;
		}

		public List<ItemData> GetInventory()
		{
			return _items;
		}

		public void Move(int from, int to)
		{
			(_items[to], _items[from]) = (_items[from], _items[to]);
			OnInventoryChanged?.Invoke(GetInventory());
		}

		public bool TryAddItem(ItemData newItem, int count = 1)
		{
			var existingItem = _items.FirstOrDefault(i => i.Id == newItem.Id);
			if (existingItem != null)
			{
				existingItem.Count += count;
				OnItemChanged?.Invoke(existingItem);
				OnInventoryChanged?.Invoke(GetInventory());
				return true;
			}
			else
			{
				var item = new ItemData(newItem.Id, newItem.Name, count);
				_items.Add(item);
				OnItemChanged?.Invoke(newItem);
				OnInventoryChanged?.Invoke(GetInventory());
				return true;
			}
		}

		public bool TryRemoveItem(ItemData newItem, int count = 1)
		{
			var existingItem = _items.FirstOrDefault(i => i.Equals(newItem));
			if (existingItem != null)
			{
				existingItem.Count -= count;
				if (existingItem.Count <= 0)
				{
					existingItem.Count = 0;
					_items.Remove(existingItem);
					OnInventoryChanged?.Invoke(GetInventory());
					return true;
				}
				OnInventoryChanged?.Invoke(GetInventory());
				OnItemChanged(existingItem);
				return true;
			}
			return false;
		}
	}
}
