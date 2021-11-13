using System;
using System.Text;

namespace Puissance4.Classe
{
    public class RealPlayer : Player
    {
        public RealPlayer(int id) : base(id)
        {
            
        }
        public override void play(Grille grille)
        {
            int column = 0;
            Boolean isFull = true;
            Boolean isOutOfRange = true;

            do
            {
                Console.WriteLine($"Joueur {this.id}, en quelle colonne jouez-vous ?");
                String inputStr = Console.ReadLine();
           
                try
                {
                    column = int.Parse(inputStr);
                    isFull = grille.listPile[column].full();
                    if(grille.width > column && !isFull)
                    {
                        isOutOfRange = false;
                    }   
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Fait un effort y'a " + grille.width + " colonnes");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Fait un effort on te demmande un nombre");
                }
            }
            while(isOutOfRange && isFull);

            grille.placeChip(column, this.id);
            grille.displayGrille();
        }
    }
}