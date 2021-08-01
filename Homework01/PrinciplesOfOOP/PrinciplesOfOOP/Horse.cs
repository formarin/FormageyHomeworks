using System;

namespace PrinciplesOfOOP
{
    class Horse : Animal
    {
        public override void Checkup()
        {
            Console.WriteLine($"Horse  | {Name,-10}| {Colour}");
        }
    }
}
