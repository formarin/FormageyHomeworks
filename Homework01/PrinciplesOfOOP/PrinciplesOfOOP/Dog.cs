using System;

namespace PrinciplesOfOOP
{
    class Dog : Animal, IFollowing
    {
        public override void Checkup()
        {
            Console.WriteLine($"Dog    | {Name,-10}| {Colour}");
        }
        public void Follow(string name)
        {
            Console.WriteLine($"Dog     {Name,9}: *running near..*");
        }
    }
}
