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
        public float movementSpeed;
        public float _rotationSpeed;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }
        void FixedUpdate()
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
        
        }

       

    }
}