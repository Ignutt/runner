using System;
using UnityEngine;

namespace Handlers
{
    public class InputHandler : Singletone<InputHandler>
    {
        public event Action OnShoot; 
        public event Action OnReload; 
        
        public event Action<float> OnMoveX; 
        public event Action<float> OnMoveY;

        public event Action OnScrollUp;
        public event Action OnScrollDown;
        
        public event Action<float> OnMouseX; 
        public event Action<float> OnMouseY; 

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Update()
        {
            OnMoveX?.Invoke(Input.GetAxis("Horizontal"));
            OnMoveY?.Invoke(Input.GetAxis("Vertical"));
            OnMouseX?.Invoke(Input.GetAxis("Mouse X"));

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnShoot?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReload?.Invoke();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                OnScrollDown?.Invoke();
            }
            
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                OnScrollUp?.Invoke();
            }
        }

        private void LateUpdate()
        {
            OnMouseY?.Invoke(Input.GetAxis("Mouse Y"));
        }
    }
}
