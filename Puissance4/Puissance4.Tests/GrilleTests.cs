using NUnit.Framework;
using Puissance4.Classe;
using System.Collections.Generic;

namespace Puissance4.Tests
{
    public class GrilleTests
    {
        private Pile pile;
        private List<Pile> listPile = new List<Pile>();
        [SetUp]
        public void Setup()
        {
           this.pile = new Pile(7);
            
        }

        [Test]
        public void TestInitPile()
        {

         this.pile.addChip(new Chip(1));
         this.listPile.Add(this.pile);

        Assert.AreEqual(1, this.listPile.Count);
        }
    }
}