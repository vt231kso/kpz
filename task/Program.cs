using task.Classes;
using task.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var usd = new USD();
var money = new Money(10, 50, usd);
var product = new Product("Волейбольний м'яч", money, ProductCategory.Sports);
var warehouseItem = new WarehouseItem(product, "шт", 100, DateTime.Now);

var usd1 = new USD();
var money1 = new Money(20, 30, usd);
var product1 = new Product("Кросівки", money1, ProductCategory.Sports);
var warehouseItem1 = new WarehouseItem(product1, "шт", 150, DateTime.Now);


var warehouse = new Warehouse();
warehouse.AddItem(warehouseItem);
warehouse.AddItem(warehouseItem1);

var reporting = new Reporting();
reporting.RegisterIncome(warehouseItem);
reporting.RegisterShipment(warehouseItem, 50);
reporting.RegisterIncome(warehouseItem1);
reporting.RegisterShipment(warehouseItem1, 100);


var cart = new Cart();
cart.AddToCart(product, 2);
cart.AddToCart(product1, 1);
cart.DisplayCart();

warehouse.InventoryReport();
reporting.ShowReports();

