using System;
using System.Text;
namespace Puissance4.Classe
{
    public class Result
    {
        private Game Game;

        public Result(Game Game)
        {
            this.Game = Game;
        }

        public void win(Player player)
        {
            if(player is RealPlayer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Et c'est gagné");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Désolé c'est perdu"); 
                Console.ResetColor();
            }
            this.askGame();
        }

        private void askGame()
        {
            Boolean hasChoose = false;
            do
            {
                Console.WriteLine("ca relance ? " + "\n" + "Y or N" );
                String answer =  Console.ReadLine();
                if(answer.ToLower() == "y")
                {
                    hasChoose = true;
                    this.Game.newGame();
                }
                else if(answer.ToLower() == "n")
                {
                    this.exit();
                    hasChoose = true;
                }
                else
                {
                    Console.WriteLine("Saisir Y ou N !");
                }
            }
            while(!hasChoose);
        }

        private void exit()
        {
            Console.WriteLine("Adios !!");
        }
    }
}