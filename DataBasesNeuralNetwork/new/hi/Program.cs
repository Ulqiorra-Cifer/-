neural_network neural_Network = new neural_network();
neural_Network.layers.Add(new Layer(new List<decimal> { 1.2m, 4.5m, 1.4m }, 4));
neural_Network.layers.Add(new Layer(4, 4));
neural_Network.layers.Add(new Layer(4, 4));
neural_Network.layers.Add(new Layer(4, 1));

System.Console.WriteLine(neural_Network.result());

class Layer
{
    List<decimal> inputs = new List<decimal>();
    List<List<decimal>> weights = new List<List<decimal>>();

    public Layer(List<decimal> inputs, List<List<decimal>> weights)
    {
        this.inputs = inputs;
        this.weights = weights;
    }

    public Layer(List<decimal> inputs, int outputs)
    {
        this.inputs = inputs;

        for (int i = 0; i < outputs; i++)
            generate_weights();
    }

    public Layer(int n, int outputs)
    {
        for (int i = 0; i < outputs; i++)
            generate_weights(n);
    }

    private void generate_weights()
    {
        List<decimal> W = new List<decimal>();
        for (int i = 0; i < inputs.Count; i++) W.Add((decimal)new System.Random().NextDouble());

        weights.Add(W);
    }
    
    private void generate_weights(int I)
    {
        List<decimal> W = new List<decimal>();
        for (int i = 0; i < I; i++) W.Add((decimal)new System.Random().NextDouble());

        weights.Add(W);
    }

    public void show_inputs()
    {
        for (int i = 0; i < weights.Count; i++)
        {
            for (int j = 0; j < inputs.Count; j++)
            {
                System.Console.Write($"{weights[i][j]}, ");
            }
            System.Console.WriteLine();
        }
    }

    public void show_weights()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            System.Console.WriteLine(inputs[i]);
        }
    }
    public List<decimal> dot_product()
    {
        List<decimal> output = new List<decimal>();

        for (int i = 0; i < weights.Count; i++)
        {
            decimal result = 0.0m;

            for (int j = 0; j < inputs.Count; j++)
            {
                result += inputs[j] * weights[i][j];
            }

            output.Add(result);
        }

        return output;
    }

    public List<decimal> dot_product(List<decimal> I)
    {
        List<decimal> output = new List<decimal>();

        for (int i = 0; i < weights.Count; i++)
        {
            decimal result = 0.0m;

            for (int j = 0; j < I.Count; j++)
            {
                result += I[j] * weights[i][j];
            }

            output.Add(result);
        }

        return output;
    }
}

class neural_network
{
    public List<Layer> layers = new List<Layer>();

    public decimal result()
    {
        var final = new List<decimal>();
        var res = new List<decimal>();

        for (int i = 0; i < layers.Count; i++)
        {
            if (i == 0)
                res = layers[i].dot_product();
            else
            {
                res = layers[i].dot_product(res);
            }
            if (i == layers.Count - 1) final = res;
        }

        return final[0];
    }
}