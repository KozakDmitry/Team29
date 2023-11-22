﻿using System.Collections;
using UnityEngine;

namespace Infostructure.States
{
    public interface IState : IExitableState  
    {
        void Enter();
        void Exit();
       
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
        void Exit();
    }

    public interface IExitableState
    {
        void Exit();
    }
}