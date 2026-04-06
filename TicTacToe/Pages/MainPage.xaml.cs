namespace TicTacToe.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Content = new VerticalStackLayout
            {
                Padding = 30,
                Spacing = 20,
                Children =
                {
                    new Label
                    {
                        Text = "Trips-Traps-Trull",
                        FontSize = 32,
                        HorizontalOptions = LayoutOptions.Center
                    },

                    new Button
                    {
                        Text = "Alusta",
                        Command = new Command(async () =>
                        {
                            await Navigation.PushAsync(new ModePage());
                        })
                    },

                    new Button
                    {
                        Text = "Reeglid",
                        Command = new Command(async () =>
                        {
                            await Navigation.PushAsync(new RulesPage());
                        })
                    }
                }
            };
        }
    }
}