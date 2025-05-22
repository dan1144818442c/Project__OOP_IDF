using System;

namespace Project_idf___
{
    abstract public  class Target
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsDestroyed { get; private set; } = false;

        public Target(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public void Destroy()
        {
            if (!IsDestroyed)
            {
                IsDestroyed = true;
                Console.WriteLine($"Target '{Name}' at '{Location}' has been destroyed.");
            }
            else
            {
                Console.WriteLine($"Target '{Name}' is already destroyed.");
            }
        }
    }
}
