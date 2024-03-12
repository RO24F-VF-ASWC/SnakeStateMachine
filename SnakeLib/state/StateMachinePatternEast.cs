﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLib.state
{
    public class StateMachinePatternEast:IStateMachinePattern
    {
        private static readonly IStateMachinePattern NORTH = StateObjects.North;
        private static readonly IStateMachinePattern SOUTH = StateObjects.South;


        public IStateMachinePattern NextState(InputType input)
        {
            switch (input)
            {
                case InputType.FORWARD: return this;
                case InputType.LEFT: return NORTH;
                case InputType.RIGHT: return SOUTH;
            }

            return this;
        }

        public Move NextAction(InputType input)
        {
            switch (input)
            {
                case InputType.FORWARD: return MoveObjects.GoEast;
                case InputType.LEFT: return MoveObjects.GoNorth;
                case InputType.RIGHT: return MoveObjects.GoSouth;
            }

            return MoveObjects.GoEast;
        }
    }
}
