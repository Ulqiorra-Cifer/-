// List<int> x = new List<int>(){4, 3, -1, -8, 3, -2, 4};
// List<int> y = new List<int>();
// y.Add(x[0]);
// y.Add(x[1] + x[0]);
// for (int i = 2; i < x.Count(); i++)
// {
//     y.Add(max(y[i - 1], y[i - 2]) + x[i]);
// }

// System.Console.WriteLine(y[y.Count() - 1]);

// int max(int a, int b) => a > b ? a : b;




int[] ints = new int[] { 11, 15, 2, 7 };
int target = Convert.ToInt32(Console.ReadLine());
System.Console.WriteLine(TwoSum(ints, target)[0]);


int[] TwoSum(int[] nums, int target) {


    Dictionary <int,int> dictionary = new Dictionary <int, int>();


    for (int i = 0; i < nums.Count(); i++)
    {
        var comp = target - nums[i];

        if (dictionary.ContainsKey(comp)) {
            System.Console.WriteLine($"{dictionary[comp]} {i}");
            return new int[] {dictionary[comp], i};
        }
        else 
            dictionary[nums[i]] = i;
    }

    return new int[] {0,0};
}