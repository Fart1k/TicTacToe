namespace TicTacToe.Pages;

public partial class RulesPage : ContentPage
{
	Label titleLabel;
	Label rulesLabel;
    public RulesPage()
	{
		Title = "Reeglid";

		titleLabel = new Label
		{
			Text = "Reeglid",
			FontSize = 32,
			HorizontalOptions = LayoutOptions.Center
        };

		rulesLabel =new Label
		{
			Text = "Trips-Traps-Trull on klassikaline lauamäng, kus mängijad üritavad järjestada kolm oma sümbolit (X või O) ritta, veergu või diagonaali. Mängijad vahetavad käike, kuni üks neist saavutab kolm järjestikust sümbolit või laud on täis, mis tähendab viiki."
		};

        Content = new ScrollView
		{
			Content = new VerticalStackLayout
			{
				Padding = 30,
				Spacing = 20,
				Children =
				{
					titleLabel,	rulesLabel
				}
			}
		};
    }
}