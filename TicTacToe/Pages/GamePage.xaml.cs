using TicTacToe.Models;

namespace TicTacToe.Pages;

public partial class GamePage : ContentPage
{
	GameLogic game = new GameLogic();
	Button[,] buttons = new Button[3, 3];

	int redScore = 0;
	int blueScore = 0;

	Label scoreLabel;
	Grid gameGrid;
    public GamePage(bool vsBot)
	{
		Title = "Mäng";

		scoreLabel = new Label
		{
			Text = "Punane: 0 | Sinine: 0",
			FontSize = 20,
			HorizontalOptions = LayoutOptions.Center
		};

		gameGrid = new Grid
		{
			HeightRequest = 300,
			WidthRequest = 300,
        };

		CreateGrid();

		var resetButton = new Button
		{
			Text = "Alusta uuesti",
			Command = new Command(OnResetClicked)
		};

		var switchButton = new Button
		{
			Text = "Vaheta mängija",
			Command = new Command(OnSwitchFirstClicked)
		};

		Content = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 10,
			Children =
			{
				scoreLabel,
				gameGrid,
				new HorizontalStackLayout
				{
					Children =
					{
						resetButton,
						switchButton
					}
				}
			}
		};
    }

    private void OnSwitchFirstClicked(object obj)
    {
		redScore = 0;
		blueScore = 0;
		UpdateScore();
		ResetBoard();
    }

    private void OnResetClicked(object obj)
    {
		game.CurrentPlayer = game.CurrentPlayer == Player.Red ? Player.Blue : Player.Red;
    }

    private void CreateGrid()
    {
        for (int i = 0; i < 3; i++)
		{
			gameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
				var btn = new Button
				{
					BackgroundColor = Colors.LightGray,
				};

				int r = row;
				int c = col;

				btn.Clicked += (s, e) => OnCellClicked(r, c, btn);

				buttons[row, col] = btn;
				gameGrid.Add(btn, col, row);

            }
        }
    }

    private async Task OnCellClicked(int row, int col, Button btn)
    {
        if (!game.MakeMove(row, col))	
        {
			return;
        }

		btn.BackgroundColor = game.CurrentPlayer == Player.Blue ? Colors.Red : Colors.Blue;

		var winner = game.CheckWinner();

		if (winner != Player.None)
		{
			if (winner == Player.Red)
			{
				redScore++;
			}
			else
			{
				blueScore++;
            }

			UpdateScore();

			await DisplayAlert("Mäng lõppenud", $"{winner} võitis!", "OK");
			ResetBoard();
        }
    }

    private void ResetBoard()
    {
		game.ResetGame();

		foreach (var btn in buttons)
		{
			btn.BackgroundColor = Colors.LightGray;
        }
    }

    private void UpdateScore()
    {
		scoreLabel.Text = $"Punane: {redScore} | Sinine: {blueScore}";
    }
}