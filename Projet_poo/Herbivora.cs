using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public class Herbivora : Animal
    {
        public Herbivora(double x, double y, double LifeEnergy, int EnergyStorage, bool isMale, double vision, double body, int pregnancy = 0) : base(Colors.Green, x, y, LifeEnergy, EnergyStorage, isMale, vision, body, pregnancy) { }

        Random random = new Random();

        List<SimulationObject> simulationObjects = Simulation.objects;



        public override void Update()
        {
            Move();

            EnergyStorage = EnergyStorage - 10;
            if (EnergyStorage < 90)
            {
                EatPlant();
            }

            dropOrganicWaste();
            CheckEnergy();


        }


        public void EatPlant()
        {
            foreach (Herbivora herbivora in simulationObjects.OfType<Herbivora>().ToList())
            {
                foreach (Plant plant in simulationObjects.OfType<Plant>().ToList())
                {
                    if (plant.X == herbivora.X  && plant.Y == herbivora.Y)
                    {
                        herbivora.EnergyStorage = herbivora.EnergyStorage + plant.LifeEnergy;
                        simulationObjects.Remove(plant);
                    }
                }
            }
        }

        public override void Mate()
        {
            foreach (Herbivora herbivoraMale in simulationObjects.OfType<Herbivora>().Where(herbivoraMale => herbivoraMale.isMale).ToList())
            {
                foreach (Herbivora herbivorAFemale in simulationObjects.OfType<Herbivora>().Where(herbivoraFemale => herbivoraFemale.isMale).ToList())

                {

                }

            }
        }


        public override void giveBirth()
        {
            
        }

        public override void Move()
        {
            X = X + random.Next(-40, 40);
            Y = Y + random.Next(-40, 40);

        }

    }
}
