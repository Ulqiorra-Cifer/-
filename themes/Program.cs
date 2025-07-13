// comps comp = comps.acer;

// if (comp == comps.shorocomp) System.Console.WriteLine("It's a shorocomp");

// enum comps
// {
//     acer,
//     lenovo,
//     hp,
//     shorocomp
// }


// del del = sum;
// del += diff;

// del(6, 2);

// void sum(int a, int b)
// {
//     System.Console.WriteLine(a + b);
// }

// void diff(int a, int b)
// {
//     System.Console.WriteLine(a - b);
// }


// delegate void del(int x, int y);

// calculator((a, b) => a * b, 6, 1);

// void calculator(lamda lamda, int a, int b)
// {
//     if (lamda(a, b) < 18) System.Console.WriteLine("Дитё");
//     else System.Console.WriteLine("Пенсионер"); 
// }

// delegate int lamda(int x, int y);

// System.Console.WriteLine(calc("Plus")(7, 2));


// lamda calc(string action)
// {
//     if (action == "Plus") return (a, b) => a + b;
//     if (action == "Minus") return (a, b) => a - b;
//     else return (a, b) => 0;
// }


// delegate int lamda(int x, int y);


// del del = Greet;
// del("MISHAAA");
// void Greet(string name)
// {
//     System.Console.WriteLine($"Helllo {name}");
// }

// delegate void del(string name);

List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
lamda increasement = (x) => x + 10;

foreach (var i in nums)
{
    System.Console.WriteLine(increasement(i));
}

delegate int lamda(int x);


