﻿namespace Projet_poo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Parameter());
	}
}

