using Scripts.Infostructure.Services;
using Scripts.Infostructure.States;

namespace Scripts.Infostructure
{
    public class Game
    {
        public GameStateMachine _stateMachine; 

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}