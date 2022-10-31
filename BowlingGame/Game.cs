using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private readonly List<Frame> _frames = new List<Frame>();

        public static void Main()
        {
            Console.WriteLine("Welcome to Bowling Game");
            Game game = new Game();
            int i = 0;
            for (i = 1; i <= 10; i++)
            {
                Console.WriteLine("Enter score for Frame No - " +i);
                Console.WriteLine("First Roll");
                int first = Convert.ToInt32(Console.ReadLine());
                if (i <= 9)
                {
                    if (first == 10)
                    {
                        game.RollStrike();
                        Console.WriteLine("Congratulations! It was a strike.");
                    }
                    else
                    {
                        Console.WriteLine("Second Roll");
                        int second = Convert.ToInt32(Console.ReadLine());
                        game.Roll(first, second);
                    }
                }
                else
                {
                    if (first == 10)
                    {
                        Console.WriteLine("Congratulations! It was a strike.");
                    }
                    Console.WriteLine("Second Roll");
                    int second = Convert.ToInt32(Console.ReadLine());
                    if (first == 10 || first + second == 10)
                    {
                        Console.WriteLine("Third Roll");
                        int third = Convert.ToInt32(Console.ReadLine());
                        game.RollFinalFrame(first, second, third);
                    }
                    else game.Roll(first, second);
                }
            }
            Console.WriteLine("Final Score - " + game.GetScore());
            Console.ReadLine();
        }

        public int GetScore()
        {
            Add(new Open(0, 0));
            Add(new Open(0, 0));

            for (int i = 0; i < 10; i++)
                _frames[i].AddBonus(_frames[i + 1], _frames[i + 2]);

            int _totalScore = 0;
            _frames.ForEach(frame => _totalScore += frame.Score());
            return _totalScore;
        }

        public void Roll(int firstRoll, int secondRoll)
        {
            if (GameFinished())
                throw new GameOverException();

            Add(Frame.Create(firstRoll, secondRoll));
        }

        public void RollStrike()
        {
            Roll(10, 0);
        }

        private bool GameFinished()
        {
            return _frames.Count.Equals(10);
        }

        private void Add(Frame frame)
        {
            _frames.Add(frame);
        }

        public void RollFinalFrame(int firstRoll, int secondRoll, int thirdRoll)
        {
            Add(Frame.Create(firstRoll, secondRoll, thirdRoll));
        }
    }
}
