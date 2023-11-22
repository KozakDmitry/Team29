using UnityEngine;

namespace Infostructure.Services.Input
{
    public class MobileInputService : InputService 
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}