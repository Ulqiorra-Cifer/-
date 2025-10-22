List<Person> persons = new List<Person>
{
    new Person("John", 13, "Kalykan"),
    new Person("Kaly", 35, "Baizorov"),
    new Person("Tom", 42, "Ahahov"),
    new Person("Vlad", 1, "Eeeov"),
};

// foreach (Person person in persons.Where(x => x.age > 20).OrderByDescending(x => x.age).ToList())
// {
//     System.Console.WriteLine(person.name);
// }


foreach (Person person in persons.Select(x => x.clone("kupkov")).OrderByDescending(x=>x.name).ToList())
{
    System.Console.WriteLine($"{person.name} {person.age} {person.surname}");
}

class Person
{
    private static int id;
    public int ID;
    public string name;
    public int age;
    public string surname;

    public Person(string name, int age)
    {
        id++;
        ID = id;

        this.name = name;
        this.age = age;
    }

    public Person(string name, int age, string surname)
    {
        id++;
        ID = id;

        this.name = name;
        this.age = age;
        this.surname = surname;
    }


    public Person clone(string surname) => new Person(this.name, this.age,surname);
}