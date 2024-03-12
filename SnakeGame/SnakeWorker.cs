using System;
using System.Security.Cryptography;
using System.Threading;
using SnakeLib.snake;
using SnakeLib.state;

namespace SnakeGame
{
    internal class SnakeWorker
    {
        private int TimeDelay = 1000;
        private const int TimeDecrease = 100;
        public void Start()
        {
            SnakePlayground pg = new SnakePlayground(20,20);
            
            // using table state machine
            IState stateMachine = new SnakeTableStateMachine();

            // using state machine pattern
            //IState stateMachine = new SnakeStateMachinePattern();

            bool gameContinue = true;
            pg.PrintPlayground();

            while (gameContinue)
            {
                //Console.WriteLine("Point = " + pg.Point);

                InputType nextInput = ReadNextEvent();
                Move nextMove = stateMachine.NextMove(nextInput);

                gameContinue = pg.DoNextMove(nextMove);
                if (gameContinue)
                {
                    pg.PrintPlayground();
                }

                if (pg.IsLonger)
                {
                    TimeDelay = (TimeDelay < TimeDecrease) ? TimeDelay : TimeDelay - TimeDecrease;
                }
                Thread.Sleep(TimeDelay);
                
            }

            Console.WriteLine();
            Console.WriteLine("You loose :-( ");

        }


        private InputType ReadNextEvent()
        {
            InputType ev = InputType.FORWARD;

            Console.Write("Type next movement 'a,w,d' : ");
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                char c = info.KeyChar;
                switch (c)
                {
                    case 'a':
                        ev = InputType.LEFT;
                        break;
                    case 'd':
                        ev = InputType.RIGHT;
                        break;
                    case 'w':
                        ev = InputType.FORWARD;
                        break;
                }
            }

            return ev;
        }
    }
}