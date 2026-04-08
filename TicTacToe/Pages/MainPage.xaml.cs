namespace TicTacToe.Pages
{
    public partial class MainPage : ContentPage
    {
        Label titleLabel;
        Button startBtn;
        Button rulesBtn;
        public MainPage()
        {
            titleLabel = new Label
            {
                Text = "Trips-Traps-Trull",
                FontSize = 32,
                HorizontalOptions = LayoutOptions.Center
            };

            startBtn = new Button
            {
                Text = "Alusta",
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new ModePage());
                })
            };

            rulesBtn = new Button
            {
                Text = "Reeglid",
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new RulesPage());
                })
            };

            Content = new VerticalStackLayout
            {
                Padding = 30,
                Spacing = 20,
                Children =
                {
                    titleLabel, startBtn, rulesBtn
                }
            };
        }
    }
}