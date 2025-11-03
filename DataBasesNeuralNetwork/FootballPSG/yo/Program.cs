decimal weight = (decimal)new System.Random().NextDouble();
List<List<int>> list = new List<List<int>>()
{
    new List<int>() {100, 0},
    new List<int>() {100, 100},
    new List<int>() {100, 100},
    new List<int>() {100, 100},
    new List<int>() {0, 100},
    new List<int>() {100, 0},
    new List<int>() {100, 100},
    new List<int>() {100, 100},
    new List<int>() {100, 100},
};

for (int i = 0; i < 100; i++)
{
    foreach (var item in list)
    {
        var res = neural_network(item[0], weight);
        System.Console.WriteLine($"Прогноз нейросети: {res}, Ожидаемый прогноз: {item[1]}, Ошибка: {Math.Abs(item[1] - res)}");

        var error = item[1] - res;
        if (error > 0)
        {
            weight += 0.01m;
        }
        else
        {
            weight -= 0.01m;
        }
    }
}
System.Console.WriteLine("\n\n\nВведи погоду на сегодня");

System.Console.WriteLine(neural_network(Convert.ToInt32(Console.ReadLine()), weight));

decimal neural_network(int input, decimal weight)
{
    return input * weight;
}
