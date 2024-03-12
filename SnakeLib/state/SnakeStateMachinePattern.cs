using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLib.state
{
    public class SnakeStateMachinePattern:IState
    {
        // internal StateMachine as pattern i.e. objects
        private IStateMachinePattern _currentState;

        public SnakeStateMachinePattern()
        {
            _currentState = new StateMachinePatternNorth();
        }

        public Move NextMove(InputType input)
        {
            // Find next move from current state and input
            Move nextMove = _currentState.NextAction(input);

            // Find next state from current state and input
            _currentState = _currentState.NextState(input);

            return nextMove;
        }
    }
}
