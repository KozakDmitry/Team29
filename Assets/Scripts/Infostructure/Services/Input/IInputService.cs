using Infostructure.Services;
using UnityEngine;

namespace Infostructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}