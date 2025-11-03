using System.Runtime.ExceptionServices;

double rast(List <double> first, List <double> second)
{
    double sum = 0;
    for (int i = 0; i < first.Count; i++)
    {
        sum += Math.Pow(first[0] - second[0], 2);
    }

    return Math.Sqrt(sum);
}

List<List<double>> Cars = new List<List<double>>() { };

var dictionary = new Dictionary<string, List<List<double>>>
{
    { "RENO LOGAN", new List<List<double>> {
        new List<double> {1, 3,122000},
        new List<double> {1.2, 3.1,99430},
        new List<double> {1.1, 3.5,113450}
    }},
    
    { "Bugatti", new List<List<double>> {
        new List<double> {10, 10,10000},
        new List<double> {10.2, 10.9,7320},
        new List<double> {10.12, 10.15,8900}
    }},
    
    { "Porsche", new List<List<double>> {
        new List<double> {6, 8,43000},
        new List<double> {6.4, 8.8,38500},
        new List<double> {6.9, 8.1,45330}
    }},
    
    { "Kia K5", new List<List<double>> {
        new List<double> {3, 3,250000},
        new List<double> {3.4, 3.7,212600},
        new List<double> {3.25, 3.81,173200}
    }}
};


System.Console.WriteLine("Enter three numbers");
var x = Convert.ToDouble(Console.ReadLine());
var y = Convert.ToDouble(Console.ReadLine());
var z = Convert.ToDouble(Console.ReadLine());
double min = 1000000;
string R = "";

foreach (var k in dictionary.Keys)
{
    string current = k;

    foreach (var c in dictionary[k])
    {
        double res = (rast(new List<double>() { x, y, z }, new List<double>() { c[0], c[1], c[2]}));
        if (res < min)
        {
            min = res;
            R = current;
        }
    }
}


System.Console.WriteLine(R);



