using NUnit.Framework;
using Puissance4.Classe;

namespace Puissance4.Tests
{
    public class PileTests
    {
        private Pile pile;
        [SetUp]
        public void Setup()
        {
           this.pile = new Pile(8);
        }

        [Test]
        public void TestAddChip()
        {
            this.pile.addChip(new Chip(1));

             Assert.AreEqual(1, this.pile.listChip.Count);

             for(int i =0; i < 50; i++)
             {
                 this.pile.addChip(new Chip(i));
             }
             Assert.AreEqual(8, this.pile.listChip.Count);
        }
        
        [Test]
        public void TestFull()
        {
            this.pile.addChip(new Chip(1));

            Assert.IsTrue(this.pile.full());
        }
        
        [Test]
        public void TestPlace()
        {
            for(int i =0; i < 8; i++)
            {
                this.pile.addChip(new Chip(0));
            }
            this.pile.place(1);

            Assert.AreEqual(1, this.pile.getChipValue(7));
        }
        
    }
}