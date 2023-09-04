namespace Projet_poo;

public partial class Parameter : ContentPage
{
    IDispatcherTimer timer;
    Simulation simulation;

    public Parameter()
	{
		InitializeComponent();

        simulation = Resources["simulation"] as Simulation;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += this.OnTimeEvent;
        timer.Start();
    }


    private void OnTimeEvent(object source, EventArgs eventArgs)
    {
        simulation.Update();
        graphics.Invalidate();

    }
}