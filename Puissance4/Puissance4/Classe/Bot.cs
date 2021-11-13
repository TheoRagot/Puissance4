using System;
using System.Text;
using System.Threading;

namespace Puissance4.Classe
{
    public class Bot : Player
    {
        public Bot(int id) : base(id)
        {
            
        }
        public override void play(Grille grille)
        {
            int column = 0;
            Boolean isFull = true;
            Boolean isOutOfRange = true;

             do
            {
                Random random = new Random();
                column = random.Next(0, grille.width);
            
                isFull = grille.listPile[column].full();

                if(grille.width > column && !isFull)
                {
                    isOutOfRange = false;
                }              
            }
            while(isOutOfRange && isFull);

            Thread.Sleep(1000);
            grille.placeChip(column, this.id);
            grille.displayGrille();
        }
    }
}