using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Strike : Frame
    {
        public Strike() : base(10, 0) { }

        public override void AddBonus(Frame framePlusOne, Frame framePlusTwo)
        {
            if (framePlusOne is Strike)
                _frameScore += 10 + framePlusTwo.FirstRoll();
            else
                _frameScore += framePlusOne.FirstRoll() + framePlusOne.SecondRoll();
        }
    }
}
