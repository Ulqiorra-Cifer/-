using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Словарь слов → индекс
        Dictionary<string, int> wordIndex = new Dictionary<string, int>
        {
            // Позитив
            { "отлично", 0 },
            { "классно", 1 },
            { "хорошо", 2 },
            { "супер", 3 },
            { "прекрасно", 4 },
            { "понравилось", 5 },
            { "рекомендую", 6 },
            { "удовлетворен", 7 },

            // Негатив
            { "плохо", 8 },
            { "ужасно", 9 },
            { "отвратительно", 10 },
            { "разочарован", 11 },
            { "не", 12 }, // отдельно, чтоб можно было "не понравилось"
            { "понравилось-", 13 }, // пометим отрицательную форму
            { "хуже", 14 },
            { "проблема", 15 }
        };

        // Пример данных для обучения (векторы слов)
        List<List<decimal>> trainInputs = new List<List<decimal>>
        {
            MakeInput("отлично классно супер", wordIndex),
            MakeInput("понравилось прекрасно", wordIndex),
            MakeInput("рекомендую удовлетворен", wordIndex),
            MakeInput("плохо ужасно", wordIndex),
            MakeInput("разочарован проблема", wordIndex),
            MakeInput("не понравилось", wordIndex),
            MakeInput("хуже отвратительно", wordIndex)
        };

        // 1 = позитив, 0 = негатив
        List<decimal> trainOutputs = new List<decimal>
        {
            1.0m,
            1.0m,
            1.0m,
            -1.0m,
            -1.0m,
            -1.0m,
            -1.0m
        };

        // Создаём и обучаем сеть
        neural_network nn = new neural_network();
        nn.layers.Add(new Layer(new List<decimal>(new decimal[wordIndex.Count]), 5));
        nn.layers.Add(new Layer(5, 4));
        nn.layers.Add(new Layer(4, 3));
        nn.layers.Add(new Layer(3, 2));
        nn.layers.Add(new Layer(2, 1));
        nn.layers.Add(new Layer(1, 1));

        nn.Train(trainInputs, trainOutputs, 2000);

        // Тест
        Console.WriteLine("\nВведите отзыв:");
        string text = Console.ReadLine().ToLower();
        var inp = MakeInput(text, wordIndex);
        var result = nn.forward(inp)[0];
        Console.WriteLine($"Оценка: {result:F3} → {(result >= 0.5m ? "Позитив" : "Негатив")}");
    }

    // Преобразуем текст в вектор "мешок слов"
    static List<decimal> MakeInput(string text, Dictionary<string, int> wordIndex)
    {
        List<decimal> vec = new List<decimal>(new decimal[wordIndex.Count]);
        string[] words = text.ToLower().Split(' ');
        foreach (var w in words)
        {
            if (wordIndex.ContainsKey(w))
                vec[wordIndex[w]] = 1;
            else if (w == "не" && words.Length > 1)
            {
                // Если "не понравилось" — кодируем как отдельное отрицание
                int idx = wordIndex.ContainsKey(words[1] + "-") ? wordIndex[words[1] + "-"] : -1;
                if (idx >= 0) vec[idx] = 1;
            }
        }
        return vec;
    }
}

class Layer
{
    public List<List<decimal>> weights = new List<List<decimal>>();

    public Layer(List<decimal> inputs, int outputs)
    {
        for (int i = 0; i < outputs; i++)
            generate_weights(inputs.Count);
    }

    public Layer(int inputs, int outputs)
    {
        for (int i = 0; i < outputs; i++)
            generate_weights(inputs);
    }

    private void generate_weights(int count)
    {
        List<decimal> W = new List<decimal>();
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
            W.Add((decimal)(rnd.NextDouble() * 0.1)); // маленькие веса
        weights.Add(W);
    }

    public List<decimal> dot_product(List<decimal> inputs)
    {
        List<decimal> output = new List<decimal>();
        for (int i = 0; i < weights.Count; i++)
        {
            decimal sum = 0;
            for (int j = 0; j < inputs.Count; j++)
                sum += inputs[j] * weights[i][j];
            output.Add(sum); // без активации (линейно)
        }
        return output;
    }
}

class neural_network
{
    public List<Layer> layers = new List<Layer>();
    private decimal learningRate = 0.05m;

    public List<decimal> forward(List<decimal> inputs)
    {
        List<decimal> res = inputs;
        foreach (var layer in layers)
            res = layer.dot_product(res);
        return res;
    }

    public void Train(List<List<decimal>> trainInputs, List<decimal> trainOutputs, int epochs)
    {
        for (int epoch = 0; epoch < epochs; epoch++)
        {
            decimal totalError = 0;
            for (int sample = 0; sample < trainInputs.Count; sample++)
            {
                // Прямой проход
                List<List<decimal>> layerInputs = new List<List<decimal>>();
                List<decimal> currentInput = trainInputs[sample];
                layerInputs.Add(currentInput);

                foreach (var layer in layers)
                {
                    currentInput = layer.dot_product(currentInput);
                    layerInputs.Add(currentInput);
                }

                decimal output = Tanh(currentInput[0]);
                decimal target = trainOutputs[sample];
                decimal error = target - output;
                totalError += error * error;

                // Градиент на выходном слое
                List<decimal> grad = new List<decimal> { error * output * (1 - output) };

                // Обратный проход
                for (int i = layers.Count - 1; i >= 0; i--)
                {
                    var layer = layers[i];
                    var inputsToLayer = layerInputs[i];

                    // Обновляем веса
                    for (int neuron = 0; neuron < layer.weights.Count; neuron++)
                    {
                        for (int w = 0; w < layer.weights[neuron].Count; w++)
                        {
                            layer.weights[neuron][w] += learningRate * grad[neuron] * inputsToLayer[w];
                        }
                    }

                    // Считаем градиенты для предыдущего слоя
                    if (i > 0)
                    {
                        List<decimal> prevGrad = new List<decimal>(new decimal[layer.weights[0].Count]);
                        for (int w = 0; w < prevGrad.Count; w++)
                        {
                            decimal sum = 0;
                            for (int neuron = 0; neuron < layer.weights.Count; neuron++)
                            {
                                sum += grad[neuron] * layer.weights[neuron][w];
                            }
                            prevGrad[w] = sum; // для линейного слоя
                        }
                        grad = prevGrad;
                    }
                }
            }

            if (epoch % 100 == 0)
                Console.WriteLine($"Epoch {epoch}, Error: {totalError:F6}");
        }
    }
    static decimal Tanh(decimal x)
    {
    double xd = (double)x;
    double ex1 = Math.Exp(xd);
    double ex2 = Math.Exp(-xd);
    return (decimal)((ex1 - ex2) / (ex1 + ex2));
    }
}
