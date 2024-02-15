public abstract class Location
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    private readonly Random random = new Random();
    public Location()
    {
        X = random.Next(2);
        Y = random.Next(2);
        Z = random.Next(2);
    }

    public void UpdateLocation()
    {
        X = random.Next(2);
        Y = random.Next(2);
        Z = random.Next(2);
    }
}