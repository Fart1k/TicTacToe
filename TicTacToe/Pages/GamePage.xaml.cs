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

	Button resetButton;
	Button switchButton;

	Label turnLabel;
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

		resetButton = new Button
		{
			Text = "Alusta uuesti",
			Command = new Command(OnResetClicked)
		};

		switchButton = new Button
		{
			Text = "Vaheta mängija",
			Command = new Command(OnSwitchFirstClicked)
		};

		turnLabel = new Label
		{
			Text = $"Mängija käik: {game.CurrentPlayer}",
			FontSize = 18,
			HorizontalOptions = LayoutOptions.Center
		};

        Content = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 10,
			Children =
			{
				scoreLabel,
				gameGrid,
				turnLabel,
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
        game.CurrentPlayer = game.CurrentPlayer == Player.Red ? Player.Blue : Player.Red;
        redScore = 0;
        blueScore = 0;
        UpdateScore();
		ResetBoard();

        UpdateTurnLabel();

    }

    private void OnResetClicked(object obj)
    {
        redScore = 0;
        blueScore = 0;
        UpdateScore();
        ResetBoard();
		UpdateTurnLabel();
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

				btn.Clicked += async (s, e) => await OnCellClicked(r, c, btn);

				buttons[row, col] = btn;
				gameGrid.Add(btn, col, row);

            }
        }
    }

    private async Task OnCellClicked(int row, int col, Button btn)
    {
		var currentPlayer = game.CurrentPlayer;

        if (!game.MakeMove(row, col))	
        {
			return;
        }

		btn.BackgroundColor = currentPlayer == Player.Red ? Colors.Red : Colors.Blue;
		UpdateTurnLabel();

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

			await DisplayAlertAsync("Mäng lõppenud", $"{winner} võitis!", "OK");
			ResetBoard();
			return;
        }

		if (game.IsDraw())
		{
			await DisplayAlertAsync("Mäng lõppenud", "Viik!", "OK");
			ResetBoard();
        }
    }

    private void UpdateTurnLabel()
    {
		turnLabel.Text = $"Mängija käik: {game.CurrentPlayer}";
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