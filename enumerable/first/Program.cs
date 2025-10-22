using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Person Tom = new Person("Tom", 20);

        foreach (var i in Tom)
        {
            Console.WriteLine(i);
        }
    }
}

class Person : IEnumerable<int>
{
    public string name;
    public int age;
    public List<int> ages;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        ages = new List<int>() { 54, 12, 3, 7, 2 };
    }

    public IEnumerator<int> GetEnumerator()
    {
        return ages.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}