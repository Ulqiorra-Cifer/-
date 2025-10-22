Client[] clients = new Client[]
{
    new Client("A.C.Akzhol", "DFGH982635", 78345.79),
    new Client("B.D.Arina", "MNBK0183479", 34545.79),
    new Client("T.Y.Temir", "DFGH982635", 150000.0)
};
Client.Transfer(ref clients[0], ref clients[1], 3000.0);

foreach (var i in clients)
{
    i.Info();
}

struct Client
{
    public string FullName, AccountID;
    public double balance;

    public Client(string FullName, string AccountID, double balance)
    {
        this.FullName = FullName;
        this.AccountID = AccountID;
        this.balance = balance;
    }
    public void Info()
    {
        System.Console.WriteLine($"Fullname: {FullName}, Acccount: {AccountID}, Balance:{balance}");
    }

    public static void Transfer(ref Client from, ref Client to, double amount)
    {
        from.balance -= amount;
        to.balance += amount;
        return;
    }
}