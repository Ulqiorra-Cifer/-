using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;

class Program
{
    
    static void Main()
    {
        int numPopulations = 3;       // количество популяций
        int populationSize = 10;      // особей в каждой
        int generations = 5;          // сколько итераций/поколений
        int migrationInterval = 2;    // каждые 2 поколения — миграция

        List<List<neural_network>> populations = new List<List<neural_network>>();

        // --- создаем несколько популяций ---
        for (int p = 0; p < numPopulations; p++)
        {
            List<neural_network> pop = new List<neural_network>();
            for (int i = 0; i < populationSize; i++)
                pop.Add(make_network());
            populations.Add(pop);
        }

        // --- несколько поколений ---
        for (int gen = 0; gen < generations; gen++)
        {
            Console.WriteLine($"\n=== Поколение {gen} ===");

            for (int p = 0; p < populations.Count; p++)
            {
                Console.WriteLine($"\nПопуляция {p}:");

                List<decimal> fitnesses = EvaluatePopulation(populations[p]);
                var bestIndex = fitnesses.IndexOf(fitnesses.Min());
                var bestFitness = fitnesses[bestIndex];
                Console.WriteLine($"Лучший fitness: {bestFitness:F4}");

                // Скрещивание/мутация
                populations[p] = EvolvePopulation(populations[p], fitnesses);
            }

            // --- миграция ---
            if (gen > 0 && gen % migrationInterval == 0)
            {
                Console.WriteLine("\n🌍 Миграция между популяциями!");
                Migrate(populations);
            }
        }
    }

    // --- функция оценки ---
    public static List<decimal> EvaluatePopulation(List<neural_network> population)
    {
        List<decimal> fitnesses = new List<decimal>();
        foreach (var net in population)
        {
            var output = net.forward(new List<decimal> { 6 })[0];
            var fitness = Math.Abs(36.0m - output); // чем ближе к 36, тем лучше
            fitnesses.Add(fitness);
        }
        return fitnesses;
    }

    // --- эволюция внутри популяции ---
    public static List<neural_network> EvolvePopulation(List<neural_network> population, List<decimal> fitnesses)
    {
        var newPop = new List<neural_network>();
        int eliteCount = 2;

        // выбираем лучших
        var bestIndices = fitnesses
            .Select((f, i) => new { f, i })
            .OrderBy(x => x.f)
            .Take(eliteCount)
            .Select(x => x.i)
            .ToList();

        // копируем лучших
        foreach (var idx in bestIndices)
            newPop.Add(population[idx]);

        // скрещиваем остальные
        Random rnd = new Random();
        while (newPop.Count < population.Count)
        {
            var parent1 = population[rnd.Next(eliteCount)];
            var parent2 = population[rnd.Next(population.Count)];

            var child = make_network();
            for (int l = 0; l < child.layers.Count; l++)
            {
                for (int i = 0; i < child.layers[l].weights.Count; i++)
                {
                    for (int j = 0; j < child.layers[l].weights[i].Count; j++)
                    {
                        if (rnd.NextDouble() < 0.5)
                            child.layers[l].weights[i][j] = parent1.layers[l].weights[i][j];
                        else
                            child.layers[l].weights[i][j] = parent2.layers[l].weights[i][j];

                        // мутация
                        if (rnd.NextDouble() < 0.1)
                            child.layers[l].weights[i][j] += (decimal)(rnd.NextDouble() * 0.1 - 0.05);
                    }
                }
            }
            newPop.Add(child);
        }

        return newPop;
    }

    // --- миграция между популяциями ---
    public static void Migrate(List<List<neural_network>> populations)
    {
        // Берем лучших из каждой популяции и пересылаем в следующую
        List<neural_network> bests = new List<neural_network>();
        foreach (var pop in populations)
        {
            var fits = EvaluatePopulation(pop);
            var best = pop[fits.IndexOf(fits.Min())];
            bests.Add(best);
        }

        for (int i = 0; i < populations.Count; i++)
        {
            int next = (i + 1) % populations.Count;
            populations[next][0] = bests[i]; // переселение лучшего
        }
    }

    public static neural_network make_network()
    {
        List<List<decimal>> train_inputs = new List<List<decimal>>()
        {
            new List<decimal>() {1},
            new List<decimal>() {2},
            new List<decimal>() {3},
            new List<decimal>() {4},
            new List<decimal>() {5},
            new List<decimal>() {6},
            new List<decimal>() {7},
            new List<decimal>() {8},
            new List<decimal>() {9},
            new List<decimal>() {10}
        };

        neural_network nn = new neural_network();
        nn.layers.Add(new Layer(train_inputs[0], 5));
        nn.layers.Add(new Layer(5, 1));
        return nn;
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

                decimal output = Relu(currentInput[0]);
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
     public static decimal Relu(decimal x)
    {
        if (x > 0) return x;
        else return 0;
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
