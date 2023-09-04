using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public class Meat : SimulationObject
    {
        public double Quality;
        List<SimulationObject> simulationObjects = Simulation.objects;


        public Meat(double x, double y, double Quality = 180): base(Colors.Red, x, y)
        {
            this.Quality = Quality;
        }

        public override void Update()
        {
            Quality = Quality - 20;
            Expire();
        }


        public void Expire()
        {
            foreach (Meat meat in simulationObjects.OfType<Meat>().ToList())
            {
                if (meat.Quality == 0)
                {
                    simulationObjects.Remove(meat);
                    simulationObjects.Add(new OrganicWaste(meat.X, meat.Y));
                }
            }
        }



    }
}
