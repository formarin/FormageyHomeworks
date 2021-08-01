using System;

namespace PrinciplesOfOOP
{
    class Animal 
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public virtual void Checkup()
        {
            Console.WriteLine($"Animal | {Name,-10}| {Colour}");
        }
    }
}
