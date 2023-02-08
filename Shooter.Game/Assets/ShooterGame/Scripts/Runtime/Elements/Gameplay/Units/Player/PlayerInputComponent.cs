using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter
{
    /// <summary>
    /// Basic clasc player input class that handles player controlls such as moving,looking, shooting and reloading. 
    /// </summary>
    public class PlayerInputComponent : MonoBehaviour
    {
        public CharacterController CharacterController;
        [HideInInspector]
        public PlayerController Controller;

        private Vector2 movementInput;
        private Vector3 mousePosition;

        [SerializeField]
        private InputActionReference shoot, reload, movement, look;
        public float MouseSensitivity = 100f;
        public Camera PlayerCamera;

        private float rotationX = 0f;

        /// <summary>
        /// If the player should use basic controls instead of the example ones from the starter asset pack.
        /// </summary>
        public bool UseBasicControls = false;

        public void OnEnable()
        {
            shoot.action.performed += ShootWeapon;
            reload.action.performed += ReloadWeapon;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnDisable()
        {
            shoot.action.performed -= ShootWeapon;
            reload.action.performed -= ReloadWeapon;
            Cursor.lockState = CursorLockMode.None;
        }

        public void Update()
        {
            if (UseBasicControls)
            {
                LookControls();
                MoveControls();
            }
        }

        #region Basic Player Movement
        /// <summary>
        /// Very Basic Look Controls 
        /// </summary>
        private void LookControls()
        {
            mousePosition = look.action.ReadValue<Vector2>() * MouseSensitivity * Time.deltaTime;
            rotationX -= mousePosition.y;
            rotationX = Mathf.Clamp(rotationX, -75, 75);

            PlayerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.Rotate(Vector3.up * mousePosition.x);
        }

        /// <summary>
        /// Basic move controls.
        /// </summary>
        private void MoveControls()
        {
            movementInput = movement.action.ReadValue<Vector2>();
            Vector3 move = (movementInput.x * transform.right) + (movementInput.y * transform.forward);
            CharacterController.Move((move + (Vector3.down * 9.8f)) * Controller.Model.Definition.BaseMovementSpeed * Time.deltaTime);
        }

        #endregion

        private void ShootWeapon(InputAction.CallbackContext obj)
        {
            Controller.PlayerModel.EquippedWeapon?.HandleWeaponShootInput();
        }
        private void ReloadWeapon(InputAction.CallbackContext obj)
        {
            Controller.PlayerModel.EquippedWeapon?.HandleWeaponReloadInput();
        }
    }
}