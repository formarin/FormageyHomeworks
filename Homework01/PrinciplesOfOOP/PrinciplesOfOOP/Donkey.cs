using System;

namespace PrinciplesOfOOP
{
    class Donkey : Animal
    {
        public override void Checkup()
        {
            Console.WriteLine($"Donkey | {Name,-10}| {Colour}");
        }
    }
}
