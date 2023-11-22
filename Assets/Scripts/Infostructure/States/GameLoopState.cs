using UnityEngine;

namespace Infostructure.States
{
    public class GameLoopState : IState
    {
        public void Enter()
        {
            Debug.Log("InGame");


        }

        public void Exit()
        {

        }
    }
}