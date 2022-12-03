using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class Game
    {
        //Кількість всіх ігр
        private static int gamesCount = 0;
        //Змінні гри
        private int ID;
        private GameAccount firstPlayer;
        private GameAccount secondPlayer;
        private int rating;
        bool isWinFisrt;

        //Конструктор
        public Game(GameAccount firstPlayer, GameAccount secondPlayer, int rating, bool isWinFisrt)
        {
            ID = gamesCount++;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.rating = rating;
            this.isWinFisrt = isWinFisrt;
        }

        //Геттери
        public int getID() { return ID; }
        public GameAccount getFirstPlayer() { return firstPlayer; }
        public GameAccount getSecondPlayer() { return secondPlayer; }
        public int getRating() { return rating; }
        public bool isFirstPlayerWin() { return isWinFisrt; }
    }
}
