using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<List<decimal>> train_inputs = new List<List<decimal>>()
        {
            new List<decimal>() {10.0m, 30.0m},
            new List<decimal>() {25.0m, 50.0m},
            new List<decimal>() {5.0m, 80.0m},
            new List<decimal>() {20.0m, 80.0m},
            new List<decimal>() {-1.0m, 100.0m},
            new List<decimal>() {7.0m, 100.0m},
            new List<decimal>() {90.0m, 0.0m},
        };

        // 1 = позитив, 0 = негатив
        List<decimal> trainOutputs = new List<decimal>
        {
            1.0m,
            0.0m,
            1.0m,
            0.0m,
            1.0m,
            1.0m,
            0.0m
        };

        // Создаём и обучаем сеть
        neural_network nn = new neural_network();
        nn.layers.Add(new Layer(train_inputs[0], 5));
        nn.layers.Add(new Layer(5, 5));
        nn.layers.Add(new Layer(5, 5));
        nn.layers.Add(new Layer(5, 5));

        nn.layers.Add(new Layer(5, 1));


        nn.Train(train_inputs, trainOutputs, 400);

        // Тест
         Console.WriteLine("\nВведите temperature:");

        List<decimal> inp = new List<decimal>()
        {
            Convert.ToDecimal(Convert.ToDouble(Console.ReadLine())),
            Convert.ToDecimal(Convert.ToDouble(Console.ReadLine()))
        };

         var result = neural_network.Sigmoid(nn.forward(inp)[0]);
         Console.WriteLine($"Оценка: {result:F3} → {(result >= 0.5m ? "ON" : "OFF")}");
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

                decimal output = Sigmoid(currentInput[0]);
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

     public static decimal Sigmoid(decimal x)
    {
        return 1m / (1m + Exp(-x));
    }

    public static decimal Exp(decimal x, int terms = 30)
    {
        decimal result = 1m;
        decimal term = 1m;

        for (int i = 1; i < terms; i++)
        {
            term *= x / i;
            result += term;
        }

        return result;
    }
}
