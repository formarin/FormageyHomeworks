using System;

namespace PrinciplesOfOOP
{
    class Donkey : Animal, IFollowing
    {
        public override void Checkup()
        {
            Console.WriteLine($"Donkey | {Name,-10}| {Colour}");
        }
        public void Follow(string name)
        {
            Console.WriteLine($"Donkey  {Name,9}: *standing..*");
        }
    }
}
