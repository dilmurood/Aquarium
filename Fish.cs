public class Fish : Location, IComparable<Fish>
{
    private readonly Random random = new Random();
    public int maxLifeCycle { get; set; }
    public bool IsDead = false;
    public Gender gender;
    public Fish()
    {
        maxLifeCycle = random.Next(1, 11);
        gender = (Gender)random.Next(2);
        Console.WriteLine(ToString());
        Console.WriteLine("========================================");
    }
    public void NextLocation()
    {
        maxLifeCycle--;
        if(maxLifeCycle <= 0)
            IsDead = true;
        UpdateLocation();
    }
    public override string ToString()
    {
        return $"x - {X}, y - {Y}, z - {Z} \nmax life - {maxLifeCycle} \nIsDead? {IsDead} \ngender - {gender}";
    }
  public int CompareTo(Fish? other)
    {
        if(other is null)
            throw new ArgumentNullException(nameof(other), "The 'other' argument cannot be null.");

        if (X != other.X || Y != other.Y || Z != other.Z)
            return -1;
        
        return 0;
    } 
}