using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public class Plant : SimulationObject
    {

        public int LifeEnergy;
        public double RootZone;
        public double SowingZone;

        public Plant(double x, double y, int LifeEnergy = 111, double RootZone = 300, double sowingZone = 50) : base(Colors.Green, x, y)
        {
            this.LifeEnergy = LifeEnergy;
            this.RootZone = RootZone;
            this.SowingZone = sowingZone;
        }

        List<SimulationObject> simulationObjects = Simulation.objects;
        Random random = new Random();



        public override void Update()
        {
            GetNutrients();
            SeedSpreading();
        }

        public void GetNutrients()
        {
            foreach (Plant plant in simulationObjects.OfType<Plant>().ToList())
            {
                foreach (OrganicWaste waste in simulationObjects.OfType<OrganicWaste>().ToList())
                {
                    double distance2;
                    double distance;
                    distance2 = Math.Pow(plant.X - waste.X, 2) + Math.Pow(plant.Y - waste.Y, 2);
                    distance = Math.Sqrt(distance2);

                    if (distance < plant.RootZone)
                    {
                        plant.LifeEnergy = plant.LifeEnergy + 100;
                        simulationObjects.Remove(waste);
                    }
                }
            }
        }

        public void SeedSpreading()
        {
            foreach(Plant plant in  Simulation.objects.OfType<Plant>().ToList())
            {
                if (plant.LifeEnergy > 150)
                {
                    double newX;
                    double newY;
                    double theta = random.Next(0, 360);
                    int randomValue = random.Next(0, 11);
                    double value = (randomValue / 10);
                    newX = plant.X + SowingZone * Math.Cos(theta) * value;
                    newY = plant.Y + SowingZone * Math.Sin(theta) * value;

                    for(int i = 0; i < random.Next(0, 6); i++)
                    {
                        simulationObjects.Add(new Plant(newX, newY));
                    }

                    plant.LifeEnergy = 10;

                }
            }
        }

    }
}
