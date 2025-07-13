int a = Convert.ToInt32(Console.ReadLine());
FindMult(a);
FindNum(a, mult);

int FindMult(int a)
{
    int count;
    while (a > 0)
    {
        a = a / 10;
        count++;
    }
    int mult = 1;
    while (count > 0)
    {
        mult *= 10;
        count--;
    }
}

void FindNum(int a,int mult)
{
    int original = 0, reverse = 0;
    original = a;

    while (a > 0)
    {
        int num = a % 10;
        int res = (a - num) / 10;
        a = res;

        reverse += mult * num;
        mult /= 10;

    }
    System.Console.WriteLine($"{reverse} , {original}");
    if (reverse == original)
    {
        System.Console.WriteLine("That's a palindrome!");
    }
    else
    {
        System.Console.WriteLine("That is not polindrome");
    }
}

