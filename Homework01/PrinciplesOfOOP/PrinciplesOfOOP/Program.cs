using System;

namespace PrinciplesOfOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal goose = new Animal { Name = "Igor'", Colour = "belenkii" };
            Dog dog = new Dog { Name = "Bim", Colour = "black and white" };
            Horse horse = new Horse { Name = "Kel'pie", Colour = "raven" };
            Donkey donkey = new Donkey { Name = "Valerchik", Colour = "brown" };
            var MyAnimals = new Animal[] { goose, dog, horse, donkey };

            Console.WriteLine("\tSo, we have:");
            foreach (var pet in MyAnimals)
            {
                pet.Checkup();
            }

            Console.WriteLine("\n\tAnd now, time to go:");
            goose.Follow(goose.Name);
            dog.Follow(dog.Name);
            horse.Follow(horse.Name);
            donkey.Follow(donkey.Name);

            Console.ReadKey();
        }
    }
}
