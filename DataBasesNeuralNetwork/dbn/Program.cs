List <List <int>> list = new List<List<int>>()
{
    new List<int>() {22, 24},
    new List<int>() {24, 26},
    new List<int>() {29, 31},
    new List<int>() {31, 35},
    new List<int>() {26, 29},
    new List<int>() {32, 28},
    new List<int>() {29, 29},
    new List<int>() {25, 30},
    new List<int>() {30, 31},
};

System.Console.WriteLine(neural_network(38, 0.3m));

decimal neural_network(int input, decimal weight)
{
    return input * weight;
}