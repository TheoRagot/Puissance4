using System;
using System.Text;

namespace Puissance4.Classe
{
    public abstract class Player
    {
        public int id { get; set; }

        public Player(int id)
        {
            this.id = id;
        }

        public abstract void play(Grille grille);
    }
}