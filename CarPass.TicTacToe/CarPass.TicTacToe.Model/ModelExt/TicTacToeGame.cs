using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Timers;

namespace CarPass.TicTacToe.Model
{
    [DataContract]
    public enum TicTacToeGameStatus : short
    {
        [EnumMember]
        PLAYING,
        [EnumMember]
        X_WIN,
        [EnumMember]
        O_WIN,
        [EnumMember]
        DRAW,
        [EnumMember]
        QUIT
    }

    public static class TicTacToeGameStatusExt
    {
        public static string TicTacToeGameStatusDisplayName(this short n)
        {
            return ((TicTacToeGameStatus)n).ToString().Replace("_","");
        }
    }

    public partial class TicTacToeGame
    {
        private const uint MAX_GAME_DURATION = 1 * 60;
        private const char E_TOKEN = '-';
        private const char X_TOKEN = 'X';
        private const char O_TOKEN = 'O';

        private char whoseTurn = X_TOKEN;
        private bool isGameOver = false;
        private Timer timer = new Timer(1*1000);        

        private char[,] tokens = { 
             { E_TOKEN, E_TOKEN, E_TOKEN }, 
             { E_TOKEN, E_TOKEN, E_TOKEN }, 
             { E_TOKEN, E_TOKEN, E_TOKEN } };

        public char[,] Tokens
        {
            get { return tokens; }            
        }
        
        public string GameMessage { get; set; }

        public DateTime? EndDate { get {
            DateTime? result = null;
            if (Status == (short)TicTacToeGameStatus.PLAYING)
            {
                StartDate.AddSeconds(DurationInSec);
            }
            return result;
        } }

        public TicTacToeGame() 
        {
            NewGame();
        }

        /** Reset the game */
        public void NewGame()
        {
            Status = (short)TicTacToeGameStatus.PLAYING;
            StartDate = DateTime.Now;
            DurationInSec = 0;

            whoseTurn = X_TOKEN;
            isGameOver = false;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tokens[i,j] = E_TOKEN;

            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += UpdateGameDuration;
            timer.Start();

            GameMessage = string.Format("Game starts @ {0}. {1} turn.",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), X_TOKEN);
        }

        private void UpdateGameDuration(Object obj, ElapsedEventArgs e)
        {
            DurationInSec++;
            if (DurationInSec >= MAX_GAME_DURATION)
            {
                QuitGame();
            }
        }

        public void QuitGame()
        {
            timer.Stop();
            Status = (short)TicTacToeGameStatus.QUIT;

            whoseTurn = X_TOKEN;
            isGameOver = false;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tokens[i, j] = E_TOKEN;

            GameMessage = string.Format("Game quits @ {0}.",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public void MarkValue(int i, int j)
        {
            // If cell is empty the game is not over
            if (Tokens[i,j] == E_TOKEN && whoseTurn != E_TOKEN && !isGameOver)
            {
                Tokens[i,j] = whoseTurn; // Set the token in the cell	
            }

            // Check game status
            if (IsWon(whoseTurn) && !isGameOver)
            {
                Status = whoseTurn == X_TOKEN ? (short)TicTacToeGameStatus.X_WIN :
                    (short)TicTacToeGameStatus.O_WIN;
                GameMessage = whoseTurn + " won! The game is over";
                
                isGameOver = true;
                whoseTurn = E_TOKEN;
                timer.Stop();
            }
            else if (IsFull() && !isGameOver)
            {
                Status = (short)TicTacToeGameStatus.DRAW;
                GameMessage = "Draw! The game is over";
                isGameOver = true;
                whoseTurn = E_TOKEN;
                timer.Stop();
            }
            else if (!isGameOver)
            {
                whoseTurn = (whoseTurn == X_TOKEN) ? O_TOKEN : X_TOKEN; // Change the turn
                GameMessage = whoseTurn + "'s turn";
            }
        }

        /** Determine if the cell are all occupied */
        public bool IsFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tokens[i, j] == E_TOKEN)
                        return false;
                }
            }
            return true;
        }

        /** Determine if the play with specified token wins */
        public bool IsWon(char token)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if ((tokens[i,0] == token) &&
                    (tokens[i,1] == token) &&
                    (tokens[i,2] == token))
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if ((tokens[0,j] == token) &&
                    (tokens[1,j] == token) &&
                    (tokens[2,j] == token))
                {
                    return true;
                }
            }

            // Check major diagonal
            if ((tokens[0,0] == token) &&
                (tokens[1,1] == token) &&
                (tokens[2,2] == token))
            {
                return true;
            }

            // Check minor diagonal
            if ((tokens[0,2] == token) &&
                (tokens[1,1] == token) &&
                (tokens[2,0] == token))
            {
                return true;
            }

            return false;
        }
    }
}
