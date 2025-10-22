List<Book> Books = new List<Book>()
{
    new Book("poltava",150),
    new Book("Capitans Daughter",200),
    new Book("Evgeny Onegin",200),
    new Book("War and peace",400),
    new Book("Anna Karenina",100),
    new Book("Childhood",150),
    new Book("graveyard of fireflies",550),
    new Book("i want to take you to the moon",450),
    new Book("Death can wait for you around the corner", 300)
};

List<OrderItem> Items = new List<OrderItem>()
{
    new OrderItem(Books[6],3),
    new OrderItem(Books[7],8),
    new OrderItem(Books[1],1),
    new OrderItem(Books[0],9),
    new OrderItem(Books[3],2),
    new OrderItem(Books[2],4),
};

List<Order> Orders = new List<Order>()
{
    new Order(5.17f,new List<OrderItem>() { Items[5]}),
    new Order(6.10f,new List<OrderItem>() { Items[4]}),
    new Order(2.27f,new List<OrderItem>() { Items[1]}),
    new Order(7.05f,new List<OrderItem>() { Items[0]}),
    new Order(4.11f,new List<OrderItem>() { Items[3]}),
    new Order(3.14f,new List<OrderItem>() { Items[2]})
};

List<Customer> Customers = new List<Customer>(){
    new Customer("Vityaa",new List<Order>() { Orders[0] }),
    new Customer("Misha",new List<Order>() { Orders[4], Orders[2] }),
    new Customer("Vlados",new List<Order>() { Orders[1], Orders[3],Orders[5] })
}; 

Author Akira = new Author("just Akira", new List<Book>() { Books[6],Books[7],Books[8]});
Author Pushkin = new Author("Aleksandr Sergeevich Pushkin",new List<Book>() { Books[0],Books[1],Books[2]});
Author Tolstoy = new Author("Lev Nikolaevich Tolstoy", new List<Book>() { Books[3], Books[4], Books[5] });
var res = Customers.OrderByDescending(x => x.Orders.Count).ToList();
System.Console.WriteLine(res.First().Name);

var res1 = Orders.OrderByDescending(x => x.Items[0].Quantity).ToList();
for (int i = 0; i < 3; i++)
{
    System.Console.WriteLine(res1[i].Items[0].Book.Title);
}

var res2 = Orders.OrderBy(x => x.Items[0].Quantity).ToList();
for (int i = 0; i < Math.Min(res1.Count, res2.Count); i++)
{
    System.Console.WriteLine(res2[i].Items[0].Book.Price * res2[i].Items[0].Quantity);
}
System.Console.WriteLine();


class Author
{
    public static int Id;
    public int ID;
    public string FullName;
    public List<Book> Books = new();
    public Author(string FullName, List<Book> Books)
    {
        Id++;
        Id = ID;
        this.FullName = FullName;
        this.Books = Books;
    }
}


class Book
{
    public static int Id;
    public int ID;
    public string Title;
    public decimal Price;
    public int AuthorId;
    public Author Author;
    public Book(string Title, decimal Price)
    {
        Id++;
        Id = ID;
        this.Title = Title;
        this.Price = Price;
    } 
}

class Customer
{
    public static int Id;
    public int ID;
    public string Name;
    public List<Order> Orders = new();
    public Customer(string Name, List<Order> Orders)
    {
        Id++;
        Id = ID;
        this.Name = Name;
        this.Orders = Orders;  
    }
}

class Order
{
    public static int Id;
    public int ID;
    public static int CustomerId;
    public int CustomerID;
    public float OrderDate;
    public List<OrderItem> Items = new();
    public Order(float OrderDate, List<OrderItem> Items)
    {
        CustomerId++;
        CustomerId = CustomerID;
        Id++;
        Id = ID;
        this.OrderDate = OrderDate;
        this.Items = Items;
    }
}

class OrderItem
{
    public static int BookId;
    public int BookID;
    public Book Book;
    public int Quantity;
    public OrderItem(Book Book, int Quantity)
    {
        BookId++;
        BookId = BookID;
        this.Book = Book;
        this.Quantity = Quantity;
    }
}