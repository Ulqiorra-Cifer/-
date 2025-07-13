Person person = new Person();
person.age = Convert.ToInt32(Console.ReadLine()); //set вызывается тогда, когда происходиь присванивание

System.Console.WriteLine(person.age); //get вызываетсято гда когда мы вызываем

class Person
{

    private int Age;
    public int age
    {
        get
        {
            return Age;
        }
        set
        {
            if (value > 0) Age = value;
            else Age = 0;
        }
    }
}