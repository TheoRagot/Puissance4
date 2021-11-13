using System;
using System.Text;
using System.Collections.Generic;

namespace Puissance4.Classe
{
    public class Game
    {
        private Result result;
        private Grille grille;
        private Boolean win;
        
        private List<Player> listPlayer;
        

        public Game(Grille grille, List<Player> listP){
            this.grille = grille;
            this.win = false;
            this.listPlayer = listP;
            this.result = new Result(this);
        }

        public void newGame() 
        {
            this.win = false;
            this.grille.init();
            Player currentPlayer = new Bot(69);

            while(!this.win)
            {
                int currentIndexPlayer = 0;

                while(!this.win && currentIndexPlayer < this.listPlayer.Count)
                {
                    currentPlayer = this.listPlayer[currentIndexPlayer];
                    currentPlayer.play(this.grille);
                    this.win = this.hasWin(currentPlayer);
                    currentIndexPlayer++;
                }
            }
            this.result.win(currentPlayer);
        }

        private Boolean hasWin(Player player)
        {   
            return grille.checkPlayerWin(player.id);
        }
    }
}