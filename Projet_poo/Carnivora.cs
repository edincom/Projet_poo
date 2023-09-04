using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public class Carnivora : Animal
    {
        public Carnivora(double x, double y, double LifeEnergy, int EnergyStorage, bool isMale, double vision, double body, int pregnancy = 0) : base(Colors.Red, x, y, LifeEnergy, EnergyStorage, isMale, vision, body, pregnancy) { }

        List<SimulationObject> simulationObjects = Simulation.objects;


        Random random = new Random();

        public override void Update()
        {
            Move();
            EnergyStorage = EnergyStorage - 10;
            if (EnergyStorage < 90)
            {
                EatMeat();
                KillHerbivora();
            }

            Mate();
            foreach (Carnivora carnivora in simulationObjects.OfType<Carnivora>().Where(carnivora => carnivora.pregnancy > 0).ToList())
            {
                carnivora.pregnancy = carnivora.pregnancy + 1;
                if(carnivora.pregnancy == 10)
                {
                    giveBirth();
                }

            }

            dropOrganicWaste();
            CheckEnergy();


        }


        public void EatMeat()
        {
            foreach (Carnivora carnivora in simulationObjects.OfType<Carnivora>().ToList())
            {
                foreach (Meat meat in simulationObjects.OfType<Meat>().ToList())
                {
                    if (meat.X == carnivora.X && meat.Y == carnivora.Y)
                    {
                        double qualityValue = meat.Quality;
                        int intValue = Convert.ToInt32(qualityValue);
                        carnivora.EnergyStorage = carnivora.EnergyStorage + intValue;
                        simulationObjects.Remove(meat);
                    }
                }
            }
        }

        public void KillHerbivora()
        {
            foreach (Herbivora herbivora in simulationObjects.OfType<Herbivora>().ToList())
            {
                foreach (Carnivora carnivora in simulationObjects.OfType<Carnivora>().ToList())
                {
                    double distance2;
                    double distance;
                    distance2 = Math.Pow(herbivora.X - carnivora.X, 2) + Math.Pow(herbivora.Y - carnivora.Y, 2);
                    distance = Math.Sqrt(distance2);
                    if (distance < carnivora.vision)
                    {
                        carnivora.X = herbivora.X;
                        carnivora.Y = herbivora.Y;
                        carnivora.EnergyStorage += 50;
                        simulationObjects.Remove(herbivora);
                    }
                }
            }
        }


        public override void Mate()
        {
            foreach(Carnivora carnivoraMale in simulationObjects.OfType<Carnivora>().Where(carnivoraMale => carnivoraMale.isMale).ToList())
            {
                foreach (Carnivora carnivoraFemale in simulationObjects.OfType<Carnivora>().Where(carnivoraFemale => !carnivoraFemale.isMale).ToList())
                {
                    if (carnivoraMale.X == carnivoraFemale.X && carnivoraMale.Y == carnivoraFemale.Y && carnivoraFemale.pregnancy == 0)
                    {
                        carnivoraFemale.pregnancy++;
                    }
                }

            }

        }

        public override void giveBirth()
        {
            foreach (Carnivora carnivora in simulationObjects.OfType<Carnivora>().Where(carnivora => carnivora.pregnancy == 10).ToList())
            {
                simulationObjects.Add(new Carnivora(carnivora.X + 10, carnivora.Y + 10, 100, 100, true, 150, 20));
                carnivora.pregnancy = 0;
            }
        }

        public override void Move()
        {
            X = X + random.Next(-40, 40);
            Y = Y + random.Next(-40, 40);
        }



    }
}
