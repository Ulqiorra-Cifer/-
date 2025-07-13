
EspressoCreator espressoCreator = new EspressoCreator();
AmericanoCreator americanoCreator = new AmericanoCreator();
KapuccinoCreator kapuccinoCreator = new KapuccinoCreator();

var esp = kapuccinoCreator.product();
esp.prepare();


interface IStartegy
{
    public void Algorithm();
}

class Coffee
{
    string name;
    IStartegy startegy;

    public Coffee(string name, IStartegy startegy)
    {
        this.name = name;
        this.startegy = startegy;
    }

    public void prepare()
    {
        startegy.Algorithm();
    }

    public void changeStrategy(IStartegy startegy)
    {
        this.startegy = startegy;
    }
}

class Espresso : IStartegy
{
    public void Algorithm()
    {
        System.Console.WriteLine("быстрое приготовление при высоком давлении.");
    }
}

class Americano : IStartegy
{
    public void Algorithm()
    {
        System.Console.WriteLine("медленное заваривание через фильтр.");
    }
}

class Kapuccino : IStartegy
{
    public void Algorithm()
    {
        System.Console.WriteLine("настаивание молотого кофе в воде с последующим прессованием.");
    }
}

interface NormalBrewStrategy : IStartegy
{
    public void Algorithm()
    {
        System.Console.WriteLine("обычная варка кофе");
    }
}

interface FastBrewStrategy : IStartegy
{
    public void Algorithm()
    {
        System.Console.WriteLine("быстрая варка кофе");
    }
}

abstract class Creator
{
    public abstract Coffee product();

}
class EspressoCreator : Creator
{
    private Coffee res;
    public EspressoCreator()
    {
        res = new Coffee("Zakaz 180",new Espresso());
    }
    public override Coffee product() => res;
}

class AmericanoCreator : Creator
{
    private Coffee res;
    
    public AmericanoCreator()
    {
        res = new Coffee("Zakaz 200",new Americano());
    }
    public override Coffee product() => res;
}

class KapuccinoCreator : Creator
{
    private Coffee res;
    public KapuccinoCreator()
    {
        res = new Coffee("Zakaz 250",new Kapuccino());
    }
    public override Coffee product() => res;
}