using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Tests
{
    [TestClass]
    public class GameFixture
    {
        readonly Game _game = new Game();
        [TestMethod]
        public void Check_ActualScenario()
        {
            _game.RollStrike();
            _game.Roll(9, 1);
            _game.Roll(5, 5);
            _game.Roll(7, 2);
            _game.RollStrike();
            _game.RollStrike();
            _game.RollStrike();
            _game.Roll(9, 0);
            _game.Roll(8, 2);
            _game.RollFinalFrame(9, 1, 10);
            Assert.AreEqual(187, _game.GetScore());
        }
        [TestMethod]
        public void Validate_ZeroScore()
        {
            for (int i = 0; i < 10; i++) { _game.Roll(0, 0); }
            Assert.AreEqual(0, _game.GetScore());
        }
        [TestMethod]
        public void TestRollingAllOnes()
        {
            for (int i = 0; i < 10; i++) { _game.Roll(1, 1); }
            Assert.AreEqual(20, _game.GetScore());
        }

        [TestMethod]
        public void Check_CommonRecords()
        {
            _game.Roll(3, 3);
            _game.Roll(3, 3);
            _game.Roll(4, 4);
            _game.Roll(4, 4);
            _game.Roll(5, 5);
            _game.Roll(5, 5);
            _game.Roll(6, 6);
            _game.Roll(6, 6);
            _game.Roll(7, 7);
            _game.Roll(7, 7);
            Assert.AreEqual(111, _game.GetScore());
        }

        [TestMethod]
        public void Check_Strike_Count()
        {
            _game.Roll(1, 4);
            _game.Roll(4, 5);
            _game.Roll(6, 4);
            _game.Roll(5, 5);
            _game.RollStrike();
            _game.Roll(0, 1);
            _game.Roll(7, 3);
            _game.Roll(6, 4);
            _game.RollStrike();
            _game.RollFinalFrame(2, 8, 6);
            Assert.AreEqual(133, _game.GetScore());
        }
    }
}
