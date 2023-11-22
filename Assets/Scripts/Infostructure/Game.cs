using Infostructure.Services;
using Infostructure.States;

namespace Infostructure
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