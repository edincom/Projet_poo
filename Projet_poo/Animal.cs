using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public abstract class Animal : SimulationObject
    {
        List<SimulationObject> simulationObjects = Simulation.objects;

        public double LifeEnergy { get; set; }
        public int EnergyStorage { get; set; }
        public bool isMale { get; set; }
        public double vision { get; set; }
        public int pregnancy { get; set; }
        public double body { get; set; }

        public Animal(Color color, double x, double y, double LifeEnergy, int EnergyStorage, bool isMale, double vision, double body, int pregnancy) : base(color, x, y) 
        {
            this.LifeEnergy = LifeEnergy;
            this.EnergyStorage = EnergyStorage;
            this.isMale = isMale;
            this.vision = vision;
            this.pregnancy = pregnancy;
            this.body = body;
        }

        Random random = new Random();



        public override void Update()
        {
            dropOrganicWaste();

        }


        abstract public void Mate();
        abstract public void giveBirth();

        abstract public void Move();

        public void dropOrganicWaste()
        {
            foreach(Animal animal in simulationObjects.OfType<Animal>().ToList())
            {
                if (random.Next(-15, 15) == 0)
                {
                    simulationObjects.Add(new OrganicWaste(animal.X, animal.Y));
                }
            }
        }

        public void CheckEnergy()
        {
            foreach (Animal animal in simulationObjects.OfType<Animal>().ToList())
            {
                if (animal.EnergyStorage == 0)
                {
                    animal.LifeEnergy -= 10;
                    animal.EnergyStorage = 100;
                }

                if (animal.LifeEnergy == 0)
                {
                    simulationObjects.Remove(animal);
                    simulationObjects.Add(new Meat(animal.X, animal.Y));
                }

            }

        }






    }
}
