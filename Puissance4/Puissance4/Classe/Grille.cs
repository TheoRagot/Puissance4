using System;
using System.Text;
using Puissance4;
using System.Collections.Generic;

namespace Puissance4.Classe
{
    public class Grille
    {
        private int[,] board { get; set; }
        public List<Pile> listPile { get; set; }
        
        private int height;
        public int width {get; set; }

        public Grille(int width, int height) {
            this.height = height;
            this.width = width;
        }

        private String displayNumber()
        {
            String number = " ";

            for(var i = 0; i < this.width; i++)
            {
                number += i + " ";
            }
            return number;
        }

        private String displayBorderLine(String start, String middle, String end)
        {
            String bar ="";

            for (var y = 0; y < this.width; y++)
            {
                if(y == 0)
                {
                    bar += start;
                }
                else if(y != this.width -1){
                    bar += middle; 
                }
                else{
                    bar += end;
                }
            }
            return bar;
        }
        public void displayGrille()
        {   
            Console.WriteLine(displayNumber());
            Console.WriteLine(displayBorderLine("┌─","┬─", "┬─┐"));
            for (var i = 0; i < this.width; i++)
            {
                var line = new StringBuilder("│");

                for (var j = 0; j < this.height; j++)
                {
                    if (this.listPile[j].getChipValue(i) == 0)
                    {
                        line.Append(' ');
                    }
                    else if (this.listPile[j].getChipValue(i) == 1)
                    {
                        line.Append("O");
                    }
                    else
                    {
                        line.Append('X');
                    }
                    line.Append('│');
                }
                Console.WriteLine(line.ToString());

                if(i != this.width -1)
                {
                    Console.WriteLine(displayBorderLine("├─", "┼─","┼─┤"));
                }
            }
            Console.WriteLine(displayBorderLine("└─", "┴─", "┴─┘"));
        }
        public void init() 
        {
            this.listPile = new List<Pile>();
            this.board = new int[width, height];
            this.initPile();
            this.displayGrille();
        }

        private void initPile()
        {
            for(var i = 0; i < this.width; i++)
            {
                Pile pile = new Pile(this.height);
                
                for(var j = 0; j < this.width; j++)
                { 
                    pile.addChip(new Chip(0));
                }
                listPile.Add(pile);
            }
        }

        public void placeChip(int index, int idPlayer)
        {
            this.listPile[index].place(idPlayer);
        }

        public Boolean checkPlayerWin(int idPlayer)
        {
           return vertical(idPlayer) || horizontal(idPlayer);
        }

        private Boolean vertical(int idPlayer)
        {
            int verticalCounter = 0;
            Boolean win = false;
            int column = 0;

            while(!win && column < this.width)
            {
                verticalCounter = 0;

                int cursor = 0;

                while(!win && cursor < this.height)
                {
                    if(this.listPile[column].getChipValue(cursor) == idPlayer)
                    {
                        verticalCounter ++;
                    }
                    else{
                        verticalCounter = 0;
                    }
                    if(verticalCounter >= 4)
                    {
                        win = true;
                    }
                    cursor++;
                }
                column++;
            }
            return win;
        }

        private Boolean horizontal(int idPlayer)
        {
            int horizontalCounter = 0;
            Boolean win = false;
            int line = 0;

            while(!win && line < this.height)
            {
                horizontalCounter = 0;

                int cursor = 0;

                while(!win && cursor < this.width)
                {
                    if(this.listPile[cursor].getChipValue(line) == idPlayer)
                    {
                        horizontalCounter ++;
                    }
                    else{
                        horizontalCounter = 0;
                    }
                    if(horizontalCounter >= 4)
                    {
                        win = true;
                    }
                    cursor++;
                }
                line++;
            }
            return win;
        }
    }
}