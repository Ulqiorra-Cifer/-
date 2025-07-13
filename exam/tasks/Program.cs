// System.Console.WriteLine("введите ваш возраст");
// int age = Convert.ToInt32(Console.ReadLine());
// if (age < 12 && age > 0)
// {
//     System.Console.WriteLine("вы ребенок");
// }
// else if (age >= 12 && age <= 18)
// {
//     System.Console.WriteLine("вы подросток");
// }
// else if (age >= 19 && age <= 65)
// {
//     System.Console.WriteLine("вы взрослый");
// }
// else if (age > 65)
// {
//     System.Console.WriteLine("вы пенсионер");
// }
// else
// {
//     System.Console.WriteLine("такого возраста не бывает, не придумывай!");
// }

// System.Console.WriteLine("введите число от 1 до 10");
// int a = Convert.ToInt32(Console.ReadLine());
// for (int i = 0; i <= 10; i++)
// {
//     int b = i * a;
//     int res = b;
//     System.Console.WriteLine(res);
// // }
// reverse(list);
// foreach (var i in reversed)
// {
//     System.Console.WriteLine(i);
// }

// for (int i = list.Count() - 1; i >= 0; i--)
// {
//     System.Console.WriteLine(list[i]);
// }


// void reverse(List<int> list)
// {
//     for (int j = 0; j < list.Count(); j++)
//     {
//         int max = 0;
//         for (int i = j; i < list.Count(); i++)
//         {
//             if (max < list[j])
//             {
//                 max = list[j];
//             }
//         }
//         reversed.Add(max);
//     }
// }

// string name = "anton";
// for(int i = 0; i < name.Count(); i++ ) System.Console.WriteLine(name[i]);

// System.Console.WriteLine("enter your numbers");
// List<int> nums = new List<int>() { };
// int i = 0;
// while (i <= 0)
// {
//     int x = Convert.ToInt32(Console.ReadLine());
//     if (x > 0)
//     {
//         nums.Add(x);
//     }
//     if (x == 0) break;
// }
// int a=0;
// foreach (var b in nums)
// {
//     a += b;

// }
//     System.Console.WriteLine(a / nums.Count());

// Circle circle = new Circle(5);
// Rectangle rectangle = new Rectangle(5, 10);
// circle.GetArea();
// rectangle.GetArea();
// abstract class Shape
// {
//     public int r, widht, height;
//     public abstract void GetArea();
// }

// class Circle : Shape
// {
//     public Circle(int r)
//     {
//         this.r = r;
//     }
//     public override void GetArea()
//     {
//         double area = 3.14 * r * r;
//         System.Console.WriteLine($"Area of the circle equals: {area}");
//     }
// }

// class Rectangle : Shape
// {
//     public Rectangle(int widht, int height)
//     {
//         this.widht = widht;
//         this.height = height;
//     }
//     public override void GetArea()
//     {
//         int area = widht * height;
//         System.Console.WriteLine($"Area of the rectangle equals: {area}");
//     }
// }

// Player player = new Player(50,"Knight");
// Enemy enemy = new Enemy(100, "Ogre");
// player.atack(enemy);
// enemy.TakeDamage(10);

// class Player
// {
//     public int hp;
//     public string name;
//     public Player(int hp, string name)
//     {
//         this.hp = hp;
//         this.name = name;
//     }
//     public void atack(Enemy enemy)
//     {
//         System.Console.WriteLine($"{name} atacked {enemy}");
//     }
// }

// class Enemy : Player
// {

//     public Enemy(int hp, string name) : base(hp, name)
//     {
//         this.hp = hp;
//         this.name = name;
//     }
//     public void TakeDamage(int damage)
//     {
//         int res = hp - damage;
//         System.Console.WriteLine($"{name} took {damage} damage, and have {res} hp left");
//     }
// }

Car car = new Car("Porsche");
Bycycle bycycle = new Bycycle("Tsunami");
car.Drive();
bycycle.Drive();

interface IDriveable
{
    public abstract void Drive();
}

class Car : IDriveable
{
    public string name;
    public Car(string name)
    {
        this.name = name;
    }
    public void Drive()
    {
        System.Console.WriteLine($"{name} is driving");
    }
}

class Bycycle : IDriveable
{
    public string name;
    public Bycycle(string name)
    {
        this.name = name;
    }
    public void Drive()
    {
        System.Console.WriteLine($"{name} is driving");
    }
}