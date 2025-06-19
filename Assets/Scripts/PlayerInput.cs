using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public event Action OnNotesPressed;
    public event Action OnPausePressed;

    public bool IsInputEnabled { get; set; } = true;

    private void Update()
    {
        if (!IsInputEnabled && Time.timeScale != 0f)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            OnPausePressed?.Invoke();

        if (IsInputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
                OnNotesPressed?.Invoke();
        }
    }
}
