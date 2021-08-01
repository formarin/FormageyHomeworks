using System;

namespace PrinciplesOfOOP
{
    class Horse : Animal, IFollowing
    {
        public override void Checkup()
        {
            Console.WriteLine($"Horse  | {Name,-10}| {Colour}");
        }
        public void Follow(string name)
        {
            Console.WriteLine($"Horse   {Name,9}: *riding..*");
        }
    }
}
