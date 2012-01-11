using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarPass.TicTacToe.Model;

namespace CarPass.TicTacToe.Process
{
    static class EXt
    {
        public static U GetValueOrDefault<T,U>(this Dictionary<T,U> dict, T key)
        {
            U result;

            if (dict.TryGetValue(key, out result))
                return result;
            return default(U);
        }
    }

    [Serializable]
    public class GameGridItem
    {
        internal GameGridItem() { }

        public string GameDate { get; set; }
        public string GameId { get; set; }
        public string GameStatus { get; set; }
        public string GameDuration { get; set; }
    }

    [Serializable]
    public class StatsGridItem
    {
        internal StatsGridItem() { }

        public string XWinPercent { get; set; }
        public string OWinPercent { get; set; }
        public string QuitPercent { get; set; }
        public string DrawPercent { get; set; }
    }

    public class TicTacToePresenter
    {
        private TicTacToeGame TheGame { get; set; }

        public string GameDuration { get {
            return TheGame == null ? string.Empty : TheGame.DurationInSec.ToString();
        } }

        public string Message { 
            get {
                return TheGame == null ? string.Empty : TheGame.GameMessage;
            } 
        }

        public bool IsReady 
        { 
            get 
            {
                return TheGame != null && TheGame.Status == (short)TicTacToeGameStatus.PLAYING; 
            } 
        }
        
        public char[,] GridValues
        {
            get
            {
                return TheGame != null ? TheGame.Tokens :
                   new char[,]{ 
             { '-', '-', '-' }, 
             { '-', '-', '-' }, 
             { '-', '-', '-' } };
            }
        }

        public GameGridItem[] PassedGames
        {
            get
            {
                var results = new GameGridItem[0];

                using (var container = new TicTacToeModelContainer())
                {
                    results = container.TicTacToeGameSet.OrderByDescending(g => g.StartDate).Take(10).ToArray()
                        .Select(g => new GameGridItem { 
                            GameId = g.Id.ToString(),
                            GameDate = g.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            GameStatus = g.Status.TicTacToeGameStatusDisplayName(),
                            GameDuration = g.DurationInSec.ToString()
                        }).ToArray();
                }

                return results;
            }
        }

        public IEnumerable<StatsGridItem> GamesStats
        {
            get
            {
                using (var container = new TicTacToeModelContainer())
                {
                    double total = container.TicTacToeGameSet.Count();
                    var results = container.TicTacToeGameSet.GroupBy(g=> (TicTacToeGameStatus)g.Status)
                        .Select(g => new 
                        {
                            Status = g.Key, Percent = g.Count()/ total
                        }).ToDictionary(x=> x.Status, x=> x.Percent);

                    yield return new StatsGridItem
                    {
                        DrawPercent = results.GetValueOrDefault(TicTacToeGameStatus.DRAW).ToString("0.00%"),
                        OWinPercent = results.GetValueOrDefault(TicTacToeGameStatus.O_WIN).ToString("0.00%"),
                        QuitPercent = results.GetValueOrDefault(TicTacToeGameStatus.QUIT).ToString("0.00%") ,
                        XWinPercent = results.GetValueOrDefault(TicTacToeGameStatus.X_WIN).ToString("0.00%"),
                    };
                }                
            }
        }

        public void NewGame()
        {

           TheGame = new TicTacToeGame();
        }

        public void QuitGame()
        {
            if (IsReady)
            {
                TheGame.QuitGame();
                EndGame();
            }
        }

        public void MarkValue(int i, int j)
        {
            TheGame.MarkValue(i, j);
            if (TheGame.Status != (short)TicTacToeGameStatus.PLAYING)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            // Save game 
            using (var container = new TicTacToeModelContainer())
            {
                if (container.TicTacToeGameSet.FirstOrDefault(g=>g.Id == TheGame.Id) == null)
                {
                    container.TicTacToeGameSet.AddObject(TheGame);
                    container.SaveChanges();
                }
            }

            // TheGame = null;
        }
    }
}
