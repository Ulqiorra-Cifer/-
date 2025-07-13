// Coffee coffee = new Coffee("Espresso", new FilterCoffee());
// coffee.prepare();

// interface IStartegy
// {
//     public void Algorithm();
// }

// class Coffee
// {
//     string name;
//     IStartegy startegy;

//     public Coffee(string name, IStartegy startegy)
//     {
//         this.name = name;
//         this.startegy = startegy;
//     }

//     public void prepare()
//     {
//         startegy.Algorithm();
//     }

//     public void changeStrategy(IStartegy startegy)
//     {
//         this.startegy = startegy;
//     }
// }

// class Espresso : IStartegy
// {
//     public void Algorithm()
//     {
//         System.Console.WriteLine("быстрое приготовление при высоком давлении.");
//     }
// }

// class FilterCoffee : IStartegy
// {
//     public void Algorithm()
//     {
//         System.Console.WriteLine("медленное заваривание через фильтр.");
//     }
// }

// class FrenchPress : IStartegy
// {
//     public void Algorithm()
//     {
//         System.Console.WriteLine("настаивание молотого кофе в воде с последующим прессованием.");
//     }
// }
