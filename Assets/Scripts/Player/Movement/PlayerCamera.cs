using System;
using Handlers;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform graphic;

        [Header("Sensitivity")] 
        [SerializeField] private float sensitivityX = 1;
        [SerializeField] private float sensitivityY = 1;
 
        private float _currentRotationX;
        private float _currentRotationY = 180;
        
        private void Start()
        {
            InputHandler.Instance.OnMouseY += value =>
            {
                _currentRotationX -= value * sensitivityX;
                _currentRotationX = Mathf.Clamp(_currentRotationX, -90, 90);
                
                transform.eulerAngles = new Vector3(_currentRotationX, transform.eulerAngles.y, 0);
            };
            
            InputHandler.Instance.OnMouseX += value =>
            {
                _currentRotationY += value * sensitivityY;
                
                transform.eulerAngles = new Vector3(_currentRotationX, _currentRotationY, 0);
                graphic.eulerAngles = Vector3.up * _currentRotationY;
            };

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
