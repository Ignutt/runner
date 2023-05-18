using Handlers;
using Player.Movement;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singletone<GameManager>
{
    [SerializeField] private UnityEvent onLose;
    [SerializeField] private UnityEvent onWin;
        
    public override void OnAwake()
    {
        Instance = this;
    }

    public void Lose()
    {
        PlayerMovement.Instance.enabled = false;
        InputHandler.Instance.enabled = false;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        onLose?.Invoke();
    }

    public void Win()
    {
        PlayerMovement.Instance.enabled = false;
        InputHandler.Instance.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        onWin?.Invoke();
    }
}
