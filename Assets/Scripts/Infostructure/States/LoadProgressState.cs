

namespace Infostructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;


        public LoadProgressState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }

        public void Exit()
        {

        }
    }
}