class Program
{
    static void Main(string[] args)
    {
        List<Fish> list = new List<Fish>();
        Fish fish1 = new Fish();
        Fish fish2 = new Fish();
        //simplified version of instantiating object of Fish
        Fish fish3 = new();
        Fish fish4 = new();
        Fish fish5 = new();
        Fish fish6 = new();

        list.AddRange([fish1, fish2, fish3, fish4, fish5, fish6]);

        Aquarium aquarium = new Aquarium(9);
        Console.WriteLine("Max capacity of the aquarium is " + aquarium.Capacity);

        while (list.Count < aquarium.Capacity && list.Count > 0)
        {
            Breed(list);
            Console.WriteLine("Now aquarium has " + list.Count + " fish in total.");

            List<Task> tasks = new List<Task>();
            foreach (var fish in list)
            {
                tasks.Add(Task.Run(() => Move(fish)));
            }
            Task.WaitAll(tasks.ToArray());

            list.RemoveAll(fish => IsDead(fish));

            Console.WriteLine("Continue................................");
        }
        System.Console.WriteLine("========================================");
        string str = list.Count > 1 ? "Finished aquarium is full " : "Finished all fish are dead";
        Console.WriteLine(str + "....................");
        System.Console.WriteLine("========================================");
    }

    public static void Move(Fish fish)
    {
        fish.NextLocation();
        System.Console.WriteLine("new location: \n" + fish.ToString() + "\n========================================");
    }

    public static bool IsDead(Fish fish)
    {
        if (fish.IsDead)
        {
            Console.WriteLine(fish.ToString() + " is dead....\n");
            return true;
        }
        return false;
    }
    public static void Breed(List<Fish> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                var result = list[i].CompareTo(list[j]);
                //even if we have 3 or more fishes, only one pair will breed 
                if (result == 0 && list[i].gender != list[j].gender && !(list[i].IsDead || list[j].IsDead))
                {
                    Console.WriteLine("\nFound a match...........................");
                    Console.WriteLine(list[i].ToString() + "\n========================================\n" + list[j].ToString());
                    Console.WriteLine("\nnew fish is born: ");
                    Fish f = list[i];
                    f.maxLifeCycle = new Random().Next(1, 11);
                    list.Add(f);
                    Console.WriteLine(f.ToString());
                    return;
                }
            }
        }
        System.Console.WriteLine("No match is found.......................");
    }
}
