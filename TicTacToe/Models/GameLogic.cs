using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Models
{
    public enum Player
    {
        None,
        Red,
        Blue
    }
    public class GameLogic
    {
        public Player[,] Board { get; set; } = new Player[3, 3];
        public Player CurrentPlayer { get; set; } = Player.Red;

        public bool MakeMove(int row, int col)
        {
            if (Board[row, col] != Player.None)
                return false;

            Board[row, col] = CurrentPlayer;
            SwitchPlayer();
            return true;
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.Red ? Player.Blue : Player.Red;
        }

        public Player CheckWinner()
        {
            for (int i = 0; i < 3; i++ )
            {
                if (Board[i, 0] != Player.None &&
                    Board[i, 0] == Board[i, 1] &&
                    Board[i, 1] == Board[i, 2])
                {
                    return Board[i, 0];
                }

                if (Board[0, i] != Player.None &&
                Board[0, i] == Board[1, i] &&
                Board[1, i] == Board[2, i])
                {
                    return Board[0, i];
                }
            }

            if (Board[0, 0] != Player.None &&
            Board[0, 0] == Board[1, 1] &&
            Board[1, 1] == Board[2, 2])
            {
                return Board[0, 0];
            }
            if (Board[0, 2] != Player.None &&
                Board[0, 2] == Board[1, 1] &&
                Board[1, 1] == Board[2, 0])
            {
                return Board[0, 2];
            }
            return Player.None;
        }

        public bool IsDraw()
        {
            foreach (var cell in Board)
            {
                if (cell == Player.None)
                {
                    return false;
                }
            }

            return CheckWinner() == Player.None;
        }

        public void ResetGame(bool keepCurrentPlayer)
        {
            Board = new Player[3, 3];

            if (!keepCurrentPlayer)
            {
                CurrentPlayer = Player.Red;
            }
        }
    }
}
