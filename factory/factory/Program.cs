FrontendCreator frontendCreator = new FrontendCreator();
frontendCreator.system = new FrontendSystem("Window", "Simple window");

List<Product> list = new List<Product>();
for (int i = 0; i < 5; i++)
{
    list.Add(frontendCreator.product());
    System.Console.WriteLine($"Было произвдено {i} продукта");
}

frontendCreator.system = new FrontendSystem("Button", "UI");

for (int i = 0; i < 5; i++)
{
    list.Add(frontendCreator.product());
    System.Console.WriteLine($"Было произвдено {i} продукта");
}


foreach (var item in list)
{
    item.getInfo();
}

abstract class Creator
{
    public abstract Product product();
}
abstract class Product
{
    public string name, descr;
    public void getInfo()
    {
        System.Console.WriteLine($"{name} {descr}");
    }
}

class BackendCreator : Creator
{
    public FrontendSystem system;
    
    public BackendCreator() { }
    public override Product product() => system;
}

class FrontendCreator : Creator
{
    public FrontendSystem system;
    public  FrontendCreator() { }
    public override Product product() => system;
}

class FrontendSystem : Product {
    public FrontendSystem(string name, string descr)
    {
        this.name = name;
        this.descr = descr;
    }
}

class BackendSystem : Product {
    public BackendSystem(string name, string descr)
    {
        this.name = name;
        this.descr = descr;
    }
}
