using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAccount player1 = new GameAccount("1Gamer");
            GameAccount player2 = new GameAccount("2Gamer");
            
            player1.winGame(player2, 25);
            player1.loseGame(player2, 29);
            player1.loseGame(player2, -26);//Гра не пройде, бо рейтинг, на який грають -- від'ємний
            player2.loseGame(player1, 22);
            player2.winGame(player1, 21);
            player2.winGame(player1, 27);

            player1.getStats();
            player2.getStats();
        }
    }
}
