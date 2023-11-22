using Scripts.Infostructure.Services;
using UnityEngine;

namespace Scripts.Infostructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}