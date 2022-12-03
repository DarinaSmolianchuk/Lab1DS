using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class GameAccount
    {
        //Ім'я
        private string userName;
        //Рейтинг
        private int currentRating = 0;
        //Кількість зіграних ігр
        private int gamesCount = 0;
        //Список з іграми
        private List<Game> history = new List<Game>();

        //Геттери/Сеттери
        public string getUserName() { return userName; }
        public int getCurrentRating() { return currentRating; }
        //Рейтинг не може бути менше 0
        //Якщо отримане значення менше 0, то встановлюємо 0
        public void setCurrentRating(int value) 
        {
            if (value < 0)
                currentRating = 0;
            else
                currentRating = value;
        }
        public int getGamesCount() { return gamesCount; }
        public List<Game> getHistory() { return history; }


        //Конструктор користувача. У стандартному випадку при реєстрації користувача у нього 0 ігр і такий же рейтинг
        public GameAccount(string userName) 
        {
            this.userName = userName;
        }

        //Виграш
        public void winGame(GameAccount opponent, int rating) 
        {
            try
            {
                //Якщо рейтинг, на який грають -- від'ємний, то гра не відбувається
                if (rating < 0)
                    throw new Exception("Error! Playing on incorrect rating!");

                //Зміна рейтингу і кількості ігор
                opponent.setCurrentRating(opponent.currentRating - rating);
                opponent.gamesCount++;
                setCurrentRating(currentRating + rating);
                gamesCount++;

                //Запис в історію
                //Грають оба гравці -- оба отримують запис в історію
                Game currentGame = new Game(this, opponent, rating, true);
                history.Add(currentGame);
                opponent.history.Add(currentGame);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //Програш
        public void loseGame(GameAccount opponent, int rating)
        {
            try
            {
                //Якщо рейтинг, на який грають -- від'ємний, то гра не відбувається
                if (rating < 0)
                    throw new Exception("Error! Playing on incorrect rating!\n");

                //Зміна рейтингу і кількості ігор
                opponent.setCurrentRating(opponent.currentRating + rating);
                opponent.gamesCount++;
                setCurrentRating(currentRating - rating);
                gamesCount++;

                //Запис в історію
                //Грають оба гравці -- оба отримують запис в історію
                Game currentGame = new Game(this, opponent, rating, false);
                history.Add(currentGame);
                opponent.history.Add(currentGame);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getStats()
        {
            //Якщо не грав -- відповідне повідомлення
            if (history == null) 
            {
                Console.WriteLine("Player " + userName + " not played yet!");
                return;
            }

            //Отримуємо дані щодо ігр
            Console.WriteLine("Player " + userName + ".\nRating: "  + currentRating + ".\nPlayed " + gamesCount  + " games:" );
            Console.WriteLine("\tID   \tOpponent   \tRating   \tResult");
            foreach (Game game in history)
            {
                Console.Write("\t" + game.getID());
                //В записі вказано 2 гравця, визначаємо який з них поточний
                if (game.getFirstPlayer().userName == userName)
                {
                    Console.Write("\t" + game.getSecondPlayer().userName + "\t\t" + game.getRating());
                    if (game.isFirstPlayerWin())
                        Console.WriteLine("\t\tWin");
                    else
                        Console.WriteLine("\t\tLose");
                }
                else
                {
                    Console.Write("\t" + game.getFirstPlayer().userName + "\t\t" + game.getRating());
                    if (game.isFirstPlayerWin())
                        Console.WriteLine("\t\tLose");
                    else
                        Console.WriteLine("\t\tWin");
                }
            }
            Console.WriteLine();
        }
    }
}
