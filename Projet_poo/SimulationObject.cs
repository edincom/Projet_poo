using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_poo
{
    public abstract class SimulationObject : DrawableObjects
    {
        public SimulationObject(Color color, double x, double y) : base(color, x, y) { }

        abstract public void Update();
    }
}
