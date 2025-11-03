// decimal weight = (decimal)new System.Random().NextDouble();
// List<List<int>> list = new List<List<int>>()
// {
//     new List<int>() {22, 24},
//     new List<int>() {24, 26},
//     new List<int>() {29, 31},
//     new List<int>() {31, 35},
//     new List<int>() {26, 29},
//     new List<int>() {32, 28},
//     new List<int>() {29, 29},
//     new List<int>() {25, 30},
//     new List<int>() {30, 31},
// };


// for (int i = 0; i < 30; i++)
// {
//     foreach (var item in list)
//     {
//         var res = neural_network(item[0], weight);
//         System.Console.WriteLine($"Прогноз нейросети: {res}, Ожидаемый прогноз: {item[1]}, Ошибка: {Math.Abs(item[1] - res)}");

//         var error = item[1] - res;
//         if (error > 0)
//         {
//             weight += 0.01m;
//         }
//         else
//         {
//             weight -= 0.01m;
//         }
//     }
// }

// System.Console.WriteLine("\n\n\nВведи погоду на сегодня");
// System.Console.WriteLine(neural_network(Convert.ToInt32(Console.ReadLine()), weight));


// decimal neural_network(int input, decimal weight)
// {
//     return input * weight;
// }

//Заполняем массив весов случайными весами
List<decimal> weights = new List<decimal>();

for (int i = 0; i < 3; i++)
{
    weights.Add((decimal)new System.Random().NextDouble());
}


//Температура, давление, влажность
List<List<int>> inputs = new List<List<int>>()
{
    new List<int>() {3, 6, 69},
    new List<int>() {-1, 8,86},
    new List<int>() {6, 7,78},
    new List<int>() {4, 5,58},
    new List<int>() {0, 14,85},
    new List<int>() {6,11,79 },
    new List<int>() {7,12,46 },
    new List<int>() {-5,5,62 },
    new List<int>() {-9,13,80 },
};

List<decimal> outputs = new List<decimal>()
{
    0.5m,
    1.0m,
    -0.25m,
    1.0m,
    2.5m,
    2.5m,
    2.25m,
    5.25m,
    -2.5m
};


for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < inputs.Count; j++)
    {
        var res = neural_network(inputs[j], weights);

        System.Console.WriteLine($"Прогноз нейросети: {res}, Ожидаемый прогноз: {outputs[j]}, Ошибка: {Math.Abs(outputs[j] - res)}");

        var error = outputs[j] - res;

        if (error > 0)
        {
            for (int k = 0; k < weights.Count; k++) weights[k] += 0.1m;
        }
        else
        {
            for (int k = 0; k < weights.Count; k++) weights[k] -= 0.1m;
        }
    }
}

System.Console.WriteLine("\n\n\nВведи погоду на сегодня");
System.Console.WriteLine(neural_network(new List<int>() { Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()) }, weights));

//Реализация скалярного произведения
decimal neural_network(List<int> inputs, List<decimal> weights)
{
    decimal result = 0.0m;

    for (int i = 0; i < weights.Count; i++)
    {
        result += weights[i] * inputs[i];
    }

    return result;
}
