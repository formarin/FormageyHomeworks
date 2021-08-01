using System;

namespace PrinciplesOfOOP
{
    class Dog : Animal
    {
        public override void Checkup()
        {
            Console.WriteLine($"Dog    | {Name,-10}| {Colour}");
        }
    }
}
