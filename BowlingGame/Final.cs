namespace BowlingGame
{
    public class Final : Frame
    {
        private readonly int _pinsThirdRoll;

        public Final(int pinsFirstRoll, int pinsSecondRoll, int pinsThirdRoll) : base(pinsFirstRoll, pinsSecondRoll)
        {
            _pinsThirdRoll = pinsThirdRoll;
        }

        public override void AddBonus(Frame framePlusOne, Frame framePlusTwo)
        {
            _frameScore += _pinsThirdRoll;
        }

    }
}
