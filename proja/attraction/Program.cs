Park park = new Park();

Attraction wheel = new Attraction("Wheel", 60, 12, true);
Attraction xz = new Attraction("xz", 25, 23, true);
Attraction nezn = new Attraction("nezn", 35, 20, false);
Attraction helicopter = new Attraction("helicopter", 15, 0, false);
park.Attractions.Add(helicopter);
park.Attractions.Add(wheel);
park.Attractions.Add(nezn);

park.OpenAllAttractions();
park.DisplayAttractions();

wheel.AddVisitors(7);
park.DisplayAttractions();
park.CloseAllAttractions();
park.DisplayAttractions();

class Attraction
{
    public string Name;
    public int Capacity, visitors;
    public bool IsOpen;
    public Attraction(string Name, int Capacity, int visitors, bool IsOpen)
    {
        this.Name = Name;
        this.Capacity = Capacity;
        this.visitors = visitors;
        this.IsOpen = IsOpen;
    }
    public void Open()
    {
        IsOpen = true;
    }
    public void Close()
    {
        IsOpen = false;
    }
    public bool AddVisitors(int count)
    {
        int res = visitors + count;
        if (res > Capacity)
        {
            visitors = res;
            return false;
        }
        else
        {
            visitors = res;

            System.Console.WriteLine(res);
            return true;
        }
    }
    public void ClearVisitors()
    {
        visitors = 0;
    }
    public void GetInfo()
    {
        System.Console.WriteLine($"{Name} capacity: {Capacity}, visitors:{visitors}, is opened: {IsOpen}");
    }

}

class Park
{
    public List<Attraction> Attractions = new List<Attraction>() { };
    public void AddAttraction(Attraction attract)
    {
        Attractions.Add(attract);
    }
    public void RemoveAttraction(string name)
    {
        foreach (var i in Attractions)
        {
            if (i.Name == name)
            {
                Attractions.Remove(i);
                break;
            }

        }
    }
    public void OpenAllAttractions()
    {
        foreach (var i in Attractions)
        {
            i.IsOpen = true;
        }
    }
    public void CloseAllAttractions()
    {
        foreach (var i in Attractions)
        {
            i.IsOpen = false;
        }
    }
    public void DisplayAttractions()
    {
        foreach (var i in Attractions)
        {
            i.GetInfo();
        }
    }
}
