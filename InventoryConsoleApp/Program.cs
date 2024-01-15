using InventoryConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IInventoryLogic, InventoryLogic>();
using IHost host = builder.Build();

IServiceProvider provider = builder.Services.BuildServiceProvider();

IInventoryLogic inventory = provider.GetService<IInventoryLogic>();

List<ItemData> tableItems = new List<ItemData>()
{
	new ItemData (0, "Coins", 33),
	new ItemData(1, "Book", 1),
	new ItemData(2, "Amulet", 1)
};

Container container = new Container(tableItems, inventory);

Console.WriteLine("Item in table before taking");
foreach (var item in tableItems)
{
	Console.WriteLine($"{item.Name} - {item.Count}");
}
container.TakeItem(0, 1);
container.TakeItem(1, 1);

Console.WriteLine("Item in inventory");
foreach (var item in inventory.GetInventory())
{
	Console.WriteLine($"{item.Name} - {item.Count}");
}

Console.WriteLine("Item in table after taking");
foreach (var item in tableItems)
{
	Console.WriteLine($"{item.Name} - {item.Count}");
}
container.TakeItem(0, 1);
Console.WriteLine("Item in inventory");
foreach (var item in inventory.GetInventory())
{
	Console.WriteLine($"{item.Name} - {item.Count}");
}