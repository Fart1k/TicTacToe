namespace TicTacToe.Pages;

public partial class ModePage : ContentPage
{
	public ModePage()
	{
		Title = "Vali mängurežiim";

		Content = new VerticalStackLayout
		{
			Padding = 30,
			Spacing = 20,
			Children =
			{
				new Label
				{
					Text = "Vali mängurežiim",
					FontSize = 32,
					HorizontalOptions = LayoutOptions.Center
				},

				new Button
				{
					Text = "Tehisintellektiga",
					Command = new Command(async () =>
					{
						await DisplayAlertAsync(Title, "Tehisintellektiga mängurežiim pole veel saadaval.", "OK");
					})
                },

				new Button
				{
					Text = "Kahe mängijaga",
					Command = new Command(async () =>
					{
						await Navigation.PushAsync(new GamePage(false));
					})
                }
            }
        };
    }
}