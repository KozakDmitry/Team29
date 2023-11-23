using Scripts.Infostructure.Services.Input;
using Scripts.Infostructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public CharacterController characterController;
        public Animator anim;
        public float movementSpeed;
        public float gravity;
        public ParticleSystem movementEffect;

        private IInputService _inputService;

        public Transform target;
        public Transform targetIndicator;
        [HideInInspector]
        public bool safe;
        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }
        void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > 0.05f)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            characterController.Move(movementVector * (movementSpeed * Time.deltaTime));



           

            if (!safe)
            {
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
                Quaternion targetIndicatorRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
                targetIndicator.rotation = Quaternion.Slerp(targetIndicator.rotation, targetIndicatorRotation, Time.deltaTime * 50);
            }
        }

    }
}