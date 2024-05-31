using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace X_O_GameApp
{
    public class Game
    {
        private string name;
        private bool isXPlayer;
        private int[,] board;
        public delegate void Mydelegate();
        public event Mydelegate ComputerWon;
        public event Mydelegate UserWon;
        public event Mydelegate Draw;
        public bool isGameOver;

        public Game(string name, bool isXPlayer)
        {
            this.name = name;
            this.isXPlayer = isXPlayer;
            this.board = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = -1;
                }
            }
            isGameOver = false;
        }
        
        public string getName()
        {
            return name;
        }

        public bool getIsXPlayer()
        {
            return isXPlayer;
        }

        public int[,] getBoard()
        {
            return board;
        }

        public void setField(int i, int j, int value)
        {
            if(this.board[i, j] == -1)
                this.board[i, j] = value;
        }

        public void setFieldComputer()
        {
            List<int> index = new List<int>();
            int nr = -1;
            if (isXPlayer)
                nr = 0;
            else
                nr = 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == -1)
                    {
                        index.Add(i * 10 + j);

                    }
                }
            }
            if(index.Count != 0)
            {
                Random random = new Random();
                int randomIndex = index[random.Next(index.Count)];
                this.board[randomIndex / 10, randomIndex % 10] = nr;
            }
        }

        public void gameOver()
        {
            int sumRow1 = board[0, 0] + board[0, 1] + board[0, 2];
            int sumRow2 = board[1, 0] + board[1, 1] + board[1, 2];
            int sumRow3 = board[2, 0] + board[2, 1] + board[2, 2];
            int sumCol1 = board[0, 0] + board[1, 0] + board[2, 0];
            int sumCol2 = board[0, 1] + board[1, 1] + board[2, 1];
            int sumCol3 = board[0, 2] + board[1, 2] + board[2, 2];
            int sumDiagPrinc = board[0, 0] + board[1, 1] + board[2, 2];
            int sumDiagSec = board[0, 2] + board[1, 1] + board[2, 0];
            bool isBoardFull = true;

            if(isXPlayer && (sumCol1 == 0 || sumCol2 == 0 || sumCol3 == 0 || sumRow1 == 0 || sumRow2 == 0 || sumRow3 == 0 || sumDiagPrinc == 0 ||sumDiagSec == 0))
            {
                ComputerWon?.Invoke();
                isGameOver = true;
                return;
            }
            else if(!isXPlayer && (sumCol1 == 0 || sumCol2 == 0 || sumCol3 == 0 || sumRow1 == 0 || sumRow2 == 0 || sumRow3 == 0 || sumDiagPrinc == 0 || sumDiagSec == 0))
            {
                UserWon?.Invoke();
                isGameOver = true;
                return;
            }
            if (isXPlayer && (sumCol1 == 9 || sumCol2 == 9 || sumCol3 == 9 || sumRow1 == 9 || sumRow2 == 9 || sumRow3 == 9 || sumDiagPrinc == 9 || sumDiagSec == 9))
            {
                UserWon?.Invoke();
                isGameOver = true;
                return;
            }
            else if (!isXPlayer && (sumCol1 == 9 || sumCol2 == 9 || sumCol3 == 9 || sumRow1 == 9 || sumRow2 == 9 || sumRow3 == 9 || sumDiagPrinc == 9 || sumDiagSec == 9))
            {
                ComputerWon?.Invoke();
                isGameOver = true;
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == -1)
                    {
                       isBoardFull = false;
                    }
                }
            }
            if(isBoardFull)
            {
                Draw?.Invoke();
                isGameOver = true;
                return;
            }
        }
    }
}
