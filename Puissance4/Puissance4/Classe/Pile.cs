using System;
using System.Text;
using System.Collections.Generic;
namespace Puissance4.Classe
{
    public class Pile
    {
        public List<Chip> listChip;
        private int height;

        public Pile(int height)
        {
            this.height = height;
            this.listChip = new List<Chip>();
        }
        public void addChip(Chip chip)
        {
            if(this.listChip.Count < this.height)
            {
                this.listChip.Add(chip);
            }
            
        }

        public int getChipValue(int index)
        {
            return this.listChip[index].idPlayer;
        }
        public Boolean full()
        {
            Boolean isFull = false;
            
            if(this.listChip[0].idPlayer != 0){
                isFull = true;
                Console.WriteLine("Colonne pleine");
            }   
            return isFull;
        }

        public void place(int idPlayer)
        {
            int i = listChip.Count -1;
            Boolean check = true;
            
            while(i >= 0 && check)
            {
                if(this.listChip[i].idPlayer == 0)
                {
                   this.listChip[i].idPlayer = idPlayer; 
                   check = false;
                }
                i--;
            }
        }

        public Boolean verfiPile(int index, int idPlayer)
        {
            return this.listChip[index].idPlayer == idPlayer;
        }
    }
}