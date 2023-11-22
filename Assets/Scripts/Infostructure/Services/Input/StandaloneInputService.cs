using UnityEngine;

namespace Infostructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 Axis = SimpleInputAxis();

                if (Axis == Vector2.zero)
                {
                    Axis = UnityAxis();
                }
                return Axis;
            }
        }

        protected Vector2 UnityAxis() =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}