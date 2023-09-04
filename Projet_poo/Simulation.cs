namespace Projet_poo
{
    public class Simulation : IDrawable
    {
        public static List<SimulationObject> objects;

        public Simulation()
        {
            objects = new List<SimulationObject>();
            objects.Add(new Carnivora(120, 250, 110, 100, true, 100, 30));
            objects.Add(new Carnivora(520, 250, 110, 100, false, 100, 30));
            objects.Add(new Herbivora(50, 200, 150, 100, true, 40, 30)) ;
            objects.Add(new Meat(300, 300));
            objects.Add(new OrganicWaste(70, 100));
            objects.Add(new Plant(400, 400));

        }

        public void Update()
        {
            foreach (SimulationObject drawable in objects.ToList())
            {
                drawable.Update();
            }
        }


        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (SimulationObject drawable in objects.ToList())
            {
                canvas.FillColor = drawable.Color;

                if (drawable is Carnivora carnivora)
                {
                    canvas.FillCircle(new Point(drawable.X, drawable.Y), carnivora.body);
                    canvas.DrawCircle(new Point(drawable.X, drawable.Y), carnivora.vision);


                }

                if (drawable is Herbivora herbivora)
                {
                    canvas.FillCircle(new Point(drawable.X, drawable.Y), herbivora.body);
                    canvas.DrawCircle(new Point(drawable.X, drawable.Y), herbivora.vision);

                }

                if (drawable is OrganicWaste)
                {
                    float Xvalue = Convert.ToSingle(drawable.X);
                    float Yvalue = Convert.ToSingle(drawable.Y);
                    canvas.FillRectangle(Xvalue, Yvalue, 10, 15);

                }


                if (drawable is Plant)
                {
                    float Xvalue = Convert.ToSingle(drawable.X);
                    float Yvalue = Convert.ToSingle(drawable.Y);
                    canvas.FillRectangle(Xvalue, Yvalue, 30, 20);
                    //canvas.DrawCircle(new Point(drawable.X, drawable.Y), plant.RootZone);


                }

                if (drawable is Meat)
                {
                    float Xvalue = Convert.ToSingle(drawable.X);
                    float Yvalue = Convert.ToSingle(drawable.Y);
                    canvas.FillRectangle(Xvalue, Yvalue, 10, 15);

                }



            }
        }

    }
}
