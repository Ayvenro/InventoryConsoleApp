namespace InventoryConsoleApp
{
	public class ItemData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public int Count { get; set; }

		public ItemData(int id, string name, int count)
		{
			Id = id;
			Name = name;
			Count = count;
		}

		public ItemData(int id, string name, string description, int count)
		{
			Id = id;
			Name = name;
			Description = description;
			Count = count;
		}

	}
}