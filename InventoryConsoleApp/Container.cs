using InventoryConsoleApp;

public class Container
{
	private readonly IInventoryLogic _inventoryLogic;
	private List<ItemData> _items;

	public Container(IInventoryLogic inventoryLogic)
	{
		_inventoryLogic = inventoryLogic;
	}

	public Container(List<ItemData> items, IInventoryLogic inventoryLogic)
	{
		_items = items;
		_inventoryLogic = inventoryLogic;
	}
	
	public void TakeItem(int id, int count = 1)
	{
		var item = _items.FirstOrDefault(x => x.Id == id);
		_inventoryLogic.TryAddItem(item);
		item.Count -= count;
		if (item.Count <= 0)
		{
			_items.Remove(item);
		}
	}
}
