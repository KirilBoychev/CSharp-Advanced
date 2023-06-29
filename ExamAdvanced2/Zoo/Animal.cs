using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double lenght;

        public string Species
        {
            get { return species; }
            set { species = value; }
        }
        
        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }

        public double Weight
        {
            get { return weight; }
            set {  weight = value; }
        }

        public double Lenght
        {
            get {  return lenght; }
            set { lenght = value; }
        }

        public Animal(string species, string diet, double weight, double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Lenght = length;
        }

        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
