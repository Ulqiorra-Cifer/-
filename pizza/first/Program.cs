List<PizzaOrder> Orders = new List<PizzaOrder>()
{
    new PizzaOrder("Vitya","Pepperoni",30,true,"Toktogula 167"),
    new PizzaOrder("Elena","Margaritta",45,false,""),
    new PizzaOrder("Misha","Ananasi fuuuuu",50,true,"Manasa 35"),
};

Orders.Add(Orders[0] with {Size=40, Delivery=false, Address=""} );
foreach (var i in Orders)
{
    System.Console.WriteLine($"{i.CustomerName} {i.Pizza} {i.Size} {i.Delivery} {i.Address}");
}

public record PizzaOrder(string CustomerName, string Pizza, int Size, bool Delivery, string Address);
