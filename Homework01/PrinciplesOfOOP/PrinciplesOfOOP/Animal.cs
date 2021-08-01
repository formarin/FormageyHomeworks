using System;

namespace PrinciplesOfOOP
{
    class Animal : IFollowing
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public virtual void Checkup()
        {
            Console.WriteLine($"Animal | {Name,-10}| {Colour}");
        }
        public void Follow(string name)
        {
            Console.WriteLine($"Animal  {Name,9}: *riding in a cart..*");
        }
    }
}
