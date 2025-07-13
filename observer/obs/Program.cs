// Host sudya = new Host("Artem");
// Mafia p1 = new Mafia();
// Policeman p2 = new Policeman();
// Doctor p3 = new Doctor();
// Civilian p4 = new Civilian();
// p1.AddObserver(sudya);
// p2.AddObserver(sudya);
// p3.AddObserver(sudya);
// p4.AddObserver(sudya);
// p1.Notify("игрок один мафия");
// p2.Notify("игрок два шериф");
// p3.Notify("игрок три доктор");
// p4.Notify("игрок четыре житель");

// interface Admin
// {
//     public void update(string message);
// }

// interface Player
// {
//     public void Notify(string message);
//     public void AddObserver(Admin observer);
// }

// class Host : Admin
// {
//     public string name;
//     public Host(string name)
//     {
//         this.name = name;
//     }
//     public void update(string message)
//     {
//         System.Console.WriteLine($"Ведущему{name} игры пришла информация{message}");
//     }
// }

// class Mafia : Player
// {
//     public List<Admin> observers = new List<Admin>();
//     public void AddObserver(Admin observer)
//     {
//         observers.Add(observer);
//     }
//     public void Notify(string message)
//     {
//         foreach (var i in observers) i.update(message);
//     }
// }

// class Policeman : Player
// {
//     public List<Admin> observers = new List<Admin>();
//     public void AddObserver(Admin observer)
//     {
//         observers.Add(observer);
//     }
//     public void Notify(string message)
//     {
//         foreach (var i in observers) i.update(message);
//     }
// }

// class Doctor : Player
// {
//     public List<Admin> observers = new List<Admin>();
//     public void AddObserver(Admin observer)
//     {
//         observers.Add(observer);
//     }
//     public void Notify(string message)
//     {
//         foreach (var i in observers) i.update(message);
//     }
// }   

// class Civilian : Player
// {
//     public List<Admin> observers = new List<Admin>();
//     public void AddObserver(Admin observer)
//     {
//         observers.Add(observer);
//     }
//     public void Notify(string message)
//     {
//         foreach (var i in observers) i.update(message);
//     } 
// // }
// OrderManager dude1 = new OrderManager("Artem");
// CustomerNotifier dude2 = new CustomerNotifier("Maksim");
// AdminNotifier dude3 = new AdminNotifier("Tolya");
// CourierManager dude4 = new CourierManager("Danya");
// Customer dude5 = new Customer();
// Courier dude6 = new Courier();
// Admin dude7 = new Admin();
// dude5.Attach(dude2);
// dude6.Attach(dude4);
// dude7.Attach(dude3);
// dude5.Notify("получил свою шаурму");
// dude6.Notify("справился и отдал заказ");
// dude7.Notify("можно начислять курьеру зарплату");

// interface IObserver
// {
//     public void Update(string message);
// }

// interface IObserveable
// {
//     public void Attach(IObserver observer);
//     public void Detach(IObserver observer);
//     public void Notify(string message);
// }

// class OrderManager : IObserver {
//     public string name;
//     public OrderManager(string name)
//     {
//         this.name = name;
//     }
//     public void Update(string message)
//     {
//         System.Console.WriteLine($"{name} пришла информация {message}");
//     }
// }

// class CourierManager : IObserver {
//     public string name;
//     public CourierManager(string name)
//     {
//         this.name = name;
//     }
//     public void Update(string message)
//     {
//         System.Console.WriteLine($"{name} пришла информация {message}");
//     }
// }

// class CustomerNotifier : IObserver {
//     public string name;
//     public CustomerNotifier(string name)
//     {
//         this.name = name;
//     }
//     public void Update(string message)
//     {
//         System.Console.WriteLine($"{name} пришла информация {message}");
//     }
// }

// class AdminNotifier : IObserver
// {
//     public string name;
//     public AdminNotifier(string name)
//     {
//         this.name = name;
//     }
//     public void Update(string message)
//     {
//         System.Console.WriteLine($"{name} пришла информация {message}");
//     }
// }

// class Courier : IObserveable
// {
//     List<IObserver> observers = new List<IObserver>();
//     public void Attach(IObserver observer)
//     {
//         observers.Add(observer);
//     }
//     public void Detach(IObserver observer) {
//         observers.Remove(observer);
//     }
//     public void Notify(string message) {
//         foreach (var i in observers) i.Update(message);
//     }
// }

// class Customer : IObserveable {
//     List<IObserver> observers = new List<IObserver>();
//     public void Attach(IObserver observer)
//     {
//         observers.Add(observer);
//     }
//     public void Detach(IObserver observer) {
//         observers.Remove(observer);
//     }
//     public void Notify(string message) {
//         foreach (var i in observers) i.Update(message);
//     }
// }

// class Admin : IObserveable {
//     List<IObserver> observers = new List<IObserver>();
//     public void Attach(IObserver observer)
//     {
//         observers.Add(observer);
//     }
//     public void Detach(IObserver observer) {
//         observers.Remove(observer);
//     }
//     public void Notify(string message) {
//         foreach (var i in observers) i.Update(message);
//     }
// }
