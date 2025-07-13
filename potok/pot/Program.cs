// Thread thread = new Thread(findMin);
// Thread thread1 = new Thread(findMax);
// Thread thread2 = new Thread(findMin);
// Thread thread3 = new Thread(findMax);
// List<Thread> threads = new List<Thread>() { thread, thread1, thread2, thread3 };
// foreach (var i in threads) i.Start();

// void findMin()
// {
//     List<int> a = new List<int>() { 6, 3, 8, 2, 8 };
//     int min = 100;

//     for (int i = 0; i < a.Count(); i++)
//     {
//         if (min > a[i]) min = a[i];
//         System.Console.WriteLine($"Мы нашли наименьшее число {min}");
//         Thread.Sleep(5000);
//     }

//     System.Console.WriteLine(min);

// }

// void findMax()
// {
//     List<int> a = new List<int>() { 6, 3, 8, 2, 8 };
//     int max = 0;

//     for (int i = 0; i < a.Count(); i++)
//     {
//         if (max < a[i]) max = a[i];
//         System.Console.WriteLine($"Мы нашли наибольшее число {max}");
//         Thread.Sleep(1000);

//     }

//     System.Console.WriteLine(max);
// }
// Thread thread = new Thread(nechetnie);
// Thread thread1 = new Thread(chetnie);
// thread.Start();
// thread1.Start();

// void nechetnie()
// {
//     for (int i = 1; i < 10; i += 2)
//     {
//         System.Console.WriteLine($"Нечётные числа {i}");
//         Thread.Sleep(5000);
//     }
// }

// void chetnie()
// {
//     for (int i = 0; i <= 10; i += 2)
//     {
//         System.Console.WriteLine($"Чётные числа {i}");
//         Thread.Sleep(2000);
//     }
// }



// Thread thread = new Thread(new ParameterizedThreadStart(findMax));
// thread.Start(new Parameters(5000, new List<int>(){5, 2, 1, 7, 9, 5, 7, 3}));
// Thread thread1 = new Thread(new ParameterizedThreadStart(findMin));
// thread1.Start(new Parameters(2000, new List<int>(){5, 2, 1, 7, 9, 5, 7, 3}));

// void findMin(object? nezn)
// {
//     var a = nezn as Parameters;
//     int min = 100;
//     for (int i = 0; i < a.list.Count(); i++)
//     {
//         if (min > a.list[i]) min = a.list[i];
//         System.Console.WriteLine($"Мы нашли наименьшее число {min}");
//         Thread.Sleep(a.time);
//     }
//     System.Console.WriteLine(min);

// }

// void findMax(object? obj)
// {
//     int max = 0;
//     var l = obj as Parameters;

//     for (int i = 0; i < l.list.Count(); i++)
//     {
//         if (max < l.list[i]) max = l.list[i];
//         System.Console.WriteLine($"Мы нашли наибольшее число {max}");
//         Thread.Sleep(l.time);

//     }
//     System.Console.WriteLine(max);
// }

// class Parameters
// {
//     public int time;
//     public List<int> list = new List<int>();

//     public Parameters(int time, List<int> list)
//     {
//         this.time = time;
//         this.list = list;
//     }
// // }

// Thread thread = new Thread(new ParameterizedThreadStart(Posadka));
// Thread thread1 = new Thread(new ParameterizedThreadStart(Posadka));
// Thread thread2 = new Thread(new ParameterizedThreadStart(Posadka));
// thread.Start(new FlightInfo("U214",12,3000));
// thread1.Start(new FlightInfo("U215",14,2000));
// thread2.Start(new FlightInfo("U216", 17, 4000));

// void Posadka(object? obj)
// {
//     var i = obj as FlightInfo;
//     System.Console.WriteLine($"на рейс {i.FlightNumber} зашло {i.PassengerCount}");
//     Thread.Sleep(i.Delay);
// }
// class FlightInfo
// {
//     public string FlightNumber { get; set; }
//     public int PassengerCount { get; set; }
//     public int Delay { get; set; }
//     public FlightInfo(string FlightNumber, int PassengerCount, int Delay)
//     {
//         this.FlightNumber = FlightNumber;
//         this.PassengerCount = PassengerCount;
//         this.Delay = Delay;
//     }
// }

using System.Threading;


List<Thread> ships = new List<Thread>()
{
    new Thread(new Ship(5,1,50).Zagruzka),
    new Thread(new Ship(3,2,10).Zagruzka),
    new Thread(new Ship(1,3,60).Zagruzka),
    new Thread(new Ship(5,4,100).Zagruzka),
    new Thread(new Ship(8,5,20).Zagruzka),
    new Thread(new Ship(4,6,30).Zagruzka),
    new Thread(new Ship(5,1,50).shipThroughTonnel),
    new Thread(new Ship(3,2,10).shipThroughTonnel),
    new Thread(new Ship(1,3,60).shipThroughTonnel),
    new Thread(new Ship(5,4,100).shipThroughTonnel),
    new Thread(new Ship(8,5,20).shipThroughTonnel),
    new Thread(new Ship(4,6,30).shipThroughTonnel)
};

foreach (var s in ships) s.Start();



class Ship
{
    public static Semaphore semaphore = new Semaphore(5, 5);
    public static Semaphore semaphore1 = new Semaphore(3, 3);
    public int gruz, id, vmestimost;

    public Ship(int gruz, int id, int vmestimost)
    {
        this.gruz = gruz;
        this.id = id;
        this.vmestimost = vmestimost;
    }

    public void Zagruzka()
    {
        semaphore1.WaitOne();
        System.Console.WriteLine($"корабль {id} начал загрузку");
        Thread.Sleep(1000 * (vmestimost % 10));
        semaphore1.Release();
        System.Console.WriteLine($"корабль под номером {id} был загружен и уехал");
    }

    public void shipThroughTonnel()
    {
        semaphore.WaitOne();
        System.Console.WriteLine($"Корабль {id} вышел в тоннель!");
        Thread.Sleep(1000 * gruz);
        semaphore.Release();
        System.Console.WriteLine($"Корабль {id} выехал...");

    }
}