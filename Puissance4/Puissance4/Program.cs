using System;
using System.Text;
using Puissance4.Classe;
using System.Collections.Generic;

namespace Puissance4
{
    public class Program
    {    
        static void Main(string[] args)
        {
            Grille grille = new Grille(8,8);
            List<Player> listPlayer = new List<Player>()
            {
                new RealPlayer(1),
                new Bot(2)
            };
            Game Game = new Game(grille, listPlayer);
            Game.newGame();
        }
    }
}

