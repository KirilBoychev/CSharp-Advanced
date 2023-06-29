
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Zoo
    {
        List<Animal> animals;
        private string name;
        private int capacity;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }

        public Zoo(string name, int capacity)
        {
            this.Capacity = capacity;
            this.Name = name;
            this.animals = new List<Animal>();
            this.Animals = animals;
        }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (animals.Count >= this.Capacity)
            {
                return "The zoo is full.";
            }
            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int counter = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Species == species)
                {
                    animals.Remove(animals[i]);
                    i--;
                    counter++;
                }
            }
            return counter;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> currOne = new List<Animal>();
            foreach (var animalll in animals)
            {
                if (animalll.Diet == diet)
                {
                    currOne.Add(animalll);
                }
            }
            return currOne;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal firstOne = null;
            foreach (var animalll in animals)
            {
                if (animalll.Weight == weight)
                {
                    firstOne = animalll;
                    break;
                }
            }
            return firstOne;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int counter = 0;
            foreach (var animall in animals)
            {
                if (animall.Lenght >= minimumLength && animall.Lenght <= maximumLength)
                {
                    counter++;
                }
            }
            return $"There are {counter} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
